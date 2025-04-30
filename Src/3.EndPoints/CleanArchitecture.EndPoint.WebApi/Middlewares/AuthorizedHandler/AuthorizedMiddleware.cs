using CleanArchitecture.EndPoint.WebApi.Middlewares.ExceptionHandler;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CleanArchitecture.EndPoint.WebApi.Middlewares.AuthorizedHandler;

   
public class AuthorizedMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<AuthorizedMiddleware> _logger;
    private readonly IConfiguration _configuration;

    public AuthorizedMiddleware(RequestDelegate next,
                              ILogger<AuthorizedMiddleware> logger,
                              IConfiguration configuration)
    {
        _next = next;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task Invoke(HttpContext context)
    {
        // First, try to authenticate the token if present
        await TryAuthenticateToken(context);

        var originalBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        try
        {
            await _next(context);

            if (context.Request.Path.StartsWithSegments("/api"))
            {
                if (context.Response.StatusCode == StatusCodes.Status401Unauthorized ||
                    context.Response.StatusCode == StatusCodes.Status403Forbidden)
                {
                    _logger.LogWarning("Unauthorized/Forbidden access attempt to {Path}", context.Request.Path);
                    responseBody.SetLength(0);

                    string message = context.Response.StatusCode == StatusCodes.Status401Unauthorized
                        ? "Authentication failed. Please provide valid credentials."
                        : "You don't have permission to access this resource.";

                    var response = new
                    {
                        Status = context.Response.StatusCode,
                        Type = context.Response.StatusCode == StatusCodes.Status401Unauthorized
                            ? "https://tools.ietf.org/html/rfc7235#section-3.1"
                            : "https://tools.ietf.org/html/rfc7231#section-6.5.3",
                        Title = context.Response.StatusCode == StatusCodes.Status401Unauthorized
                            ? "Unauthorized" : "Forbidden",
                        Detail = message,
                        Instance = context.Request.Path,
                        TraceId = context.TraceIdentifier,
                        IsAuthenticated = context.User?.Identity?.IsAuthenticated,
                        UserName = context.User?.Identity?.Name
                    };

                    context.Response.ContentType = "application/json";
                    var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    });

                    await context.Response.WriteAsync(jsonResponse);
                }
            }

            responseBody.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
        finally
        {
            context.Response.Body = originalBodyStream;
        }
    }

    private async Task TryAuthenticateToken(HttpContext context)
    {
        var identityOption = new IdentityOption();
        _configuration.Bind("IdentityOption", identityOption);
        await Task.CompletedTask;
        var token = GetTokenFromRequest(context);
        if (string.IsNullOrEmpty(token)) return;
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(identityOption.Jwt.Key);

            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = identityOption.Jwt.Issuer,
                ValidAudience = identityOption.Jwt.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                NameClaimType = ClaimTypes.Name,
                RoleClaimType = ClaimTypes.Role,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            context.User = principal;
            _logger.LogDebug("User {UserName} authenticated via middleware", principal.Identity.Name);
        }
        catch (Exception ex)
        {
            _logger.LogDebug("Token validation failed: {Message}", ex.Message);
            // Don't throw, just continue without setting the user
        }
    }

    private string GetTokenFromRequest(HttpContext context)
    {
        // Try from Authorization header first
        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
        {
            return authHeader.Substring("Bearer ".Length).Trim();
        }

        // Try from cookie if not found in header
        return context.Request.Cookies["access_token"];
    }
}