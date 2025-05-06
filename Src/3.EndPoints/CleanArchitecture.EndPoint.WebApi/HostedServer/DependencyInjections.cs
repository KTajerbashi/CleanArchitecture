namespace CleanArchitecture.EndPoint.WebApi.HostedServer;

public static class DependencyInjections
{
    public static IServiceCollection RegisterHostedService(this IServiceCollection services)
    {
        services.AddHostedService<HangfireHost>();
        services.AddHostedService<ServiceHost>();
        return services;
    }
}