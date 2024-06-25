using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.DIContainer;

public static class InfrastructureDIContainer
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        return services
            .AddRepositories()
            .AddApplicationServices();
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}
