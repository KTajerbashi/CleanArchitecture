using Application.Library.ModelBase;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;

namespace Application.Library.Repositories.SEC.UserRepositories.Commands
{
    public interface IUpdateUser
    {
        Task<ResultPublicDTO<UserDTO>> Execute(UserDTO user,Guid guid);
    }
}
