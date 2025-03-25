using CleanArchitecture.Core.Application.Library.Identity.Repositories;
using CleanArchitecture.Core.Application.Library.UseCases.Security.UserHandlers.RegisterUser;
using CleanArchitecture.EndPoint.WebApi.Common.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.EndPoint.WebApi.Controllers;
public class AccountController : AuthController
{
    private readonly IIdentityService _identityService;
    public AccountController(
        IMediator mediator,
        IIdentityService identityService)
        : base(mediator)
    {
        _identityService = identityService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        return await RequestAsync<RegisterUserRequest, RegisterUserResponse>(request);
    }


}
