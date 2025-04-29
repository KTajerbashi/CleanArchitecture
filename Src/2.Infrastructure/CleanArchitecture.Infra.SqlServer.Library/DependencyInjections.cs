using CleanArchitecture.Core.Application.Library.Common.Repository;
using CleanArchitecture.Core.Application.Library.Common.Service;
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

    private static IServiceCollection AddInMemoryCaching(this IServiceCollection services)
    {
        return services
            .AddMemoryCache()
            .AddTransient<ICacheAdapter, InMemoryCacheAdapter>();
    }
}