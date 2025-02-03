using CleanArchitecture.Core.Application.Library.Identity.Models.DTOS;

namespace CleanArchitecture.Core.Application.Library.Identity.Repositories;

public interface IIdentityService
{
    Task<long> LoginAsUsername(string username, string password);
    Task<long> LoginAsEmail(string email, string password);
    Task<long> LoginAs(string username);
    Task<long> LoginAs(long id);
    Task<long> Register(RegisterDTO parameter);
}
