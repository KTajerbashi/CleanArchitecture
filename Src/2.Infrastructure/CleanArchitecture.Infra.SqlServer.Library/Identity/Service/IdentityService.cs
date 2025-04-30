using CleanArchitecture.Core.Application.Library.Providers;
using CleanArchitecture.Core.Application.Library.UseCases.Security.Role.Repositories;
using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

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
    private readonly IRoleRepository _roleRepository;
    private readonly ProviderServices _providerServices;
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
        IUserRoleRepository userRoleRepository,
        ProviderServices providerServices,
        IRoleRepository roleRepository)
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
        _providerServices = providerServices;
        _roleRepository = roleRepository;
    }

    public UserManager<UserEntity> UserManager => _userManager;
    public SignInManager<UserEntity> SignInManager => _signInManager;
    public RoleManager<RoleEntity> RoleManager => _roleManager;
    public IUserRepository UserRepository => _userRepository;
    public IUserLoginRepository UserLoginRepository => _userLoginRepository;
    public IUserTokenRepository UserTokenRepository => _userTokenRepository;
    public IUserRoleRepository UserRoleRepository => _userRoleRepository;
    public IRoleRepository RoleRepository => _roleRepository;

    public ITokenService TokenService => _tokenService;

    public async Task LoginAsync(UserEntity entity)
    {
        await _signInManager.SignInAsync(entity,true);
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
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

