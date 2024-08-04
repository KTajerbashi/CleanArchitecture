using Hangfire;

namespace BackgroundTaskProvider.HangfireProvider.Services;

public class BackgroundTaskService
{
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly IRecurringJobManager _recurringJobManager;
    public BackgroundTaskService(
        IBackgroundJobClient backgroundJobClient,
        IRecurringJobManager recurringJobManager
        )
    {
        _backgroundJobClient = backgroundJobClient;
        _recurringJobManager = recurringJobManager;
    }
    public IBackgroundJobClient BackgroundJobClient => _backgroundJobClient;
    public IRecurringJobManager RecurringJobManager => _recurringJobManager;
}
