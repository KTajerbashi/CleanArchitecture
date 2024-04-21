using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Models.Views;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Queries;

namespace CleanArchitecture.Infrastructure.Library.Services.SEC.UserServices.Queries
{
    public class UserGetAllService : IUserGetAllRepository
    {
        public Task<Result<List<UserView>>> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
