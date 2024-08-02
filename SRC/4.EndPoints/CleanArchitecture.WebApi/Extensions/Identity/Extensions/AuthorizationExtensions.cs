using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.WebApi.Extensions.Identity.Extensions;

public static class AuthorizationExtensions
{
    public static IServiceCollection AddAuthorizationService(this IServiceCollection services,IConfiguration configuration)
    {
        return services
            .AddIdentityService()
            .AddCookieService()
            .AddPoliciesService()
            ;
    }

    private static IServiceCollection AddIdentityService(this IServiceCollection services)
    {

        services.AddIdentity<UserEntity, RoleEntity>(option =>
        {

        })
            .AddRoles<RoleEntity>()
            .AddEntityFrameworkStores<CleanArchitectureDb>()
            .AddDefaultTokenProviders()
            ;
        services.AddAuthentication();
        services.AddAuthorization();

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
        });
        return services;
    }


    public static void UseIdentity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}



