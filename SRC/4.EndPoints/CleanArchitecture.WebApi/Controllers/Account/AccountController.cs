﻿using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.WebApi.Attributes;
using CleanArchitecture.WebApi.BaseEndPoints;
using CleanArchitecture.WebApi.Controllers.Account.Models;
using CleanArchitecture.WebApi.UserManagement.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanArchitecture.WebApi.Controllers.Account;

public class AccountController : BaseController
{
    private readonly IIdentityService _identityService;
    private readonly IUserInfoService _userInfoService;
    public AccountController(IIdentityService identityService, IUserInfoService userInfoService)
    {
        _identityService = identityService;
        _userInfoService = userInfoService;
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
    [Authorize]
    public Task<IActionResult> GetProfile()
    {
        return OkResultAsync(User);
    }

    [HttpGet("GetProfileFree")]
    public Task<IActionResult> GetProfileFree()
    {
        var model = new
        {
            Token = _userInfoService.GetToken(),
            UserAgent = _userInfoService.GetUserAgent(),
            UserIp = _userInfoService.GetUserIp(),
            UserId = _userInfoService.UserId(),
            FirstName = _userInfoService.GetFirstName(),
            LastName = _userInfoService.GetLastName(),
            UserName = _userInfoService.GetUsername(),
            Claim = _userInfoService.GetClaim(""),
            IsCurrentUser = _userInfoService.IsCurrentUser("1"),
            UserIdOrDefault = _userInfoService.UserIdOrDefault(),
            UserIdOrDefault1 = _userInfoService.UserIdOrDefault("1"),
        };
        return OkResultAsync(model);
    }

    /// <summary>
    /// Check is Current User Authenticate
    /// </summary>
    /// <returns>true or false</returns>
    [HttpGet("IsAuthenticated")]
    public Task<IActionResult> IsAuthenticated() => OkResultAsync(User.Identity.IsAuthenticated);

    [HttpPost("DisActive")]
    public Task<IActionResult> DisActive() => OkResultAsync("DisActive");

    [HttpGet("AccessDenied")]
    public Task<IActionResult> AccessDenied() => OkResultAsync("AccessDenied");



    /// <summary>
    /// Login User.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST api/Account/Login
    ///     {
    ///       "userName": "User",
    ///       "password": "User@123",
    ///       "returnUrl": "/",
    ///       "isRemember": true
    ///     }
    /// </remarks>
    /// <param name="model"></param>   
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>    
    [HttpPost("Login")]
    [Produces("application/json")]
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


    [HttpPost("LoginAsync")]
    public async Task<IActionResult> LoginAsync(LoginModel model)
    {
        var result = await _identityService.SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.IsRemember, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var user = await _identityService.UserManager.FindByNameAsync(model.UserName);
            var roles = await _identityService.UserManager.GetRolesAsync(user);

            var claims = new List<Claim>{new Claim(ClaimTypes.Name, user.UserName)};

            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            //await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));

            return await OkResultAsync(result);
        }
        return Unauthorized();
    }

}