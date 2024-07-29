using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.WebApi.UserManagement.Repositories;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.WebApi.UserManagement.Services;

public class IdentityService : IIdentityService
{
    public IdentityService(
        UserManager<UserEntity> userManager, 
        RoleManager<RoleEntity> roleManager, 
        SignInManager<UserEntity> signInManager
        )
    {
        UserManager = userManager;
        RoleManager = roleManager;
        SignInManager = signInManager;
    }
    public UserManager<UserEntity> UserManager { get; }

    public RoleManager<RoleEntity> RoleManager { get; }

    public SignInManager<UserEntity> SignInManager { get; }
}
