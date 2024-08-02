using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanArchitecture.Infrastructure.Configurations.Interceptors;
/// <summary>
/// Audit Field 
/// ها قبل از ذخیره شدن باید مقدار دهی شود و اضافه شود
/// </summary>
public class AddAuditDataInterceptor : SaveChangesInterceptor
{
    /// <summary>
    /// قبل از ذخیره شدن 
    /// فیلد های شادو ست شوند
    /// </summary>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        AddShadowProperties(eventData);
        return base.SavingChanges(eventData, result);
    }

    /// <summary>
    /// قبل از ذخیره شدن 
    /// فیلد های شادو ست شوند
    /// </summary>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        AddShadowProperties(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    /// <summary>
    /// دیافت اطلاعات مورد نیاز از 
    /// ChangeTracker
    /// و اطلاعات مربوط به کاربر 
    /// ور ارسال به متد اکستنشن مورد ست کننده شادو
    /// </summary>
    /// <param name="eventData"></param>
    private static void AddShadowProperties(DbContextEventData eventData)
    {
        var changeTracker = eventData.Context.ChangeTracker;
        var userInfoService = eventData.Context.GetService<IUserInfoService>();
        changeTracker.SetAuditableEntityPropertyValues(userInfoService);
    }
}




