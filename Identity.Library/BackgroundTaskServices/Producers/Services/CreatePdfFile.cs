using Identity.Library.BackgroundTaskServices.Queues.Interfaces;
using Microsoft.Identity.Web;

namespace Identity.Library.BackgroundTaskServices.Producers.Services
{
    public interface  ICreatePdfFile
    {
        void Create();
    }
    public class CreatePdfFile: ICreatePdfFile
    {
        private readonly ILogger<CreatePdfFile> logger;
        private readonly IBackgroundTaskQueue background;
        public CreatePdfFile(ILogger<CreatePdfFile> logger, IBackgroundTaskQueue background)
        {
            this.logger = logger;
            this.background = background;
        }

       public void Create()
        {
            background.QueueBackgroundWorkItemAsync(BuildWorktime);
        }
        private async ValueTask BuildWorktime(CancellationToken cancellationToken)
        {
            var FileCreated = false;
            while (!cancellationToken.IsCancellationRequested && !FileCreated)
            {
                FileCreated = await CreateFile(cancellationToken);
            }
            logger.LogInformation($"PDF File is Create {DateTime.Now.ToString("F")}");
        }
        private async Task<bool> CreateFile(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Delay(2000);
            logger.LogInformation($"PDF File is Create {DateTime.Now.ToString("F")}");
            return true;
        }
    }
}
