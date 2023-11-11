using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.SEC.UserRepositories.Models.Views;

namespace Application.Library.Repositories.SEC.UserRepositories.Queries
{
    public interface IUserGetAllRepository
    {
        Result<List<UserView>> Execute();
    }
}
