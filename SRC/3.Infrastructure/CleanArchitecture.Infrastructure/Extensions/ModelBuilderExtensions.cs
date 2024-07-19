using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Infrastructure.Configurations.Security;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder AddModelBuilder(this ModelBuilder modelBuilder)
        => modelBuilder.AddEntityModelBuilder()
        .AddEntityConfigurationModelBuilder();
    private static ModelBuilder AddEntityModelBuilder(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().ToTable("Users", "Security");
        modelBuilder.Entity<RoleEntity>().ToTable("Roles", "Security");
        modelBuilder.Entity<RoleClaimEntity>().ToTable("RoleClaims", "Security");
        modelBuilder.Entity<UserClaimEntity>().ToTable("UserClaims", "Security");
        modelBuilder.Entity<UserLoginEntity>().ToTable("UserLogins", "Security");
        modelBuilder.Entity<UserRoleEntity>().ToTable("UserRoles", "Security");
        modelBuilder.Entity<UserTokenEntity>().ToTable("UserTokens", "Security");

        return modelBuilder;
    }
    private static ModelBuilder AddEntityConfigurationModelBuilder(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        return modelBuilder;
    }
}
