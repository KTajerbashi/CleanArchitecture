﻿using CleanArchitecture.Core.Application.Library.Identity.Repositories;
using CleanArchitecture.Infra.SqlServer.Library.Data;
using CleanArchitecture.Infra.SqlServer.Library.Data.Constants;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Infra.SqlServer.Library;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureLibrary(this IServiceCollection services, IConfiguration configuration)
        => services
        .AddDatabase(configuration)
        .AddIdentityConfiguration(configuration)
        .AddIdentityPolicies()
        ;
    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }


    private static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddIdentity<UserEntity, RoleEntity>(options =>
        {
            options.Password.RequiredLength = 6;  // Set the minimum password length
            options.Password.RequireDigit = true;  // Require at least one digit in password
            options.Password.RequireLowercase = true; // Require at least one lowercase letter
            options.Password.RequireUppercase = true; // Require at least one uppercase letter
            options.Password.RequireNonAlphanumeric = false; // Optional: Allow non-alphanumeric characters
        })
        .AddEntityFrameworkStores<DatabaseContext>()  
        .AddRoles<RoleEntity>()                 
        .AddDefaultTokenProviders();                   
                                                       //   .AddApiEndpoints();
                                                       //services.AddScoped(typeof(SignInManager<UserEntity>), typeof(CustomSignInManager<UserEntity>));
                                                       //services.AddScoped(typeof(UserManager<UserEntity>), typeof(CustomUserManager<UserEntity>));
                                                       //services.AddScoped<IUserClaimsPrincipalFactory<UserEntity>, CustomUserClaimsFactory>();
        return services;
    }
    private static IServiceCollection AddIdentityPolicies(this IServiceCollection services)
    {
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.Name = "_auth.TK";
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        });
        services.AddAuthentication("AuthorizationCookies")
            .AddCookie(options =>
            {
                options.Cookie.Name = "_auth.TK";
                options.Events.OnRedirectToLogin = context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api") && context.Response.StatusCode == StatusCodes.Status200OK)
                    {
                        context.Response.Clear();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.CompletedTask;
                    }
                    context.Response.Redirect(context.RedirectUri);
                    return Task.CompletedTask;
                };
            });
        services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator));
        });

        return services;
    }
}
