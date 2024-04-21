using System.Threading.Channels;

namespace Identity.Library.BackgroundTaskServices.Queues.Interfaces
{
    public interface IBackgroundTaskQueue
    {
        ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken,ValueTask> workitem);
        ValueTask<Func<CancellationToken,ValueTask>> DequeueAsync(CancellationToken cancellationToken);

    }
    public class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        private readonly Channel<Func<CancellationToken,ValueTask>> Queue;
        public BackgroundTaskQueue(int capacity)
        {
            var boundedChannelOptions = new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            Queue = Channel.CreateBounded<Func<CancellationToken,ValueTask>>(boundedChannelOptions);
        }
        public async ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken)
        {
            var workItem = await Queue.Reader.ReadAsync(cancellationToken);
            return workItem;
        }

        public async ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask> workitem)
        {
            if (workitem is null)
            {
                throw new ArgumentNullException(nameof(workitem));
            }
            await Queue.Writer.WriteAsync(workitem);
        }
    }
}
