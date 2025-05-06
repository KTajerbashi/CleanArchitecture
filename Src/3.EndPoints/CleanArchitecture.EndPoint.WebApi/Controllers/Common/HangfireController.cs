using CleanArchitecture.Core.Application.Library.Providers.HangfireBackgroundTask;
using Hangfire;
using System.Data;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Common;

public class HangfireController : BaseController 
{
    private readonly IBackgroundJobClient _backgroundJob;

    public HangfireController(IBackgroundJobClient backgroundJob)
    {
        _backgroundJob = backgroundJob;
    }

    [HttpGet("CreateOrder/{orderId}")]
    public IActionResult CreateOrder(int orderId)
    {
        // ... create order logic

        // Enqueue background job
        _backgroundJob.Enqueue<IUserTask>(x => x.SendEmailAsync(orderId));

        return Ok();
    }
}
