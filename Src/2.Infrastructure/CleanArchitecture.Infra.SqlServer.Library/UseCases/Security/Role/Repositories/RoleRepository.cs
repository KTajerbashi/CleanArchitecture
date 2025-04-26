using CleanArchitecture.Core.Application.Library.UseCases.Security.Role.Repositories;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Security.Role.Repositories;

public class RoleRepository : Repository<AppRoleEntity, long>, IRoleRepository
{
}
