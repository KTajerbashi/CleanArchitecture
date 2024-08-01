using CleanArchitecture.Domain.BasesDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CleanArchitecture.Infrastructure.Configurations.Interceptors;

/// <summary>
/// Audit Shadow Property
/// </summary>
public class AuditingSaveChangesInterceptor : SaveChangesInterceptor
{
    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        SetShadowProperties(eventData.Context);
        return base.SavedChanges(eventData, result);
    }
    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        SetShadowProperties(eventData.Context);
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private void SetShadowProperties(DbContext context)
    {
        if (context == null) return;

        var entriesAdded = context.ChangeTracker.Entries()
            .Where(e => e.Entity.GetType().GetInterfaces()
                                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntity<>))
                        && e.State == EntityState.Added);

        foreach (var entry in entriesAdded)
        {
            // Set shadow property values, e.g., CreatedDate
            entry.Property("CreatedDate").CurrentValue = DateTime.Now;
            entry.Property("CreatedBy").CurrentValue = 1;
            entry.Property("IsDeleted").CurrentValue = false;
            entry.Property("IsActive").CurrentValue = true;
        }

        var entriesModified = context.ChangeTracker.Entries()
            .Where(e => e.Entity.GetType().GetInterfaces()
                                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntity<>))
                        && e.State == EntityState.Modified);

        foreach (var entry in entriesModified)
        {
            // Set shadow property values, e.g., CreatedDate
            entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
            entry.Property("UpdatedBy").CurrentValue = 1;
        }
    }
}
