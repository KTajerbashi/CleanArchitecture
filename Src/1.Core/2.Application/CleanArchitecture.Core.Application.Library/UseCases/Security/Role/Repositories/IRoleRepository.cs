using CleanArchitecture.Core.Application.Library.Common.Repository;
using CleanArchitecture.Core.Domain.Library.UseCases.Security;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.Role.Repositories;

public interface IRoleRepository : IRepository<AppRoleEntity, long>
{
}
