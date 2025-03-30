using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace BlazorSolution.Core.Application.Common.Extensions;

public static class AssemblyProviderExtensions
{
    public static List<Assembly> GetAssembly(string assemblyName)
    {
        var assemblies = new List<Assembly>();
        var dependencies = DependencyContext.Default!.RuntimeLibraries;
        string[] assembles = [];
        assembles.Append(assemblyName);
        foreach (var library in dependencies)
        {
            if (IsCandidateCompilationLibrary(library, assembles))
            {
                var assembly = Assembly.Load(new AssemblyName(library.Name));
                assemblies.Add(assembly);
            }
        }
        return assemblies;
    }

    public static Assembly[] GetAssemblies(string[] assemblyName)
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
        return assemblies.ToArray();
    }
    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assemblyName)
    {
        return assemblyName.Any(d => compilationLibrary.Name.Contains(d))
            || compilationLibrary.Dependencies.Any(d => assemblyName.Any(c => d.Name.Contains(c)));
    }

}
