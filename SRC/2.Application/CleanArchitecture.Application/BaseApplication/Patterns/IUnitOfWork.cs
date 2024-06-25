namespace CleanArchitecture.Application.BaseApplication.Patterns;

public interface IUnitOfWork
{
    /// <summary>
    /// در صورت نیاز به کنترل تراکنش‌ها از این متد جهت شروع تراکنش استفاده می‌شود.
    /// </summary>
    void BeginTransaction();
    /// <summary>
    /// 
    /// </summary>
    void BeginTransactionAsync();

    /// <summary>
    /// در صورت کنترل دستی تراکنش از این متد جهت پایان موفقیت آمیز تراکنش استفاده می‌شود.
    /// </summary>
    void CommitTransaction();
    /// <summary>
    /// 
    /// </summary>
    void CommitTransactionAsync();

    /// <summary>
    /// در صورت بروز خطا در فرایند‌ها از این متد جهت بازگشت تغییرات استفاده می‌شود.
    /// </summary>
    void RollbackTransaction();
    /// <summary>
    /// 
    /// </summary>
    void RollbackTransactionAsync();

    /// <summary>
    /// برای تایید تراکنشی که اتوماتیک توسط سیستم ایجاد شده است از این متد استفاده می‌شود.
    /// </summary>
    /// <returns></returns>
    int SaveChange();

    /// <summary>
    /// برای تایید تراکنشی که اتوماتیک توسط سیستم ایجاد شده است از این متد استفاده می‌شود.
    /// </summary>
    /// <returns></returns>
    Task<int> SaveChangeAsync();
}
