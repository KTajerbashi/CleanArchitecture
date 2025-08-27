using CleanArchitecture.Core.Application.Providers.UserManagement;
using CleanArchitecture.Infra.SqlServer.Data;
using CleanArchitecture.Infra.SqlServer.Data.Constants;
using CleanArchitecture.Infra.SqlServer.Identity.Entities;
using CleanArchitecture.Infra.SqlServer.Identity.Handlers;
using CleanArchitecture.Infra.SqlServer.Identity.Models;
using CleanArchitecture.Infra.SqlServer.Identity.Polymorphism;
using CleanArchitecture.Infra.SqlServer.Identity.Repositories;
using CleanArchitecture.Infra.SqlServer.Identity.Service;

namespace CleanArchitecture.EndPoint.WebApi.Providers;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        // Add this to your service configuration
        services.Configure<IdentityOptions>(configuration.GetSection(sectionName));

        services.AddIdentityServices(configuration);
        services.AddIdentityPolicies(configuration, sectionName);

        return services;
    }

    private static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IUser, UserInfoService>();
        services.AddScoped<ITokenService, JwtTokenService>();

        services.AddIdentity<UserEntity, RoleEntity>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<DatabaseContext>()
        .AddRoles<RoleEntity>()
        .AddDefaultTokenProviders()
        .AddApiEndpoints();

        services.AddScoped<SignInManager<UserEntity>, AppSignInManager<UserEntity>>();
        services.AddScoped<UserManager<UserEntity>, AppUserManager<UserEntity>>();
        services.AddScoped<IUserClaimsPrincipalFactory<UserEntity>, AppUserClaimsFactory>();

        return services;
    }


    private static IServiceCollection AddIdentityPolicies(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        var identityOption = new IdentityOption();
        configuration.Bind(sectionName, identityOption);

        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.Name = "_auth.Session";
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        });

        // Configure both Cookie and JWT authentication
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = "JWT_OR_COOKIE";
            options.DefaultChallengeScheme = "JWT_OR_COOKIE";
        })
        .AddPolicyScheme("JWT_OR_COOKIE", "JWT_OR_COOKIE", options =>
        {
            options.ForwardDefaultSelector = context =>
            {
                var authorization = context.Request.Headers.Authorization.FirstOrDefault();
                if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
                {
                    // Verify the token structure before accepting
                    var token = authorization.Substring("Bearer ".Length).Trim();
                    if (token.Count(c => c == '.') == 2) // Basic JWT structure check
                    {
                        return JwtBearerDefaults.AuthenticationScheme;
                    }
                }
                return "AuthorizationCookies";
            };
        })
        .AddCookie("AuthorizationCookies", options =>
        {
            options.Cookie.Name = "_auth.TK";
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(identityOption.Jwt.ExpireMinutes);

            options.Events.OnRedirectToLogin = context =>
            {
                if (context.Request.Path.StartsWithSegments("/api"))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                }
                context.Response.Redirect(context.RedirectUri);
                return Task.CompletedTask;
            };
        })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true, // Changed to true to validate token expiration
                ValidateIssuerSigningKey = true,
                ValidIssuer = identityOption.Jwt.Issuer,
                ValidAudience = identityOption.Jwt.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identityOption.Jwt.Key)),
                ClockSkew = TimeSpan.FromMinutes(1) // Added small clock skew
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    // Manually extract token from headers
                    var authorization = context.Request.Headers["Authorization"].FirstOrDefault();

                    if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
                    {
                        context.Token = authorization.Substring("Bearer ".Length).Trim();

                        // Additional validation
                        if (string.IsNullOrEmpty(context.Token) ||
                            context.Token.Split('.').Length != 3)
                        {
                            context.Fail("Invalid token format");
                            return Task.CompletedTask;
                        }
                    }
                    else
                    {
                        // Try to get token from cookies as fallback
                        context.Token = context.Request.Cookies["access_token"];
                    }

                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception is SecurityTokenExpiredException)
                    {
                        context.Response.Headers.Append("Token-Expired", "true");
                    }
                    Console.WriteLine($"Authentication failed: {context.Exception}");
                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    var authorization = context.Request.Headers["Authorization"].FirstOrDefault();
                    if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
                    {
                        string token = authorization.Substring("Bearer ".Length).Trim();
                        var handler = new JwtSecurityTokenHandler();
                        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                    }


                    Console.WriteLine("Token successfully validated");
                    return Task.CompletedTask;
                },
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";

                    var errorMessage = context.AuthenticateFailure switch
                    {
                        SecurityTokenExpiredException => "Token expired",
                        SecurityTokenInvalidAudienceException => "Invalid audience",
                        SecurityTokenInvalidIssuerException => "Invalid issuer",
                        _ => "Unauthorized"
                    };

                    var result = JsonSerializer.Serialize(new { error = errorMessage });
                    return context.Response.WriteAsync(result);
                }
            };

        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator));

            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddAuthenticationSchemes("JWT_OR_COOKIE")
                .Build();

            // Admin policy - requires Admin role
            options.AddPolicy(Policies.AdminAccess, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole(Roles.Administrator);
                // You can add additional requirements
                // policy.RequireClaim("Department", "IT");
            });

            // User policy - requires either User or Admin role
            options.AddPolicy(Policies.UserAccess, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireAssertion(context =>
                    context.User.IsInRole(Roles.User) ||
                    context.User.IsInRole(Roles.Administrator));
            });

            // Example of a more complex policy
            options.AddPolicy(Policies.ContentManager, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole(Roles.ContentManager);
                policy.RequireClaim("CanEditContent", "true");
            });

            options.AddPolicy("Over18", policy => policy.Requirements.Add(new MinimumAgeRequirement(18)));

        });

        return services;
    }


}

