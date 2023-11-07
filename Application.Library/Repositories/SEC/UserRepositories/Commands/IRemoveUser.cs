using Application.Library.ModelBase;

namespace Application.Library.Repositories.SEC.UserRepositories.Commands
{
    public interface IRemoveUser
    {
        Task<ResultPublicDTO<bool>> Execute(Guid guid);
    }
}
