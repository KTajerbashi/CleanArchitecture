using CleanArchitecture.Core.Application.Common.Repository;
using CleanArchitecture.Core.Domain.UseCases.Security;

namespace CleanArchitecture.Core.Application.UseCases.Security.Role.Repositories;

public interface IRoleRepository : IRepository<AppRoleEntity, long>
{
    Task<AppRoleEntity> FindByNameAsync(string roleName, CancellationToken cancellationToken);
}
