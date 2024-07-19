namespace CleanArchitecture.WebApi.DIContainer;
public static class ApplicationLibrary
{
    public static IServiceCollection AddApplicationContainer(this IServiceCollection services) => 
        services.AddApplicationRepositories();
    private static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
    {
        return services;
    }
}
