using CleanArchitecture.Core.Application.Library.Providers;
using CleanArchitecture.Core.Application.Library.UseCases.Security.Role.Repositories;
using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Service;

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

public class IdentityProfile : Profile
{
    public IdentityProfile()
    {
        CreateMap<AppUserEntity, UserCreateParameters>()
            .ReverseMap()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(_ => DateTime.Now));
    }
}

