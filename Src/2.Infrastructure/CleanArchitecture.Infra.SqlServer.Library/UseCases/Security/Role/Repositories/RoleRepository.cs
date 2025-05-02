using CleanArchitecture.Core.Application.Library.UseCases.Security.Role.Repositories;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Security.Role.Repositories;

public class RoleRepository : Repository<AppRoleEntity, long>, IRoleRepository
{
    public RoleRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<AppRoleEntity> FindByNameAsync(string roleName, CancellationToken cancellationToken)
    {
        return await Entity.Where(item => item.Name.ToLower().Equals(roleName)).SingleOrDefaultAsync(cancellationToken)!;
    }
}


public class RoleClaimRepository : Repository<AppRoleClaimEntity, int>, IRoleClaimRepository
{
    public RoleClaimRepository(DatabaseContext context) : base(context)
    {
    }
}
