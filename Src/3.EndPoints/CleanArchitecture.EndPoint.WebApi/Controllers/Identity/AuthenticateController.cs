using CleanArchitecture.EndPoint.WebApi.Models;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Identity;

public class AuthenticateController : BaseController
{
    private readonly IIdentityService _identityService;
    private readonly ILogger<AuthenticateController> _logger;
    public AuthenticateController(IIdentityService identityService, ILogger<AuthenticateController> logger)
    {
        _identityService = identityService;
        _logger = logger;
        _logger.Log(LogLevel.Information, "AuthenticateController => Started ...");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest parameter)
    {
        var userEntity = await _identityService.UserManager.FindByEmailAsync(parameter.Username) ?? await _identityService.UserManager.FindByNameAsync(parameter.Username);

        if (userEntity is null)
        {
            return NotFound();
        }

        var loginResult = await _identityService.SignInManager.PasswordSignInAsync(userEntity,parameter.Password,parameter.IsRemember,true);

        if (loginResult.Succeeded)
        {
            return Ok(loginResult);
        }
        return BadRequest();
    }

    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        await _identityService.SignInManager.SignOutAsync();
        return Ok();
    }

    [HttpGet("IsAuthenticated")]
    public async Task<IActionResult> IsAuthenticated()
    {
        await Task.CompletedTask;
        return Ok(User?.Identity?.IsAuthenticated);
    }
}
