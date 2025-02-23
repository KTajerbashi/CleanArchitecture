using CleanArchitecture.Core.Application.Library.Identity.Models.DTOS;
using CleanArchitecture.Core.Domain.Library.Entities.Security;

namespace CleanArchitecture.Core.Application.Library.Identity.Repositories;

public interface IIdentityService
{
    Task<Result> LoginAsUsernameAsync(string username, string password);

    Task<Result> LoginAsEmailAsync(string email, string password);

    Task<Result> LoginAsAsync(string username);

    Task<Result> LoginAsAsync(long id);

    Task<Result> RegisterAsync(AppUserEntity parameter, string password);

    Task<string?> GetUserNameAsync(long userId);

    Task<bool> IsInRoleAsync(long userId, string role);

    Task<bool> AuthorizeAsync(long userId, string policyName);

    Task<(Result Result, long UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(long userId);
}
