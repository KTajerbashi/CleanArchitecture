using Common.Library;
using Domain.Library.Entities;

namespace Application.Library.Service
{
    public interface IRemoveUserService
    {
        ResultDto<User> RemoveUser(long userId);
    }
}
