using CleanArchitecture.Application.Repositories.Identity;
using CleanArchitecture.Application.Repositories.Identity.Models.DTOs;
using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Account;

public class AccountController : BaseController
{
    private readonly IIdentityService _identityService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(IIdentityService identityService, ILogger<AccountController> logger)
    {
        _identityService = identityService;
        _logger = logger;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDTO model)
    {
        return await OkResultAsync(await _identityService.LoginAccount(model));
    }

    [HttpGet("SignOut")]
    public async Task<IActionResult> SignOut()
    {
        return await OkResultAsync(_identityService.SignOut());
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDTO model)
    {
        return await OkResultAsync(await _identityService.Register(model));
    }

    [HttpGet("ReadProfile")]
    [Authorize]
    public async Task<IActionResult> ReadProfile(long Id)
    {
        return await OkResultAsync(await _identityService.ReadProfile(Id));
    }

    [HttpGet("IsAuthenticated")]
    public async Task<IActionResult> IsAuthenticated()
    {
        return await OkResultAsync(User.Identity.IsAuthenticated);
    }

    [HttpGet("GetClaims")]
    public async Task<IActionResult> GetClaims()
    {
        return await OkResultAsync(User.Claims.ToList());
    }

    [HttpGet("GetRoles")]
    public async Task<IActionResult> GetRoles(long Id)
    {
        return await OkResultAsync(_identityService.GetUserRoles(Id));
    }

    [HttpGet("AccessAdmin")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> AccessAdmin()
    {
        return OkResultAsync("AccessAdmin");
    }

    [HttpGet("AccessUser")]
    [Authorize(Roles = "User")]
    public Task<IActionResult> AccessUser()
    {
        return OkResultAsync("AccessUser");
    }

    [HttpGet("AccessAuthorize")]
    [Authorize(Roles = "User,Admin")]
    public Task<IActionResult> AccessAuthorize()
    {
        return OkResultAsync("AccessAuthorize");
    }
}
