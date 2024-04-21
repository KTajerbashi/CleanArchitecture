
using Identity.Library.BackgroundTaskServices.Queues.Interfaces;

namespace Identity.Library.BackgroundTaskServices.Consumers.Services
{
    public class QueuedHostedService : BackgroundService
    {
        private readonly IBackgroundTaskQueue backgroundTaskQueue;
        private readonly ILogger<QueuedHostedService> logger;
        public QueuedHostedService(IBackgroundTaskQueue backgroundTaskQueue, ILogger<QueuedHostedService> logger)
        {
            this.backgroundTaskQueue = backgroundTaskQueue;
            this.logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation($"{nameof(QueuedHostedService)} started");
            await BackgroundProcessing(stoppingToken);
            logger.LogInformation($"{nameof(QueuedHostedService)} finished");
        }

        private async Task BackgroundProcessing(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var workItem = await backgroundTaskQueue.DequeueAsync(cancellationToken);
                try
                {
                    await workItem.Invoke(cancellationToken);
                }
                catch (Exception ex)
                {
                    logger.LogError($"{ex} : Exception in WorkItem");
                }
            }
        }
    }
}
