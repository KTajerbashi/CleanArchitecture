using CleanArchitecture.Core.Domain.Library.Entities.Security;
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
    private BaseDatabaseContext()
    {
        
    }
    protected BaseDatabaseContext(DbContextOptions options):base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.AddSecurityConfiguration();
    }

    #region Security
    public virtual DbSet<UserEntity> UserEntities => Set<UserEntity>();
    //public virtual DbSet<AppUserEntity> AppUserEntities => Set<AppUserEntity>();
    public virtual DbSet<UserClaimEntity> UserClaimEntities => Set<UserClaimEntity>();
    public virtual DbSet<UserLoginEntity> UserLoginEntities => Set<UserLoginEntity>();
    public virtual DbSet<UserTokenEntity> UserTokenEntities => Set<UserTokenEntity>();
    public virtual DbSet<RoleEntity> RoleEntities => Set<RoleEntity>();
    //public virtual DbSet<AppRoleEntity> AppRoleEntities => Set<AppRoleEntity>();
    public virtual DbSet<RoleClaimEntity> RoleClaimEntities => Set<RoleClaimEntity>();
    public virtual DbSet<UserRoleEntity> UserRoleEntities => Set<UserRoleEntity>();
    //public virtual DbSet<AppUserRoleEntity> AppUserRoleEntities => Set<AppUserRoleEntity>();
    #endregion

}
