using CleanArchitecture.Core.Application.UseCases.Security.User.Repositories;
using CleanArchitecture.Core.Domain.UseCases.Security;
using CleanArchitecture.Infra.SqlServer.Common.Repository;
using CleanArchitecture.Infra.SqlServer.Data;
using CleanArchitecture.Infra.SqlServer.Exceptions;
using CleanArchitecture.Infra.SqlServer.Identity.Entities;

namespace CleanArchitecture.Infra.SqlServer.UseCases.Security.User.Repositories;

public class UserRoleRepository : Repository<AppUserRoleEntity, long>, IUserRoleRepository
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly RoleManager<RoleEntity> _roleManager;
    public UserRoleRepository(DatabaseContext context, UserManager<UserEntity> userManager, RoleManager<RoleEntity> roleManager) : base(context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public override async Task<AppUserRoleEntity> AddAsync(AppUserRoleEntity entity, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(entity.UserId.ToString());
        if (user == null)
            throw new InfraException("User not found");

        var role = await _roleManager.FindByIdAsync(entity.RoleId.ToString());
        if (role == null)
            throw new InfraException("Role not found");

        var userRoleEntity = new UserRoleEntity(entity.UserId, entity.RoleId);
        await Context.UserRoles.AddAsync(userRoleEntity);
        entity.SetId(userRoleEntity.Id);
        return entity;
    }
}
