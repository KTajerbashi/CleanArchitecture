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
            IsActive=true,
            IsDeleted=false,
            Key = Guid.NewGuid(),
            AvatarFile = "Null",
            NationalCode = "1020304050",
            SignFile = "Null"
        };
        var adminRole = new RoleEntity
        {
            Id = 1,
            Name = "Admin",
            Title = "ادمین",
            NormalizedName = "ADMIN",
            Key = Guid.NewGuid(),
            IsDeleted=false,
            IsActive=true,
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
            IsActive=true,
            IsDeleted=false,
            Key = Guid.NewGuid(),
            AvatarFile = "Null",
            NationalCode = "1020304050",
            SignFile = "Null",
        };
        var normalRole = new RoleEntity
        {
            Id = 2,
            Name = "User",
            Title = "کاربر",
            NormalizedName = "USER",
            Key = Guid.NewGuid(),
            IsDeleted=false,
            IsActive=true,
        };

        var hasher = new PasswordHasher<UserEntity>();

        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");
        normalUser.PasswordHash = hasher.HashPassword(normalUser, "User@123");

        builder.Entity<RoleEntity>().HasData(adminRole,normalRole);
        builder.Entity<UserEntity>().HasData(adminUser,normalUser);
        builder.Entity<UserRoleEntity>().HasData(
           new UserRoleEntity
           {
               RoleId = adminRole.Id,
               UserId = adminUser.Id
           },
           new UserRoleEntity
           {
               RoleId = normalRole.Id,
               UserId = normalUser.Id
           }
       );
        return builder;
    }

}
