using CleanArchitecture.Core.Application.Library.UseCases.Security.Role.Repositories;
using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;
using System.Security.Claims;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;

public interface IIdentityService
{
    public UserManager<UserEntity> UserManager { get; }
    public RoleManager<RoleEntity> RoleManager { get; }
    public SignInManager<UserEntity> SignInManager { get; }


    public IUserRepository UserRepository { get; }
    public IUserLoginRepository UserLoginRepository { get; }
    public IUserTokenRepository UserTokenRepository { get; }
    public IUserRoleRepository UserRoleRepository { get; }
    public IRoleRepository RoleRepository { get; }


    public string GeneratePersonalCode { get; }

    // Add these new methods
    Task<string> GenerateJwtTokenAsync(UserEntity user);
    Task<string> GenerateJwtTokenAsync(UserEntity user, IEnumerable<Claim> claims = null);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
