using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace CleanArchitecture.Core.Application.Library.Utilities.Extensions;

public static class AssemblyExtensions
{
    public static List<Assembly> GetAssemblies(this string assemblyNames)
    {
        var assemblies = new List<Assembly>();
        var dependencies = DependencyContext.Default?.RuntimeLibraries;

        foreach (var library in dependencies!)
        {
            if (IsCandidateCompilationLibrary(library, assemblyNames.Split(',')))
            {
                var assembly = Assembly.Load(new AssemblyName(library.Name));
                assemblies.Add(assembly);
            }
        }

        return assemblies;
    }

    public static List<Assembly> GetAssemblies(this Type type)
    {
        var assemblies = new List<Assembly>();
        var dependencies = type.GetAssemblies();

        foreach (var library in dependencies!)
        {
            var assembly = Assembly.Load(new AssemblyName(library.GetName().Name));
            assemblies.Add(assembly);
        }

        return assemblies;
    }
    public static List<Assembly> GetAssemblies(params string[] assemblyNames)
    {
        var assemblies = new List<Assembly>();
        var dependencies = DependencyContext.Default?.RuntimeLibraries;
        foreach (var assemble in assemblyNames)
        {
            foreach (var library in dependencies!)
            {
                if (IsCandidateCompilationLibrary(library, assemble.Split(',')))
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }
        }

        return assemblies;
    }

    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assemblyName)
        => assemblyName.Any(d => compilationLibrary.Name.Contains(d))
           || compilationLibrary.Dependencies.Any(d => assemblyName.Any(c => d.Name.Contains(c)));
}

