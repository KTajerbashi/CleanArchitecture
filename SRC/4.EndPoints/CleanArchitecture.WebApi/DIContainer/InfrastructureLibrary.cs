using CleanArchitecture.Infrastructure.DIContainer;


namespace CleanArchitecture.WebApi.DIContainer;

public static class InfrastructureLibrary
{
    public static IServiceCollection AddInfrastructureContainer(this IServiceCollection services, IConfiguration configuration) =>
        services
        .AddDataAccess(configuration)
        ;
}
