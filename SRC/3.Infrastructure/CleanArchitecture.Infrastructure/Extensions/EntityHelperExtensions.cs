using CleanArchitecture.Domain.BasesDomain;
using System.Reflection;

namespace CleanArchitecture.Infrastructure.Extensions;

public static class EntityHelperExtensions
{
    public static IEnumerable<Type> GetAllEntitiesImplementingIEntity(Assembly assembly)
    {
        var entityType = typeof(IEntity<>);

        return assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                         .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == entityType));
    }
}