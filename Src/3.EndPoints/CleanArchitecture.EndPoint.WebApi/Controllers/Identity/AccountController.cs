using CleanArchitecture.EndPoint.WebApi.Models;
using CleanArchitecture.Infra.SqlServer.Library.Data.Constants;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Identity;

public class AccountController : AuthorizationController
{
    private readonly IIdentityService _identityService;

    public AccountController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest parameter)
    {
        await Task.CompletedTask;
        return Ok(parameter);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove()
    {
        await Task.CompletedTask;
        return Ok(true);
    }

    [HttpPut("DisActive")]
    public async Task<IActionResult> DisActive()
    {
        await Task.CompletedTask;
        return Ok(true);
    }

    [HttpGet("Profile")]
    public async Task<IActionResult> Profile()
    {
        await Task.CompletedTask;
        return Ok(true);
    }


    [HttpGet("admin-and-user")]
    [Authorize(Policy = Policies.AdminAccess)] // Multiple policies would require custom handler
    public async Task<IActionResult> AdminAccess()
    {
        await Task.CompletedTask;
        return Ok(true);
    }


    [HttpGet("UserAccess")]
    [Authorize(Policy = Policies.UserAccess)]
    public async Task<IActionResult> UserAccess()
    {
        await Task.CompletedTask;
        return Ok(true);
    }


    [HttpGet("CanUserAccessAdminFeatures")]
    public async Task<bool> CanUserAccessAdminFeatures()
    {
        var result = await _identityService.AuthorizationService.AuthorizeAsync(
            _identityService.HttpContextAccessor.HttpContext.User,
            Policies.AdminAccess);

        return result.Succeeded;
    }

}
