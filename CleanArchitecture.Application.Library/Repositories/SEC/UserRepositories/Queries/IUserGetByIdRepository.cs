using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Models.Views;

namespace CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Queries
{
    public interface IUserGetByIdRepository
    {
        Task<Result<UserView>> Execute(Guid guid);
    }
}
