using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.SEC.UserRepositories.Models.Views;

namespace Application.Library.Repositories.SEC.UserRepositories.Queries
{
    public interface IUserGetByIdRepository
    {
        Result<UserView> Execute(Guid guid);
    }
}
