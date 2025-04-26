using CleanArchitecture.EndPoint.WebApi.Common.Controllers;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;
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

    //[HttpPost("Register")]
    //public async Task<IActionResult> Register(RegisterUserRequest request)
    //{
    //    return await RequestAsync<RegisterUserRequest, RegisterUserResponse>(request);
    //}


}
