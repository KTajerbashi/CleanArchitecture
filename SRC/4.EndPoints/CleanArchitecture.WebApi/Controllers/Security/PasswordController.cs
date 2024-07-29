using CleanArchitecture.WebApi.BaseEndPoints;
using CleanArchitecture.WebApi.Models;
using CleanArchitecture.WebApi.UserManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanArchitecture.WebApi.Controllers.Security;

public class PasswordController : BaseController
{
    private readonly IIdentityService _identityService;

    public PasswordController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("reset")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
    {
        var user = await _identityService.UserManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return NotFound();
        }

        var token = await _identityService.UserManager.GeneratePasswordResetTokenAsync(user);
        var result = await _identityService.UserManager.ResetPasswordAsync(user, token, model.NewPassword);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("change")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
    {
        var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var user = await _identityService.UserManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        var result = await _identityService.UserManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors);
    }
}
