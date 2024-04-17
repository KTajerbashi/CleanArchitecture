
using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Commands;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using CleanArchitecture.Persistence.Library.DataContext;

namespace CleanArchitecture.Infrastructure.Library.Services.SEC.UserServices.Commands
{
    public class UserCreateService : IUserCreateRepository
    {
        public Task<Result<UserDTO>> Execute(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
