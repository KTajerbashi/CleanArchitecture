using CleanArchitecture.Infra.SqlServer.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace CleanArchitecture.Infra.SqlServer.Data.Interceptors;

/// <summary>
/// برای " ی و ک " که باید فارسی شوند
/// </summary>
public class SetPersianYeKeInterceptor : DbCommandInterceptor
{
    /// <summary>
    /// برای اجرا شدن کویری مورد نظر لازم است تغییرات اعمال شوند
    /// </summary>
    /// <param name="command"></param>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
    {
        command.ApplyCorrectYeKe();
        return base.NonQueryExecuting(command, eventData, result);
    }

    /// <summary>
    /// برای اجرا شدن کویری مورد نظر لازم است تغییرات اعمال شوند
    /// </summary>
    /// <param name="command"></param>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        command.ApplyCorrectYeKe();
        return base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
    }

    /// <summary>
    /// برای اجرا شدن کویری مورد نظر لازم است تغییرات اعمال شوند
    /// </summary>
    /// <param name="command"></param>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
    {
        command.ApplyCorrectYeKe();
        return base.ReaderExecuting(command, eventData, result);
    }

    /// <summary>
    /// برای اجرا شدن کویری مورد نظر لازم است تغییرات اعمال شوند
    /// </summary>
    /// <param name="command"></param>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
    {
        command.ApplyCorrectYeKe();
        return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
    }

    /// <summary>
    /// برای اجرا شدن کویری مورد نظر لازم است تغییرات اعمال شوند
    /// </summary>
    /// <param name="command"></param>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
    {
        command.ApplyCorrectYeKe();
        return base.ScalarExecuting(command, eventData, result);
    }

    /// <summary>
    /// برای اجرا شدن کویری مورد نظر لازم است تغییرات اعمال شوند
    /// </summary>
    /// <param name="command"></param>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)
    {
        command.ApplyCorrectYeKe();
        return base.ScalarExecutingAsync(command, eventData, result, cancellationToken);
    }

}
