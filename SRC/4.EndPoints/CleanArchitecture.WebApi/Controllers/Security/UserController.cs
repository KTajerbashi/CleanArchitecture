using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.WebApi.BaseEndPoints;
using CleanArchitecture.WebApi.DIContainer.ContextAccessor;
using CleanArchitecture.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanArchitecture.WebApi.Controllers.Security;

public class UserController : BaseController
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly IUserManagement _userManagement;

    public UserController(
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager,
        IUserManagement userManagement)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _userManagement = userManagement;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var user = new UserEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Gender = model.Gender,
            NationalCode = model.NationalCode,
            AvatarFile = model.AvatarFile,
            UserName = model.UserName,
            SignFile = model.SignFile,
            Email = model.Email,
        };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            // Add additional claims if needed
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            await _userManager.AddClaimsAsync(user, claims);

            await _signInManager.SignInAsync(user, isPersistent: false);
            return await OkResultAsync(result);
        }

        return BadRequest(result.Errors);
    }

    [HttpGet("GetProfile")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(new ProfileModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gender = user.Gender,
            NationalCode = user.NationalCode,
            AvatarFile = user.AvatarFile,
            UserName = user.UserName,
            Email = user.Email,
        });
    }

    [HttpPost("UpdateProfile")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileModel model)
    {
        var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        user.Email = model.Email;
        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors);
    }



    [HttpGet("IsUserAdminAsync")]
    public async Task<bool> IsUserAdminAsync(long userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        return user != null && await _userManager.IsInRoleAsync(user, "Admin");
    }

    [HttpGet("GetUserRoles")]
    public async Task<IEnumerable<string>> GetUserRoles()
    {
        return await Task.FromResult(_userManagement.GetUserRoles());
    }

    [HttpGet("GetUserClaims")]
    public async Task<IEnumerable<Claim>> GetUserClaims()
    {
        return await Task.FromResult(_userManagement.GetUserClaims());
    }

    [HttpGet("GetClaimValue")]
    public async Task<string> GetClaimValue(string claimType)
    {
        return await Task.FromResult(_userManagement.GetClaimValue(claimType));
    }

}
