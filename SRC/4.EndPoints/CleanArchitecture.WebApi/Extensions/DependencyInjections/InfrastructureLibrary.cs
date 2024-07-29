using CleanArchitecture.Infrastructure.DependencyInjections;

namespace CleanArchitecture.WebApi.Extensions.DependencyInjections;

public static class InfrastructureLibrary
{
    public static IServiceCollection AddInfrastructureContainer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccess(configuration);
        return services;
    }
}
