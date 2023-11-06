using Application.Library.ModelBase;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;

namespace Application.Library.Repositories.SEC.UserRepositories.Commands
{
    public interface ICreateUser
    {
        ResultPublicDTO<long> Execute(UserDTO user);
    }
}
