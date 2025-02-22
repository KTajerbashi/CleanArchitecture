using CleanArchitecture.Core.Application.Library.Identity.Models.DTOS;
using CleanArchitecture.Core.Application.Library.Identity.Repositories;
using CleanArchitecture.Core.Application.Library.Providers;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Extensions;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Service;

public class IdentityService : IIdentityService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly IUserClaimsPrincipalFactory<UserEntity> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;
    private readonly ProviderServices _providers;
    public IdentityService(
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager,
        IUserClaimsPrincipalFactory<UserEntity> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService
,
        ProviderServices providers)
    {
        _userManager = userManager;
        _authorizationService = authorizationService;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _signInManager = signInManager;
        _providers = providers;
    }

    public async Task<string?> GetUserNameAsync(long userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        return user?.UserName;
    }

    public async Task<(Result Result, long UserId)> CreateUserAsync(string userName, string password)
    {

        var user = new UserEntity(new UserCreateParameters(
            userName,
            userName,
            $"{userName}@mail.com",
            "NOT DEFINED",
            "NOT DEFINED",
            "NOT DEFINED",
            "NOT DEFINED",
            "NOT DEFINED"
            ));

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }


    public async Task<bool> IsInRoleAsync(long userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(long userId, string policyName)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(long userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(UserEntity user) => (await _userManager.DeleteAsync(user)).ToApplicationResult();

    public async Task<Result> LoginAsUsername(string username, string password)
        => (await _signInManager.PasswordSignInAsync(username, password, true, true)).ToApplicationResult();

    public async Task<Result> LoginAsEmail(string email, string password)
        => (await _signInManager.PasswordSignInAsync(email, password, true, true)).ToApplicationResult();

    public async Task<Result> LoginAs(string username)
    {
        UserEntity entity = await _userManager.FindByNameAsync(username);
        if (entity != null)
        {
            await _signInManager.SignInAsync(entity, true);
            return Result.Success();
        }
        return Result.Failure(["Username Not Founded !!!"]);
    }

    public async Task<Result> LoginAs(long id)
    {
        UserEntity entity = await _userManager.FindByIdAsync(id.ToString());
        if (entity != null)
        {
            await _signInManager.SignInAsync(entity, true);
            return Result.Success();
        }
        return Result.Failure(["User Not Founded !!!"]);
    }

    public async Task<Result> Register(RegisterDTO parameter)
    {
        UserCreateParameters createParams = _providers.Mapper.Map<RegisterDTO,UserCreateParameters>(parameter);
        var user = new UserEntity(createParams);
        var result = await _userManager.CreateAsync(user, parameter.Password);
        return result.ToApplicationResult();
    }
}
