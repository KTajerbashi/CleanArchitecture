using CleanArchitecture.EndPoint.WebApi.Extensions;

namespace CleanArchitecture.EndPoint.WebApi.Common.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ProviderServices ProviderServices => HttpContext.ApplicationContext();

    protected virtual async Task<IActionResult> RequestAsync<TCommand, TCommandResult>(TCommand command)
        where TCommand : RequestModel<TCommandResult> 
        => Ok(await ProviderServices.Mediator.Send(command));

    protected virtual async Task<IActionResult> RequestAsync<TCommand>(TCommand command)
      where TCommand : RequestModel
    {
        await ProviderServices.Mediator.Send(command);
        return Ok(true);
    }

    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
       => base.Ok(ApiResult.Return(value));
}
