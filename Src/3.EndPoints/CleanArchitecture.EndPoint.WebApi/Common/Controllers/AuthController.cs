using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.EndPoint.WebApi.Common.Controllers;

[Authorize]
public abstract class AuthController : BaseController
{
    protected AuthController(IMediator mediator) : base(mediator)
    {
    }
}
