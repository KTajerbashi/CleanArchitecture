using CleanArchitecture.Application.BaseApplication.UserManagement;
using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;
using CleanArchitecture.WebApi.BaseEndPoints;
using CleanArchitecture.WebApi.Controllers.Account.Models;
using CleanArchitecture.WebApi.Extensions.Identity.Options;
using CleanArchitecture.WebApi.Extensions.Identity.Services;
using CleanArchitecture.WebApi.UserManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Account;

public class AccountJWTController : BaseController
{
    private readonly IIdentityService _identityService;
    private readonly IUserWebInfoRepositories _userInfoService;
    private readonly IConfiguration _config;
    public AccountJWTController(
        IIdentityService identityService,
        IUserWebInfoRepositories userInfoService,
        IConfiguration config)
    {
        _identityService = identityService;
        _userInfoService = userInfoService;
        _config = config;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginModel loginModel)
    {
        // Authenticate user
        var result = _userInfoService.AuthenticateAsync(new AuthenticateRequest
        {
            IsRemember=loginModel.IsRemember,
            Password=loginModel.Password,
            Username=loginModel.UserName,
        }).Result;

        if (result == null)
            return Unauthorized();
        var UserModel = new UserDTO
        {
            Id=result.Id,
            FirstName=result.FirstName,
            LastName=result.LastName,
            UserName=result.Username,
            Token=result.Token
        };
        // Generate tokens
        var accessToken = TokenUtils.GenerateAccessToken(UserModel, _config["Jwt:Secret"]);
        var refreshToken = TokenUtils.GenerateRefreshToken();

        // Save refresh token (for demo purposes, this might be stored securely in a database)
        // _userService.SaveRefreshToken(user.Id, refreshToken);

        var response = new TokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return OkResultAsync(response).Result;
    }

    [HttpPost("refresh")]
    public IActionResult Refresh(TokenResponse tokenResponse)
    {
        // For simplicity, assume the refresh token is valid and stored securely
        // var storedRefreshToken = _userService.GetRefreshToken(userId);

        // Verify refresh token (validate against the stored token)
        // if (storedRefreshToken != tokenResponse.RefreshToken)
        //    return Unauthorized();

        // For demonstration, let's just generate a new access token
        var newAccessToken = TokenUtils.GenerateAccessTokenFromRefreshToken(tokenResponse.RefreshToken, _config["Jwt:Secret"]);

        var response = new TokenResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = tokenResponse.RefreshToken // Return the same refresh token
        };

        return Ok(response);
    }

    [HttpPost("IsAuthenticated")]
    [Authorize]
    public IActionResult IsAuthenticated()
    {
        return Ok(User.Identity.IsAuthenticated);
    }


    [HttpGet("Authorized")]
    //[Authorize]
    public IActionResult Authorized()
    {
        return Ok(User.Identity.IsAuthenticated);
    }
}
