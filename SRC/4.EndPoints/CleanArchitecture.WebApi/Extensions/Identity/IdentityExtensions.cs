using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Infrastructure.DatabaseContext;
using CleanArchitecture.WebApi.Extensions.Identity.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
                .AddCookieConfiguration()
                .AddIdentityOptions()
                //.AddJWTServices(configuration)
                .AddPolicies()
                ;
    private static IServiceCollection AddCookieConfiguration(this IServiceCollection services)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

                options.LoginPath = "/Account/Login"; // Set your login path
                options.LogoutPath = "/Account/Logout"; // Set your logout path
                options.AccessDeniedPath = "/Account/AccessDenied"; // Set your access denied path
            });

        //services.ConfigureApplicationCookie(options =>
        //{
        //    // Cookie settings
        //    options.Cookie.HttpOnly = true;
        //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

        //    options.LoginPath = "/api/Account/Login";
        //    options.AccessDeniedPath = "/api/Account/AccessDenied";
        //    options.SlidingExpiration = true;
        //});
        services.AddScoped<IClaimsTransformation, ClaimsTransformer>();
        return services;
    }

    private static IServiceCollection AddIdentityOptions(this IServiceCollection services)
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
