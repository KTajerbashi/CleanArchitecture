using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.WebApi.Extensions.Identity;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
    =>
        services
                .AddIdentiyOptions()
                .AddCookieConfiguration()
                //.AddJWTServices(configuration)
                .AddPolicies()
                ;

    private static IServiceCollection AddIdentiyOptions(this IServiceCollection services)
    {
        services
            .AddIdentity<UserEntity, RoleEntity>()
            .AddRoles<RoleEntity>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<CleanArchitectureDb>();

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

    private static IServiceCollection AddCookieConfiguration(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            // Cookie settings
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

            options.LoginPath = "/api/Account/Login";
            options.AccessDeniedPath = "/api/Account/AccessDenied";
            options.SlidingExpiration = true;
        });

        return services;
    }
    
    private static IServiceCollection AddJWTServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure JWT Authentication
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });
        return services;
    }

    private static IServiceCollection AddPolicies(this IServiceCollection services)
    {

        return services;
    }

    public static void UseIdentityServiceConfiguration(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }


}
