using CleanArchitecture.Application.Library.BaseModel.BaseDTO;

namespace CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Commands
{
    public interface IUserDeleteRepository
    {
        Task<Result<bool>> Execute(Guid guid);
    }
}
