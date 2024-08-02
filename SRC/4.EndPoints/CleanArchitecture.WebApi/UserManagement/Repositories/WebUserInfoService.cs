using CleanArchitecture.Application.BaseApplication.UserManagement;
using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;
using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.WebApi.Extensions.Settings;
using CleanArchitecture.WebApi.UserManagement.DependencyInjection;
using CleanArchitecture.WebApi.UserManagement.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.WebApi.UserManagement.Repositories;

public class WebUserInfoService : IUserWebInfoRepositories
{
    private readonly IIdentityService _identityService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManagementOptions _options;
    private readonly IConfiguration _configuration;
    public WebUserInfoService(
        IIdentityService identityService,
        IHttpContextAccessor httpContextAccessor,
        UserManagementOptions options
,
        IConfiguration configuration)
    {
        _identityService = identityService;
        _httpContextAccessor = httpContextAccessor;
        _options = options;
        _configuration = configuration;
    }



    public string GetUserAgent()
    => _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"] ?? _options.DefaultUserAgent;

    public string GetUserIp()
    => _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? _options.DefaultUserIp;

    public string UserId()
    => _httpContextAccessor?.HttpContext?.User?.GetClaim(ClaimTypes.NameIdentifier) ?? string.Empty;

    public string GetUsername()
    => _httpContextAccessor.HttpContext?.User?.GetClaim(ClaimTypes.Name) ?? _options.DefaultUsername;

    public string GetFirstName()
    => _httpContextAccessor.HttpContext?.User?.GetClaim(ClaimTypes.GivenName) ?? _options.DefaultFirstName;

    public string GetLastName()
    => _httpContextAccessor.HttpContext?.User?.GetClaim(ClaimTypes.Surname) ?? _options.DefaultLastName;

    public bool IsCurrentUser(string userId)
    {
        return string.Equals(UserId().ToString(), userId, StringComparison.OrdinalIgnoreCase);
    }

    public string? GetClaim(string claimType)
    => _httpContextAccessor.HttpContext?.User?.GetClaim(claimType);

    public string UserIdOrDefault() => UserIdOrDefault(_options.DefaultUserId);

    public string UserIdOrDefault(string defaultValue)
    {
        string userId = UserId();
        return string.IsNullOrEmpty(userId) ? defaultValue : userId;
    }

    private async Task<string> generateJwtToken(UserEntity user)
    {
        //Generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = await Task.Run(() =>
        {
            var appSetting = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(appSetting["Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.CreateToken(tokenDescriptor);
        });

        return tokenHandler.WriteToken(token);
    }

    public string GetToken()
    {
        return "SMDPOSDKSDKLSKLDKSLD";
    }

    public async Task<AuthenticateResponse?> AuthenticateAsync(AuthenticateRequest model)
    {
        var userEntity = await _identityService.UserManager.FindByNameAsync(model.Username);
        // return null if user not found
        if (userEntity == null) return null;

        var result = _identityService.SignInManager.PasswordSignInAsync(userEntity,model.Password,model.IsRemember,true);
        // authentication successful so generate jwt token
        var token = await generateJwtToken(userEntity);

        return new AuthenticateResponse(new UserDTO
        {
            Id = userEntity.Id,
            FirstName = userEntity.FirstName,
            LastName = userEntity.LastName,
            UserName = userEntity.UserName,
        }, token);
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        return AuthenticateAsync(model).Result;
    }

}


