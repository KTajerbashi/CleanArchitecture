using CleanArchitecture.EndPoint.WebApi.Middlewares.ExceptionHandler;
using System.Text.Json;

namespace CleanArchitecture.EndPoint.WebApi.Middlewares.AuthorizedHandler;


public class AuthorizedMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<AuthorizedMiddleware> _logger;

    public AuthorizedMiddleware(RequestDelegate next, ILogger<AuthorizedMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // Create a buffer to capture the response
        var originalBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        try
        {
            await _next(context);

            // Only handle API requests
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                if (context.Response.StatusCode == StatusCodes.Status401Unauthorized ||
                    context.Response.StatusCode == StatusCodes.Status403Forbidden)
                {
                    _logger.LogWarning("Unauthorized/Forbidden access attempt to {Path}", context.Request.Path);

                    // Reset the stream and status code
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
                        TraceId = context.TraceIdentifier
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

            // Copy the modified response to the original stream
            responseBody.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
        finally
        {
            context.Response.Body = originalBodyStream;
        }
    }
}