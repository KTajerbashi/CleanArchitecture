using CleanArchitecture.Core.Application.Library.Providers.HangfireBackgroundTask;
using Hangfire;
using Hangfire.Dashboard;

namespace CleanArchitecture.Infra.SqlServer.Library.Providers.HangfireBackgroundTask;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();

        // Implement your authorization logic here
        // Example: Only allow authenticated admins
        return true;
        return httpContext.User.Identity.IsAuthenticated
            && httpContext.User.IsInRole("Admin");
    }
}

public class BackgroundJobService : IBackgroundJobService
{
    private readonly IBackgroundJobClient _backgroundJobClient;

    public BackgroundJobService(IBackgroundJobClient backgroundJobClient)
    {
        _backgroundJobClient = backgroundJobClient;
    }

    public Task EnqueueJobAsync(string jobName, object parameters)
    {
        _backgroundJobClient.Enqueue(() => Console.WriteLine($"Executing job: {jobName}"));
        return Task.CompletedTask;
    }

    public Task ScheduleJobAsync(string jobName, object parameters, TimeSpan delay)
    {
        _backgroundJobClient.Schedule(() => Console.WriteLine($"Scheduled job: {jobName}"), delay);
        return Task.CompletedTask;
    }
}




