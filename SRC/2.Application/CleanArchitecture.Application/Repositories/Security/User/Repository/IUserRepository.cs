using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Domain.Security;

namespace CleanArchitecture.Application.Repositories.Security.User.Repository;

public interface IUserRepository : IBaseRepository<UserEntity, long>
{
}
