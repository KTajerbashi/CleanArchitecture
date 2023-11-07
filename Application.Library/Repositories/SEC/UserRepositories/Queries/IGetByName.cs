using Application.Library.ModelBase;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;

namespace Application.Library.Repositories.SEC.UserRepositories.Queries
{
    public interface IGetByName
    {
        Task<ResultPublicDTO<UserDTO>> Execute(string name);
    }
}
