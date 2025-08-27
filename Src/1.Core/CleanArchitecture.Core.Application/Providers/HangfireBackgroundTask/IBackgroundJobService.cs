using CleanArchitecture.Core.Application.Providers.Scrutor;
using System.Linq.Expressions;

namespace CleanArchitecture.Core.Application.Providers.HangfireBackgroundTask;
public enum CornType : int
{
    Minutly,
    Hourly,
    Daily,
    Weekly,
    Monthly,
}
/// <summary>
/// Enqueued – Job is created and waiting for processing.
/// Processing – Job is being executed by a worker.
/// Succeeded – Job completed successfully.
/// Failed – Job threw an exception.
/// Deleted – Job was manually or automatically deleted.
/// </summary>
public interface IBackgroundJobService : IScopeLifeTime
{
    /// <summary>
    /// Executes a job once, immediately
    /// </summary>
    /// <param name="action"></param>
    void FireAndForget(Expression<Action> action);//BackgroundJob.Enqueue(() => SendEmail());

    /// <summary>
    /// Executes a job once, after a specified delay
    /// </summary>
    /// <param name="action"></param>
    /// <param name="secondDelay"></param>
    void Delayed(Expression<Action> action, int secondDelay);//BackgroundJob.Schedule(() => SendEmail(), TimeSpan.FromMinutes(5));

    /// <summary>
    /// Executes a job on a schedule (e.g., daily, weekly, cron-based)
    /// </summary>
    /// <param name="jonId"></param>
    /// <param name="action"></param>
    /// <param name="corn"></param>
    void Recurring(string jonId, Expression<Action> action, CornType corn);//RecurringJob.AddOrUpdate("jobId", () => SendReport(), Cron.Daily);

    /// <summary>
    /// Executes a job after another job finishes
    /// </summary>
    /// <param name="parnentId"></param>
    /// <param name="action"></param>
    void Continuations(string parnentId, Expression<Action> action);//BackgroundJob.ContinueWith(parentId, () => DoNext());
    //void Batches();   // Pro Version
}
