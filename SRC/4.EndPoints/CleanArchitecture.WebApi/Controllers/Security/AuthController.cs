using CleanArchitecture.WebApi.BaseEndPoints;
using CleanArchitecture.WebApi.Models;
using CleanArchitecture.WebApi.UserManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.WebApi.Controllers.Security;

public class AuthController : BaseController
{
    private readonly IIdentityService _identityService;
    private readonly IConfiguration _configuration;

    public AuthController(IIdentityService identityService, IConfiguration configuration)
    {
        _configuration = configuration;
        _identityService = identityService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _identityService.UserManager.FindByNameAsync(model.Username);
            if (user != null && await _identityService.UserManager.CheckPasswordAsync(user, model.Password))
            {
                await _identityService.UserManager.UpdateSecurityStampAsync(user);
                await _identityService.SignInManager.SignInAsync(user, isPersistent: model.IsRemember);
                //var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.IsRemember, lockoutOnFailure: true);
                var result = new{Succeeded=true };
                if (result.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName)
                    }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { Token = tokenString });
                }
            }
            return Unauthorized();
        }
        return BadRequest();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _identityService.SignInManager.SignOutAsync();
        return Ok();
    }

    [HttpPost("IsCurrentUserAuthenticated")]
    public async Task<bool> IsCurrentUserAuthenticated()
    {
        return await Task.FromResult(User.Identity.IsAuthenticated);
    }

}
