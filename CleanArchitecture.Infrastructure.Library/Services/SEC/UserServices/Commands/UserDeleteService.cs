using AutoMapper;
using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Commands;

namespace CleanArchitecture.Infrastructure.Library.Services.SEC.UserServices.Commands
{
    public class UserDeleteService : IUserDeleteRepository
    {
        public Task<Result<bool>> Execute(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
