using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;

namespace CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Commands
{
    public interface IUserCreateRepository
    {
        Task<Result<UserDTO>> Execute(UserDTO user);
    }
}
