using CleanArchitecture.Core.Application.Library.Identity.Repositories;
using CleanArchitecture.EndPoint.WebApi.Common.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.EndPoint.WebApi.Controllers;

public class AuthenticateController : BaseController
{
    private readonly IIdentityService _identityService;
    public AuthenticateController(IMediator mediator, IIdentityService identityService) : base(mediator)
    {
        _identityService = identityService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login()
    {
        return Ok("Login");
    }
    [HttpPost("LoginWithId/{id}")]
    public async Task<IActionResult> Login(long id)
    {
        var result = await _identityService.LoginAsAsync(id);
        return Ok(result);
    }

    [HttpPost("Signin")]
    public async Task<IActionResult> Signin()
    {
        await Task.CompletedTask;
        return Ok("Signin");
    }

    [HttpGet("SignOut")]
    public async Task<IActionResult> SignOut()
    {
        await Task.CompletedTask;
        return Ok("SignOut");
    }

    [HttpPut("DisActive")]
    public async Task<IActionResult> DisActive()
    {
        await Task.CompletedTask;
        return Ok("DisActive");
    }
}