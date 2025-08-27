using CleanArchitecture.Core.Application.Common.Repository;
using CleanArchitecture.Core.Application.Common.Service;
using CleanArchitecture.Core.Application.Providers.CacheSystem;
using CleanArchitecture.Core.Domain.UseCases.Security;
using CleanArchitecture.Infra.SqlServer.Data;
using CleanArchitecture.Infra.SqlServer.Data.Interceptors;
using CleanArchitecture.Infra.SqlServer.Data.Seed;
using CleanArchitecture.Infra.SqlServer.Identity;
using CleanArchitecture.Infra.SqlServer.Providers.CacheSystem.InMemory;
using CleanArchitecture.Infra.SqlServer.Providers.DataDapper;
using CleanArchitecture.Infra.SqlServer.Providers.Scrutor;

namespace CleanArchitecture.Infra.SqlServer;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureLibrary(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        return services
            .AddScrutor(configuration, assemblies, [typeof(IRepository<,>), typeof(IEntityService<,,>)])
            .AddDatabase(configuration)
            .AddDatabaseInterceptors()
            .AddInMemoryCaching()
            .AddIdentityConfigurations()
            .AddDataDapper(configuration)
            ;
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
        // Register the password hasher
        services.AddScoped<IPasswordHasher<AppUserEntity>, PasswordHasher<AppUserEntity>>();
        return services;
    }

    private static IServiceCollection AddDatabaseInterceptors(this IServiceCollection services)
    {
        services.AddScoped<ISaveChangesInterceptor, AddAuditDataInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        return services;
    }

    private static IServiceCollection AddInMemoryCaching(this IServiceCollection services)
    {
        return services
            .AddMemoryCache()
            .AddTransient<ICacheAdapter, InMemoryCacheAdapter>();
    }
}