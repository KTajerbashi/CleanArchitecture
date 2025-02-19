using CleanArchitecture.Core.Application.Library.Common.Patterns.MediatRPattern.Behaviours;
using CleanArchitecture.Core.Application.Library.Providers;
using CleanArchitecture.Core.Application.Library.Providers.ObjectMapper;
using CleanArchitecture.Core.Application.Library.Providers.Serializer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Core.Application.Library;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationLibrary(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddAutoMapperProfiles(configuration);

        services.AddEPPlusExcelSerializer();

        services.AddMicrosoftSerializer();

        services.AddScoped<ProviderServices>();

        services.AddMediatRService(configuration, assemblies);

        return services;
    }
    private static IServiceCollection AddMediatRService(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssemblies(assemblies.ToArray());
            option.AddOpenBehavior(typeof(AuthorizationBehaviour<,>));
            option.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            option.AddOpenBehavior(typeof(LoggingBehaviour<,>));
            option.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
            option.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
        });

        return services;
    }
}
