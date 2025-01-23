using CleanArchitecture.Infra.SqlServer.Library.Providers.Translator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infra.SqlServer.Library;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureLibrary(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddParrotTranslator(configuration);

        return services;
    }
}
