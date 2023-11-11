using Application.Library.BaseModel.BaseDTO;

namespace Application.Library.Repositories.SEC.UserRepositories.Commands
{
    public interface IUserDeleteRepository
    {
        Result<bool> Execute(Guid guid);
    }
}
