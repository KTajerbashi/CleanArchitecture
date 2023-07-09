using Common.Library;
using Domain.Library.Entities;

namespace Application.Library.Service
{
    public interface IRemoveUserService
    {
        ResultDTO<User> RemoveUser(long userId);
    }
}
