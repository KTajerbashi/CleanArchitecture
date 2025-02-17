using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.SqlServer.Library.Data;

public abstract class BaseDatabaseContext : IdentityDbContext<
    UserEntity, 
    RoleEntity, 
    long, 
    UserClaimEntity, 
    UserRoleEntity, 
    UserLoginEntity, 
    RoleClaimEntity, 
    UserTokenEntity
    >
{
    protected BaseDatabaseContext()
    {
        
    }
    protected BaseDatabaseContext(DbContextOptions options):base(options) { }
}
