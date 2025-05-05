using CleanArchitecture.Core.Application.Library.UseCases.Security.Role.Repositories;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Security.Role.Repositories;

public class RoleRepository : Repository<AppRoleEntity, long>, IRoleRepository
{
    private readonly RoleManager<RoleEntity> _roleManager;
    public RoleRepository(DatabaseContext context, RoleManager<RoleEntity> roleManager) : base(context)
    {
        _roleManager = roleManager;
    }

    public async Task<AppRoleEntity> FindByNameAsync(string roleName, CancellationToken cancellationToken)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role is null)
            return null;
        return role.AppRoleEntity();
    }
    public override async Task<AppRoleEntity> AddAsync(AppRoleEntity entity, CancellationToken cancellationToken)
    {
        RoleEntity roleEntity = new RoleEntity(entity.Name,entity.Title);
        await _roleManager.CreateAsync(roleEntity);
        entity.SetId(roleEntity.Id);
        return entity;
    }
}


public class RoleClaimRepository : Repository<AppRoleClaimEntity, int>, IRoleClaimRepository
{
    public RoleClaimRepository(DatabaseContext context) : base(context)
    {
    }
}
