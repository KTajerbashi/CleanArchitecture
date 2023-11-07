using Application.Library.ModelBase;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;

namespace Application.Library.Repositories.SEC.UserRepositories.Queries
{
    public interface IGetById
    {
        Task<ResultPublicDTO<UserDTO>> Execute(object ID);
    }
}
