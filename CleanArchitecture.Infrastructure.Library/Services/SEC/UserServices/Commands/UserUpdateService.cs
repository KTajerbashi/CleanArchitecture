using AutoMapper;
using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Commands;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;

namespace CleanArchitecture.Infrastructure.Library.Services.SEC.UserServices.Commands
{
    public class UserUpdateService : IUserUpdateRepository
    {
        public Task<Result<UserDTO>> Execute(UserDTO user, Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
