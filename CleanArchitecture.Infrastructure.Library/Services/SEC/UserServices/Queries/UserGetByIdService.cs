using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Models.Views;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Queries;

namespace CleanArchitecture.Infrastructure.Library.Services.SEC.UserServices.Queries
{
    public class UserGetByIdService : IUserGetByIdRepository
    {
        public Task<Result<UserView>> Execute(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
