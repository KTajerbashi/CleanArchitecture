using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.WebApi.Extensions.Providers.Identity;

public static class IdentityExtensions
{
    public static IServiceCollection AddAuthorizationService(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddIdentityService(configuration)
            .AddOpenIdConnect()
            //.AddJWTService(configuration)
            .AddIdentityOption()
            .AddCookieService()
            .AddPoliciesService()
            ;

    private static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<UserEntity, RoleEntity>()
            .AddEntityFrameworkStores<CleanArchitectureDb>()
            .AddSignInManager()
            .AddRoles<RoleEntity>();
        return services;
    }

    private static IServiceCollection AddIdentityOption(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            // Password settings
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;

            // Sign in settings
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
        });
        return services;
    }

    private static IServiceCollection AddJWTService(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                };
            });
        services.AddAuthorization(option =>
        {
        });
        return services;
    }

    private static IServiceCollection AddOpenIdConnect(this IServiceCollection services)
    {
        services
            .AddAuthentication(cfg =>
            {
                cfg.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(cfg =>
            {
                cfg.Authority = "https://demo.identityserver.io";
                cfg.ClientId = "interactive.confidential";
                cfg.ClientSecret = "secret";
                cfg.ResponseType = "code";
                cfg.UsePkce = true;
                cfg.Scope.Clear();
                cfg.Scope.Add("openid");
                cfg.Scope.Add("profile");
            });
        return services;
    }

    private static IServiceCollection AddCookieService(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "YourAppCookie";
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;
        });
        return services;
    }

    private static IServiceCollection AddPoliciesService(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy =>
                policy.RequireRole("Admin"));

            options.AddPolicy("UserOnly", policy =>
                policy.RequireRole("User"));

            options.AddPolicy("Hangfire", cfgPolicy =>
            {
                cfgPolicy.AddRequirements().RequireAuthenticatedUser();
                cfgPolicy.AddAuthenticationSchemes(OpenIdConnectDefaults.AuthenticationScheme);
            });
        });
        return services;
    }

    public static void UseIdentity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}



