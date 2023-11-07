using Application.Library.ModelBase;

namespace Application.Library.Repositories.SEC.UserRepositories.Commands
{
    public interface IChangeActivateUser
    {
        Task<ResultPublicDTO<bool>> Execute(Guid guid);
    }
}
