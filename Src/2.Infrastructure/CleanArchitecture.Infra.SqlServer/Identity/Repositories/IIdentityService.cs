using CleanArchitecture.Core.Application.UseCases.Security.Role.Repositories;
using CleanArchitecture.Core.Application.UseCases.Security.User.Repositories;
using CleanArchitecture.Infra.SqlServer.Identity.Entities;
using CleanArchitecture.Infra.SqlServer.Identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Infra.SqlServer.Identity.Repositories;

public interface IIdentityService
{
    public UserManager<UserEntity> UserManager { get; }
    public RoleManager<RoleEntity> RoleManager { get; }
    public SignInManager<UserEntity> SignInManager { get; }

    public IAuthorizationService AuthorizationService { get; }
    public IHttpContextAccessor HttpContextAccessor { get; }

    public IUserRepository UserRepository { get; }
    public IUserLoginRepository UserLoginRepository { get; }
    public IUserTokenRepository UserTokenRepository { get; }
    public IUserRoleRepository UserRoleRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public ITokenService TokenService { get; }

    Task<AuthResponse> LoginAsync(UserEntity entity);
    Task LogoutAsync();
}
