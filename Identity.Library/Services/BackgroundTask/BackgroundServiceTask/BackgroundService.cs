
namespace Identity.Library.Services.BackgroundTask.BackgroundServiceTask
{
    public class BackgroundTaskService : BackgroundService
    {
        private readonly ILogger<BackgroundTaskService> _logger;

        public BackgroundTaskService(ILogger<BackgroundTaskService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Start BackgroundTaskService {DateTime.Now}");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Inside BackgroundTaskService {DateTime.Now}");
                await Task.Delay(1000, stoppingToken);
            }
            _logger.LogInformation($"End BackgroundTaskService {DateTime.Now}");
        }
    }
}
