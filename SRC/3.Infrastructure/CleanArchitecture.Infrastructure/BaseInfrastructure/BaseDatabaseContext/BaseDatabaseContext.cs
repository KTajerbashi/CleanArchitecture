using CleanArchitecture.Domain.Security.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.BaseDatabaseContext;

public abstract class BaseDatabaseContext : IdentityDbContext<UserEntity, RoleEntity, long, UserClaimEntity, UserRoleEntity, UserLoginEntity, RoleClaimEntity, UserTokenEntity>
{
    public BaseDatabaseContext(DbContextOptions options) : base(options)
    {

    }
    protected BaseDatabaseContext()
    {
        
    }
}
