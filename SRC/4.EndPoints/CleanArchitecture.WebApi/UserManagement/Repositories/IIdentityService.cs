using CleanArchitecture.Domain.Security.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.WebApi.UserManagement.Repositories;

public interface IIdentityService
{
    UserManager<UserEntity> UserManager { get; }
    RoleManager<RoleEntity> RoleManager { get; }
    SignInManager<UserEntity> SignInManager { get; }

}


