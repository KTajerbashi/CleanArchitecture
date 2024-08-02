using CleanArchitecture.Application.Repositories.Identity.Models.DTOs;
using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;
using static CleanArchitecture.Application.Repositories.Identity.Models.Responses.ServiceResponse;

namespace CleanArchitecture.Application.Repositories.Identity;

public interface IIdentityService
{
    Task<GeneralResponse> Register(RegisterDTO model);
    Task<LoginResponse> LoginAccount(LoginDTO model);



    Task<GeneralResponse> PasswordSignInAsync(UserDTO entity, string password, bool isRemember, bool failLockOutEnd);
    Task<GeneralResponse> ReadProfile(long userRoleId);
    Task<GeneralResponse> FindUserById(long userId);
    Task<GeneralResponse> FindUserByUsername(string userName);
    Task<GeneralResponse> FindUserByEmail(string email);
    List<RoleDTO> GetUserRoles(long id);
    Task SignOut();
}
