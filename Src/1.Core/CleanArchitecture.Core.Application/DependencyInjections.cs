using CleanArchitecture.Core.Application.Common.Patterns.MediatRPattern.Behaviours;
using CleanArchitecture.Core.Application.Providers;
using CleanArchitecture.Core.Application.Providers.ObjectMapper;
using CleanArchitecture.Core.Application.Providers.Serializer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Core.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationLibrary(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddAutoMapperProfiles(configuration);

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
