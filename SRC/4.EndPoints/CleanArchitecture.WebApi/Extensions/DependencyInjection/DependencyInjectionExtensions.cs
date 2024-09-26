using CleanArchitecture.Application.Extensions.DIPattern;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace CleanArchitecture.WebApi.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddWebApplicationService(this IServiceCollection services, params string[] assemblyNamesForSearch)
    {
        var assemblies = GetAssemblies(assemblyNamesForSearch);
        return services.AddLifeDependencies(assemblies);
    }
    public static IServiceCollection AddLifeDependencies(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        =>  services.AddWithTransientLifetime(assemblies, typeof(ISingleLifeTime))
                    .AddWithScopedLifetime(assemblies, typeof(IScopeLifeTime))
                    .AddWithSingletonLifetime(assemblies, typeof(ITransientLifeTime));

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
        services.Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
    public static IServiceCollection AddWithSingletonLifetime(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch, params Type[] assignableTo)
    {
        services.Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        return services;
    }

    private static List<Assembly> GetAssemblies(string[] assemblyName)
    {
        var assemblies = new List<Assembly>();
        var dependencies = DependencyContext.Default.RuntimeLibraries;
        foreach (var library in dependencies)
        {
            if (IsCandidateCompilationLibrary(library, assemblyName))
            {
                var assembly = Assembly.Load(new AssemblyName(library.Name));
                assemblies.Add(assembly);
            }
        }
        return assemblies;
    }
    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assemblyName)
    {
        return assemblyName.Any(d => compilationLibrary.Name.Contains(d))
            || compilationLibrary.Dependencies.Any(d => assemblyName.Any(c => d.Name.Contains(c)));
    }
}
