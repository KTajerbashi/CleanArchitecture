using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.WebApi.BaseEndPoints;
using CleanArchitecture.WebApi.Controllers.Account.Models;
using CleanArchitecture.WebApi.UserManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Account;
public class AccountController : BaseController
{
    private readonly IIdentityService _identityService;
    public AccountController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return await OkResultAsync(ModelState);
        }
        var entity = new UserEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserName = model.Email,
            AvatarFile = model.AvatarFile,
            SignFile = model.SignFile,
            NationalCode = model.NationalCode,
            Key = Guid.NewGuid()
        };

        var result = await _identityService.UserManager.CreateAsync(entity,model.Password);
        return await OkResultAsync(result);
    }

    [HttpGet("GetProfile")]
    public Task<IActionResult> GetProfile()
    {
        return OkResultAsync(User);
    }

    [HttpGet("IsAuthenticated")]
    public Task<IActionResult> IsAuthenticated() => OkResultAsync(User.Identity.IsAuthenticated);

    [HttpPost("DisActive")]
    public Task<IActionResult> DisActive() => OkResultAsync("DisActive");

    [HttpGet("AccessDenied")]
    public Task<IActionResult> AccessDenied() => OkResultAsync("AccessDenied");

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return await OkResultAsync(model);
        }
        var entity = await _identityService.UserManager.FindByNameAsync(model.UserName) ?? default;
        if (entity is null)
        {
            return await OkResultAsync("کاربر یافت نشده است");
        }
        _identityService.SignInManager.SignOutAsync();
        var result = await _identityService.SignInManager.PasswordSignInAsync(entity, model.Password,model.IsRemember,true);
        if (result.Succeeded)
        {
            return await OkResultAsync(new UserModel
            {
                //Claims = User.Claims.ToList(),
                //Identities = User.Identities.ToList(),
                Identity = User.Identity
            });
            if (result.RequiresTwoFactor)
            {
                return await OkResultAsync(result);
            }
            if (result.IsLockedOut)
            {
                return await OkResultAsync(result);
            }
        }
        return await OkResultAsync(result);
    }

    [HttpGet("SignOut")]
    public Task<IActionResult> SignOut()
    {
        return OkResultAsync(_identityService.SignInManager.SignOutAsync());
    }
}
