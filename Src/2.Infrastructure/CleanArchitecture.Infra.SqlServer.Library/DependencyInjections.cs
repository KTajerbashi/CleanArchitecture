using CleanArchitecture.Core.Application.Library.Common.Repository;
using CleanArchitecture.Core.Application.Library.Common.Service;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;
using CleanArchitecture.Infra.SqlServer.Library.Providers.Scrutor;

namespace CleanArchitecture.Infra.SqlServer.Library;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureLibrary(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        return services
            .AddScrutor(configuration, assemblies, [typeof(IRepository<,>), typeof(IEntityService<,,>)])
            .AddDatabase(configuration)
            .AddDatabaseInterceptors()
            .AddIdentity(configuration)
            .AddIdentityPolicies()
            .AddInMemoryCaching();
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                   .AddInterceptors(
                        new SetPersianYeKeInterceptor(),
                        new AddAuditDataInterceptor()
                   );
        });

        services.AddScoped<InitializerSeedData>();

        return services;
    }

    private static IServiceCollection AddDatabaseInterceptors(this IServiceCollection services)
    {
        services.AddScoped<ISaveChangesInterceptor, AddAuditDataInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        return services;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IUser, UserInfoService>();

        services.AddIdentity<UserEntity, RoleEntity>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
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

    private static IServiceCollection AddIdentityPolicies(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.Name = "_auth.TK";
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        });

        services.AddAuthentication("AuthorizationCookies")
            .AddCookie("AuthorizationCookies", options =>
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

    private static IServiceCollection AddInMemoryCaching(this IServiceCollection services)
    {
        return services
            .AddMemoryCache()
            .AddTransient<ICacheAdapter, InMemoryCacheAdapter>();
    }
}
