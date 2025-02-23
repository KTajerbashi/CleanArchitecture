using CleanArchitecture.Core.Application.Library.Common.Models.Requests;
using CleanArchitecture.EndPoint.WebApi.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArchitecture.EndPoint.WebApi.Common.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class BaseController : Controller
{
    protected IMediator mediator;

    protected BaseController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    protected virtual async Task<IActionResult> RequestAsync<TCommand, TCommandResult>(TCommand command)
       where TCommand : RequestModel<TCommandResult> => Ok(await mediator.Send(command));

    protected virtual async Task<IActionResult> RequestAsync<TCommand>(TCommand command)
      where TCommand : RequestModel
    {
        await mediator.Send(command);
        return Ok(true);
    }



    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
       => base.Ok(ApiResult.Return(value));
}
