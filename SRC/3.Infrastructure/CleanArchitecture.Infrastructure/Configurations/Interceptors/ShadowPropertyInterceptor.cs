using CleanArchitecture.Domain.BasesDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CleanArchitecture.Infrastructure.Configurations.Interceptors;

public class ShadowPropertyInterceptor : SaveChangesInterceptor
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
        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.Entity is IEntity<long>)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                    entry.Property("IsDeleted").CurrentValue = false;
                    entry.Property("IsActive").CurrentValue = true;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdateDate").CurrentValue = DateTime.UtcNow;
                    entry.Property("UpdateBy").CurrentValue = 1;
                }
            }             
        }
    }
}
