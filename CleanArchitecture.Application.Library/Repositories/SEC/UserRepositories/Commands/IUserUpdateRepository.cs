using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;

namespace CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Commands
{
    public interface IUserUpdateRepository
    {
        Task<Result<UserDTO>> Execute(UserDTO user, Guid guid);
    }
}
