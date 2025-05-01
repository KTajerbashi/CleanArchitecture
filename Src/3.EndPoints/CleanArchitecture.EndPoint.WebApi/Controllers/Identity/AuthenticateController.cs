using CleanArchitecture.EndPoint.WebApi.Models;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;
using System.IdentityModel.Tokens.Jwt;

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
            var token = await _identityService.LoginAsync(userEntity);
            return Ok(token);
        }
        return BadRequest();
    }

    [HttpGet("LoginAs/{id}")]
    public async Task<IActionResult> LoginAs(long id)
    {
        var userEntity = await _identityService.UserManager.FindByIdAsync($"{id}");
        if (userEntity is null)
        {
            return NotFound();
        }
        var token = await _identityService.LoginAsync(userEntity);
        return Ok(token);
    }

    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        await _identityService.LogoutAsync();
        return Ok();
    }

    [HttpGet("IsAuthenticated")]
    public async Task<IActionResult> IsAuthenticated()
    {
        await Task.CompletedTask;
        return Ok(User?.Identity?.IsAuthenticated);
    }

    [HttpGet("CurrentUser")]
    public IActionResult CurrentUser()
    {
        return Ok(ProviderServices.User);
    }

    [HttpGet("validate-token")]
    public IActionResult ValidateToken([FromHeader(Name = "Authorization")] string authHeader)
    {
        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            return BadRequest("Invalid Authorization header");
        }

        var token = authHeader.Substring("Bearer ".Length).Trim();

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            return Ok(new
            {
                isValid = true,
                claims = jsonToken.Claims.Select(c => new { c.Type, c.Value })
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                isValid = false,
                error = ex.Message
            });
        }
    }
}
