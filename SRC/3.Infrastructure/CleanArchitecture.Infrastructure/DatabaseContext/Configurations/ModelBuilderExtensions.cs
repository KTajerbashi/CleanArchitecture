using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Infrastructure.DatabaseContext.Configurations.DataSeeds;
using CleanArchitecture.Infrastructure.DatabaseContext.Configurations.Interceptors;
using CleanArchitecture.Infrastructure.DatabaseContext.Configurations.Security;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DatabaseContext.Configurations;

public static class ModelBuilderExtensions
{
    public static ModelBuilder AddModelBuilder(this ModelBuilder modelBuilder)
        => modelBuilder
        .AddEntityModelBuilder()
        .AddShadowEntityConfigurationModelBuilder()
        .AddEntityConfigurationModelBuilder()
        .AddSeedDataConfiguration();
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
    private static ModelBuilder AddShadowEntityConfigurationModelBuilder(this ModelBuilder modelBuilder)
    {
        modelBuilder.AddAuditableShadowProperties<long>();
        modelBuilder.AddAuditableShadowProperties<int>();
        return modelBuilder;
    }
}

