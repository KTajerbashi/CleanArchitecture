using CleanArchitecture.Core.Application.Library.Providers.Scrutor;

namespace CleanArchitecture.Infra.SqlServer.Library.Providers.Scrutor;

public static class DependencyInjections
{
    public static IServiceCollection AddScrutor(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies, params Type[] assignableTo)
    {
        services.Scan(s => s.FromAssemblies(assemblies).AddClasses(c => c.AssignableToAny(assignableTo)).AsImplementedInterfaces().WithTransientLifetime());
        services.Scan(s => s.FromAssemblies(assemblies).AddClasses(c => c.AssignableToAny(typeof(IScopeLifeTime))).AsImplementedInterfaces().WithScopedLifetime());
        services.Scan(s => s.FromAssemblies(assemblies).AddClasses(c => c.AssignableToAny(typeof(ISingletonLifeTime))).AsImplementedInterfaces().WithSingletonLifetime());
        services.Scan(s => s.FromAssemblies(assemblies).AddClasses(c => c.AssignableToAny(typeof(ITransientLifeTime))).AsImplementedInterfaces().WithTransientLifetime());
        return services;
    }
    public static IServiceCollection RegisterRepositoriesAndServices(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        => services.Scan(scan => scan
        .FromAssemblies(assemblies)
        .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
        .AsImplementedInterfaces()
        .WithScopedLifetime()
        .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
        .AsImplementedInterfaces()
        .WithScopedLifetime()
        );

    public static void RegisterRepositoriesAndServices(this IServiceCollection services)
    {
        // Get the assembly where your repositories and services are located
        var assembly = typeof(DependencyInjections).Assembly; // Or use a specific assembly

        // Register all repositories
        var repositoryTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"));

        foreach (var repoType in repositoryTypes)
        {
            var interfaceType = repoType.GetInterfaces()
                .FirstOrDefault(i => i.Name == $"I{repoType.Name}");
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, repoType);
            }
        }

        // Register all services
        var serviceTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"));

        foreach (var serviceType in serviceTypes)
        {
            var interfaceType = serviceType.GetInterfaces()
                .FirstOrDefault(i => i.Name == $"I{serviceType.Name}");
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, serviceType);
            }
        }
    }

    public static IServiceCollection AddWithTransientLifetime(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch, params Type[] assignableTo)
    {
        services
            .Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        return services;
    }

    public static IServiceCollection AddWithScopedLifetime(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch, params Type[] assignableTo)
    {
        services
            .Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }

    public static IServiceCollection AddWithSingletonLifetime(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch, params Type[] assignableTo)
    {
        services
            .Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        return services;
    }
}