using Application.Library.BaseModel.BaseDTO;

namespace Application.Library.Repositories.SEC.UserRepositories.Commands
{
    public interface IUserDeleteRepository
    {
        Task<Result<bool>> Execute(Guid guid);
    }
}
