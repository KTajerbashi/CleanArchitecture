using CleanArchitecture.Infra.SqlServer.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace CleanArchitecture.Infra.SqlServer.Identity.Polymorphism;

public class AppUserClaimsFactory : UserClaimsPrincipalFactory<UserEntity, RoleEntity>
{
    public AppUserClaimsFactory(
        UserManager<UserEntity> userManager, 
        RoleManager<RoleEntity> roleManager, 
        IOptions<IdentityOptions> options) 
        : base(userManager, roleManager, options)
    {
    }

    protected override Task<ClaimsIdentity> GenerateClaimsAsync(UserEntity user)
    {
        return base.GenerateClaimsAsync(user);
    }
}