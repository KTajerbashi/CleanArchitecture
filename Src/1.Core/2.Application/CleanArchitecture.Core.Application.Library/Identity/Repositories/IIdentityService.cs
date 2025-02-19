using CleanArchitecture.Core.Application.Library.Identity.Models.DTOS;

namespace CleanArchitecture.Core.Application.Library.Identity.Repositories;

public interface IIdentityService
{
    Task<Result> LoginAsUsername(string username, string password);

    Task<Result> LoginAsEmail(string email, string password);

    Task<Result> LoginAs(string username);

    Task<Result> LoginAs(long id);

    Task<Result> Register(RegisterDTO parameter);

    Task<string?> GetUserNameAsync(long userId);

    Task<bool> IsInRoleAsync(long userId, string role);

    Task<bool> AuthorizeAsync(long userId, string policyName);

    Task<(Result Result, long UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(long userId);
}
