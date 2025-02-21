using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Polymorphism;

public class AppSignInManager<TUser> : SignInManager<TUser> where TUser : UserEntity
{
    private readonly UserManager<TUser> _userManager;
    public AppSignInManager(
        UserManager<TUser> userManager, 
        IHttpContextAccessor contextAccessor, 
        IUserClaimsPrincipalFactory<TUser> claimsFactory, 
        IOptions<IdentityOptions> optionsAccessor, 
        ILogger<SignInManager<TUser>> logger, 
        IAuthenticationSchemeProvider schemes, 
        IUserConfirmation<TUser> confirmation) 
        : base(
            userManager, 
            contextAccessor, 
            claimsFactory, 
            optionsAccessor, 
            logger, 
            schemes, 
            confirmation)
    {
        _userManager = userManager;
    }
    public override Task SignInAsync(TUser user, AuthenticationProperties authenticationProperties, string? authenticationMethod = null)
    {
        return base.SignInAsync(user, authenticationProperties, authenticationMethod);
    }

    public override Task<SignInResult> PasswordSignInAsync(TUser user, string password, bool isPersistent, bool lockoutOnFailure)
    {
        return base.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
    }
    public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
    {
        return base.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
    }
}
