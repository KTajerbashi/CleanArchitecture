using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.WebApi.Extensions.Providers.OAuth;


public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services,
        IConfiguration configuration, string sectionName)
        => services
        .AddIdentity()
        .AddIdentityJWT(configuration, sectionName)
        .AddIdentityConfigs()
        .AddIdentityCookies()
        .AddIdentityPolicies();
    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<UserEntity, RoleEntity>()
            .AddRoles<RoleEntity>()
            .AddEntityFrameworkStores<CleanArchitectureDb>()
            .AddDefaultTokenProviders()
            ;

        return services;

    }
    private static IServiceCollection AddIdentityConfigs(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = false;
        });
        return services;
    }
    private static IServiceCollection AddIdentityCookies(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            // Cookie settings
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            options.LoginPath = "/Identity/Account/Login";
            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            options.SlidingExpiration = true;
        });
        return services;
    }
    private static IServiceCollection AddIdentityPolicies(this IServiceCollection services)
    {

        return services;
    }
    private static IServiceCollection AddIdentityJWT(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:ValidIssuer"],
                ValidAudience = configuration["Jwt:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };
        });
        services.AddAuthorization();
        return services;
    }
    public static void UseIdentity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}


