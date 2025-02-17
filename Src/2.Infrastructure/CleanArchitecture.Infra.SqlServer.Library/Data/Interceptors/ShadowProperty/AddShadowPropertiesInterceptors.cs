using CleanArchitecture.Core.Application.Library.Identity.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Interceptors.ShadowProperty;

/// <summary>
/// AddInterceptors into ConnectionString 
/// </summary>
public class AddShadowPropertiesInterceptors : SaveChangesInterceptor
{
    private readonly IUser _user;
    private readonly TimeProvider _timeProvider;

    public AddShadowPropertiesInterceptors(IUser user, TimeProvider timeProvider)
    {
        _user = user;
        _timeProvider = timeProvider;
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        AddShadowProperties(eventData);
        return base.SavedChanges(eventData, result);
    }

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        AddShadowProperties(eventData);
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private static void AddShadowProperties(DbContextEventData eventData)
    {
        var changeTracker = eventData.Context.ChangeTracker;
        var userInfoService = eventData.Context.GetService<IUser>();
        changeTracker.SetAuditableEntityPropertyValues(userInfoService);
    }

}
