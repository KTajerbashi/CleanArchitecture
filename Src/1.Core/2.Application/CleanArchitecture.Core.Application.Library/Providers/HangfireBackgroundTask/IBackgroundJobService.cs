using CleanArchitecture.Core.Application.Library.Providers.Scrutor;

namespace CleanArchitecture.Core.Application.Library.Providers.HangfireBackgroundTask;

public interface IBackgroundJobService
{
    Task EnqueueJobAsync(string jobName, object parameters);
    Task ScheduleJobAsync(string jobName, object parameters, TimeSpan delay);
    // Add other job operations as needed
}


public interface IUserTask : IScopeLifeTime
{
    void UpdateUserFromWebService();
    Task SendEmailAsync(int orderId);
}