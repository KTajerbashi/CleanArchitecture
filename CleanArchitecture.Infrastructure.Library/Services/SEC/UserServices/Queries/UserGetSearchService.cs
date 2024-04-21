using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Models.Views;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Queries;

namespace CleanArchitecture.Infrastructure.Library.Services.SEC.UserServices.Queries
{
    public class UserGetSearchService : IUserGetSearchRepository
    {
        public Task<Result<List<UserView>>> Execute(string search)
        {
            throw new NotImplementedException();
        }
    }
}
