using CleanArchitecture.Domain.Security.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Configurations.DataSeeds;

public static class SeedDataConfiguration
{
    public static ModelBuilder AddUserSeed(this ModelBuilder builder)
    {
        var adminUser = new UserEntity
        {
            Id = 1,
            FirstName="ادمین",
            LastName="ادمین",
            UserName="Admin",
            NormalizedUserName="Admin".ToUpper(),
            Email = "Admin@mail.com",
            NormalizedEmail = "Admin@mail.com".ToUpper(),
            Gender = Domain.Security.Enums.GenderTypeEnum.Male,
            Key = Guid.NewGuid(),
            AvatarFile = "Null",
            NationalCode = "1020304050",
            SignFile = "Null",
            SecurityStamp=Guid.NewGuid().ToString("D"),
        };
        var adminRole = new RoleEntity
        {
            Id = 1,
            Name = "Admin",
            Title = "ادمین",
            NormalizedName = "ADMIN",
            Key = Guid.NewGuid(),
        };

        var normalUser = new UserEntity
        {
            Id = 2,
            FirstName="کاربر",
            LastName="کاربر",
            UserName="User",
            NormalizedUserName = "USER",
            Email = "User@mail.com",
            NormalizedEmail = "User@mail.com".ToUpper(),
            Gender = Domain.Security.Enums.GenderTypeEnum.Male,
            Key = Guid.NewGuid(),
            AvatarFile = "Null",
            NationalCode = "1020304050",
            SignFile = "Null",
            SecurityStamp=Guid.NewGuid().ToString("D")
        };
        var normalRole = new RoleEntity
        {
            Id = 2,
            Name = "User",
            Title = "کاربر",
            NormalizedName = "USER",
            Key = Guid.NewGuid(),
        };

        var hasher = new PasswordHasher<UserEntity>();

        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");
        normalUser.PasswordHash = hasher.HashPassword(normalUser, "User@123");

        builder.Entity<RoleEntity>().HasData(adminRole, normalRole);
        builder.Entity<UserEntity>().HasData(adminUser, normalUser);

        var key = Guid.NewGuid();
        List<UserRoleEntity> userRoleEntities = new List<UserRoleEntity>
        {
            new UserRoleEntity
            {
               Id = 1,
               RoleId = adminRole.Id,
               UserId = adminUser.Id,
               IsDefault = true,
               Key = key
            },
            new UserRoleEntity
            {
               Id = 2,
               RoleId = normalRole.Id,
               UserId = normalUser.Id,
               IsDefault = true,
               Key = key
            }
        };
        builder.Entity<UserRoleEntity>().HasData(userRoleEntities);

        //List<object> entities = new List<object>
        //{
        //    adminUser,
        //    adminRole,
        //    normalUser,
        //    normalRole,
        //    userRoleEntities[0],
        //    userRoleEntities[1],
        //};

        return builder;
    }

}

