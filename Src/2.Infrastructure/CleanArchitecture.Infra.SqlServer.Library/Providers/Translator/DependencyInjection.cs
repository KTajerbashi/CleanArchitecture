using CleanArchitecture.Core.Application.Library.Providers.Translator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infra.SqlServer.Library.Providers.Translator;

public static class DependencyInjection
{
    public static IServiceCollection AddParrotTranslator(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITranslator, ParrotTranslator>();
        services.Configure<ParrotTranslatorOptions>(configuration);
        return services;
    }

    public static IServiceCollection AddParrotTranslator(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddParrotTranslator(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddParrotTranslator(this IServiceCollection services, Action<ParrotTranslatorOptions> setupAction)
    {
        services.AddSingleton<ITranslator, ParrotTranslator>();
        services.Configure(setupAction);
        return services;
    }
}
