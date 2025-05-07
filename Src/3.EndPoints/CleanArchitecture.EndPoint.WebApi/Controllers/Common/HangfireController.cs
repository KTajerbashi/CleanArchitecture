using CleanArchitecture.Core.Application.Library.Providers.HangfireBackgroundTask;
using Hangfire;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Common;

public class HangfireController : BaseController
{
    private readonly IBackgroundJobClient _backgroundJob;
    private readonly IJobService _jobService;

    public HangfireController(IBackgroundJobClient backgroundJob, IJobService jobService)
    {
        _backgroundJob = backgroundJob;
        _jobService = jobService;
    }

    [HttpGet("CreateOrder/{orderId}")]
    public IActionResult CreateOrder(int orderId)
    {

        ////// Enqueue background job
        //_backgroundJob.Enqueue<IBackgroundJobService>(x => x.Continuations("Create Order", () => _jobService.CreateOrderById(orderId)));
        //_backgroundJob.Enqueue<IBackgroundJobService>(x => x.Delayed(() => _jobService.UpdateOrderById(orderId),3000));
        //_backgroundJob.Enqueue<IBackgroundJobService>(x => x.FireAndForget(() => _jobService.RemoveOrderById(orderId)));
        //_backgroundJob.Enqueue<IBackgroundJobService>(x => x.Recurring("Read Order", () => _jobService.ReadData(orderId),CornType.Daily));


        _backgroundJob.Enqueue<IJobService>(x => x.CreateOrderById(orderId));
        _backgroundJob.Schedule<IJobService>(x => x.UpdateOrderById(orderId), TimeSpan.FromSeconds(5000));
        _backgroundJob.Enqueue<IJobService>(x => x.RemoveOrderById(orderId));
        RecurringJob.AddOrUpdate<IJobService>($"read-order-{orderId}", x => x.ReadData(orderId), Cron.Daily);

        return Ok();
    }


}
