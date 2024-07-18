using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Domain.Security;

namespace CleanArchitecture.Application.Repositories.Security.User.Command;

public interface IUserCommandRepository : IBaseCommandRepository<UserEntity, long>
{
}
