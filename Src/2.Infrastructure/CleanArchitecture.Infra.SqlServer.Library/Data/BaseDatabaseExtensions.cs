using CleanArchitecture.Infra.SqlServer.Library.Data.Seed;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.SqlServer.Library.Data;

public static class BaseDatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var initialiser = scope.ServiceProvider.GetRequiredService<InitializerSeedData>();
        await initialiser.RunAsync();
    }

    public static ModelBuilder AddSecurityConfiguration(this ModelBuilder builder)
    {
        builder.Entity<UserEntity>().ToTable("Users", "Security");
        builder.Entity<AppUserEntity>().ToTable("Users", "Security");

        builder.Entity<UserClaimEntity>().ToTable("UserClaims", "Security");
        builder.Entity<AppUserClaimEntity>().ToTable("UserClaims", "Security");
        
        builder.Entity<UserLoginEntity>().ToTable("UserLogins", "Security");
        builder.Entity<AppUserLoginEntity>().ToTable("UserLogins", "Security");

        builder.Entity<UserRoleEntity>().ToTable("UserRoles", "Security");
        builder.Entity<AppUserRoleEntity>().ToTable("UserRoles", "Security");
        
        builder.Entity<UserTokenEntity>().ToTable("UserTokens", "Security");
        builder.Entity<AppUserTokenEntity>().ToTable("UserTokens", "Security");
        
        builder.Entity<RoleEntity>().ToTable("Roles", "Security");
        builder.Entity<AppRoleEntity>().ToTable("Roles", "Security");
        
        builder.Entity<RoleClaimEntity>().ToTable("RoleClaims", "Security");
        builder.Entity<AppRoleClaimEntity>().ToTable("RoleClaims", "Security");
        return builder;
    }
}

