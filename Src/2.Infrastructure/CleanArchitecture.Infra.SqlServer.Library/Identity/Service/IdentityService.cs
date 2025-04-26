using CleanArchitecture.Core.Application.Library.Providers;
using CleanArchitecture.Core.Application.Library.Providers.Scrutor;
using CleanArchitecture.Core.Application.Library.UseCases.Security.Role.Repositories;
using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Service;
public interface ITokenService : IScopeLifeTime
{
    Task<string> GenerateAccessTokenAsync(UserEntity user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}

public class IdentityService : IIdentityService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly RoleManager<RoleEntity> _roleManager;
    private readonly IUserClaimsPrincipalFactory<UserEntity> _userClaimsPrincipalFactory;
    private readonly ITokenService _tokenService;
    private readonly ILogger<IdentityService> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IUserLoginRepository _userLoginRepository;
    private readonly IUserTokenRepository _userTokenRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public IdentityService(
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager,
        RoleManager<RoleEntity> roleManager,
        IUserClaimsPrincipalFactory<UserEntity> userClaimsPrincipalFactory,
        ITokenService tokenService,
        ILogger<IdentityService> logger,
        IUserRepository userRepository,
        IUserLoginRepository userLoginRepository,
        IUserTokenRepository userTokenRepository,
        IUserRoleRepository userRoleRepository)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _tokenService = tokenService;
        _logger = logger;
        _userRepository = userRepository;
        _userLoginRepository = userLoginRepository;
        _userTokenRepository = userTokenRepository;
        _userRoleRepository = userRoleRepository;
    }

    public UserManager<UserEntity> UserManager => _userManager;
    public SignInManager<UserEntity> SignInManager => _signInManager;
    public RoleManager<RoleEntity> RoleManager => _roleManager;
    public IUserRepository UserRepository => _userRepository;
    public IUserLoginRepository UserLoginRepository => _userLoginRepository;
    public IUserTokenRepository UserTokenRepository => _userTokenRepository;
    public IUserRoleRepository UserRoleRepository => _userRoleRepository;

    public IRoleRepository RoleRepository => throw new NotImplementedException();

    public string GeneratePersonalCode => GenerateSecureRandomCode();
    public async Task<string> GenerateJwtTokenAsync(UserEntity user)
    {
        try
        {
            return await _tokenService.GenerateAccessTokenAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating JWT token for user {UserId}", user?.Id);
            throw;
        }
    }

    public async Task<string> GenerateJwtTokenAsync(UserEntity user, IEnumerable<Claim> claims)
    {
        try
        {
            //await ClearExistingClaimsAsync(user);
            //await _userManager.AddClaimsAsync(user, claims);
            return await _tokenService.GenerateAccessTokenAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating JWT token with custom claims for user {UserId}", user?.Id);
            throw;
        }
    }

    public string GenerateRefreshToken() => _tokenService.GenerateRefreshToken();

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        try
        {
            return _tokenService.GetPrincipalFromExpiredToken(token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating expired token");
            throw;
        }
    }

    private async Task ClearExistingClaimsAsync(UserEntity user)
    {
        var claims = await _userManager.GetClaimsAsync(user);
        if (claims.Any())
        {
            await _userManager.RemoveClaimsAsync(user, claims);
        }
    }

    private string GenerateSecureRandomCode()
    {
        using var rng = RandomNumberGenerator.Create();
        var bytes = new byte[4];
        rng.GetBytes(bytes);
        return (BitConverter.ToUInt32(bytes, 0) % 900000 + 100000).ToString();
    }
}

public class JwtTokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<UserEntity> _userManager;
    private readonly RoleManager<RoleEntity> _roleManager;
    private readonly ILogger<JwtTokenService> _logger;

    public JwtTokenService(
        IConfiguration configuration,
        UserManager<UserEntity> userManager,
        RoleManager<RoleEntity> roleManager,
        ILogger<JwtTokenService> logger)
    {
        _configuration = configuration;
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
    }

    public async Task<string> GenerateAccessTokenAsync(UserEntity user)
    {
        var claims = await BuildUserClaimsAsync(user);
        return GenerateToken(claims);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"])),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
    }

    private async Task<List<Claim>> BuildUserClaimsAsync(UserEntity user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new("IsActive", user.IsActive.ToString(), ClaimValueTypes.Boolean),
            new("AspNet.Identity.SecurityStamp", user.SecurityStamp)
        };

        await AddAdditionalClaimsAsync(user, claims);
        return claims.DistinctBy(c => new { c.Type, c.Value }).ToList();
    }

    private async Task AddAdditionalClaimsAsync(UserEntity user, List<Claim> claims)
    {
        // Add phone claims if available
        if (!string.IsNullOrEmpty(user.PhoneNumber))
        {
            claims.Add(new(ClaimTypes.MobilePhone, user.PhoneNumber));
            claims.Add(new("PhoneNumberVerified", user.PhoneNumberConfirmed.ToString(), ClaimValueTypes.Boolean));
        }

        // Add user-specific claims
        var userClaims = await _userManager.GetClaimsAsync(user);
        claims.AddRange(userClaims);

        // Add role claims
        var roles = await _userManager.GetRolesAsync(user);
        foreach (var roleName in roles)
        {
            claims.Add(new(ClaimTypes.Role, roleName));
            await AddRoleClaimsAsync(roleName, claims);
        }
    }

    private async Task AddRoleClaimsAsync(string roleName, List<Claim> claims)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role != null)
        {
            claims.Add(new("Role", role.Name));
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            claims.AddRange(roleClaims);
        }
    }

    private string GenerateToken(IEnumerable<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class IdentityProfile : Profile
{
    public IdentityProfile()
    {
        CreateMap<AppUserEntity, UserCreateParameters>()
            .ReverseMap()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));
    }
}

