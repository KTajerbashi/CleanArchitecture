using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Domain.Security;

namespace CleanArchitecture.Application.Repositories.Security.User.Queries;

public interface IUserQueryRepository : IBaseQueryRepository<UserEntity, long>
{
}
