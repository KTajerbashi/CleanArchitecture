using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Domain.Security;

namespace CleanArchitecture.Application.Repositories.Security.Repository;

public interface ICommandUserRepository : IBaseCommandRepository<UserEntity, long>
{
}
