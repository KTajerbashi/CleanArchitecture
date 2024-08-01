using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace CleanArchitecture.WebApi.Extensions.DependencyInjections;

public static class AddApiConfigurationExtensions
{
    public static IServiceCollection AddWebApiCore(this IServiceCollection services, params string[] assemblyNamesForLoad)
    {
        services
            .AddControllers();
            //.AddFluentValidation();
        services
            .AddDependencies(assemblyNamesForLoad);

        return services;
    }
}
public static class Extensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services,
        params string[] assemblyNamesForSearch)
    {

        var assemblies = GetAssemblies(assemblyNamesForSearch);
        //services
            //.AddApplicationServices(assemblies)
            //.AddDataAccess(assemblies)
            //.AddUtilityServices()
            //.AddCustomDependencies(assemblies);
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