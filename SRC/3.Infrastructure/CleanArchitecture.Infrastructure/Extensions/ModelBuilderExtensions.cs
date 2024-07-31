using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseDatabaseContext;
using CleanArchitecture.Infrastructure.Configurations.DataSeeds;
using CleanArchitecture.Infrastructure.Configurations.Security;
using CleanArchitecture.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder AddModelBuilder(this ModelBuilder modelBuilder, CleanArchitectureDb context)
        => modelBuilder
        .AddShadowEntityConfigurationModelBuilder()
        .AddEntityModelBuilder()
        .AddEntityConfigurationModelBuilder()
        .AddUserSeed(context);
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
        var entityTypes = modelBuilder.Model.GetEntityTypes()
            .Where(t => t.ClrType.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntity<>)));

        foreach (var entityType in entityTypes)
        {
            modelBuilder.Entity(entityType.ClrType).Property<DateTime>("CreateDate");
            modelBuilder.Entity(entityType.ClrType).Property<long>("CreateBy");
            modelBuilder.Entity(entityType.ClrType).Property<DateTime>("UpdateDate");
            modelBuilder.Entity(entityType.ClrType).Property<long>("UpdateBy");
            modelBuilder.Entity(entityType.ClrType).Property<bool>("IsDeleted");
            modelBuilder.Entity(entityType.ClrType).Property<bool>("IsActive");
        }
        return modelBuilder;
    }
}
