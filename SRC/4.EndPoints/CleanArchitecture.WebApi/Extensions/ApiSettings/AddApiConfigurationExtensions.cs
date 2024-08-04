using CleanArchitecture.WebApi.Extensions.StartupApplication;

namespace CleanArchitecture.WebApi.Extensions.ApiSettings;

public static class AddApiConfigurationExtensions
{
    public static IServiceCollection AddWebApiCore(this IServiceCollection services, IConfiguration configuration, params string[] assemblyNamesForLoad)
    {
        services

            .AddControllers();

        //.AddFluentValidation();
        services.AddDependencies(assemblyNamesForLoad);

        return services;
    }
}
