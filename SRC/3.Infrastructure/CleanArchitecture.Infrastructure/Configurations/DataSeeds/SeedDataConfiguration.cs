using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Domain.Security.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Configurations.DataSeeds;

public static class SeedDataConfiguration
{
    public static ModelBuilder AddSeedDataConfiguration(this ModelBuilder builder)
        => builder
                .AddRoleSeedData()
                .AddUseSeedData()
                .AddUserRoleSeedData();


    private static ModelBuilder AddUseSeedData(this ModelBuilder builder)
    {
        var adminUser = new UserEntity
        {
            Id = 1L,
            FirstName="ادمین",
            LastName="ادمین",
            UserName="Admin",
            NormalizedUserName="Admin".ToUpper(),
            Email = "Admin@mail.com",
            NormalizedEmail = "Admin@mail.com".ToUpper(),
            EmailConfirmed = false,
            Gender = Domain.Security.Enums.GenderTypeEnum.Male,
            Key = Guid.NewGuid(),
            AvatarFile = "Null",
            NationalCode = "1020304050",
            SignFile = "Null",
            SecurityStamp=Guid.NewGuid().ToString("D"),
            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = true,
            AccessFailedCount = 0, // Default value,
        };
        var normalUser = new UserEntity
        {
            Id = 2L,
            FirstName="کاربر",
            LastName="کاربر",
            UserName="User",
            NormalizedUserName = "USER",
            Email = "User@mail.com",
            NormalizedEmail = "User@mail.com".ToUpper(),
            EmailConfirmed = false,
            Gender = Domain.Security.Enums.GenderTypeEnum.Male,
            Key = Guid.NewGuid(),
            AvatarFile = "Null",
            NationalCode = "1020304050",
            SignFile = "Null",
            SecurityStamp=Guid.NewGuid().ToString("D"),
            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = true,
            AccessFailedCount = 0 // Default value
        };
        builder.Entity<UserEntity>().HasData(
            new
            {
                Id = adminUser.Id,
                FirstName = adminUser.FirstName,
                LastName = adminUser.LastName,
                UserName = adminUser.UserName,
                NormalizedUserName = adminUser.NormalizedUserName.ToUpper(),
                Email = adminUser.Email,
                NormalizedEmail = adminUser.NormalizedEmail.ToUpper(),
                EmailConfirmed = adminUser.EmailConfirmed,
                Gender = GenderTypeEnum.Male,
                Key = Guid.NewGuid(),
                AvatarFile = "Null",
                NationalCode = "1020304050",
                SignFile = "Null",
                SecurityStamp = adminUser.SecurityStamp,
                ConcurrencyStamp = adminUser.ConcurrencyStamp,
                PasswordHash = GetHash(adminUser,"@Admin#1234"),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = normalUser.LockoutEnd,
                LockoutEnabled = true,
                AccessFailedCount = 0, // Default value

                IsDeleted = false,
                IsActive = true,
                CreatedDateTime = DateTime.Now,
                CreatedByUserId = "1",
                ModifiedDateTime = DateTime.UtcNow,
                ModifiedByUserId = "1",

            },
            new
            {
                Id = normalUser.Id,
                FirstName = normalUser.FirstName,
                LastName = normalUser.LastName,
                UserName = normalUser.UserName,
                NormalizedUserName = normalUser.NormalizedUserName.ToUpper(),
                Email = normalUser.Email,
                NormalizedEmail = normalUser.NormalizedEmail.ToUpper(),
                EmailConfirmed = normalUser.EmailConfirmed,
                Gender = GenderTypeEnum.Male,
                Key = Guid.NewGuid(),
                AvatarFile = "Null",
                NationalCode = "1020304050",
                SignFile = "Null",
                SecurityStamp = normalUser.SecurityStamp,
                ConcurrencyStamp = normalUser.ConcurrencyStamp,
                PasswordHash = GetHash(normalUser, "@User#1234"),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = normalUser.LockoutEnd,
                LockoutEnabled = true,
                AccessFailedCount = 0, // Default value

                IsDeleted = false,
                IsActive = true,
                CreatedDateTime = DateTime.Now,
                CreatedByUserId = "1",
                ModifiedDateTime = DateTime.UtcNow,
                ModifiedByUserId = "1",
            });
        return builder;
    }

    private static ModelBuilder AddRoleSeedData(this ModelBuilder builder)
    {
        builder.Entity<RoleEntity>().HasData(
            new
            {
                Id = 1L,
                Name = "Admin",
                Title = "ادمین",
                NormalizedName = "ADMIN",
                Key = Guid.NewGuid(),
                IsDeleted = false,
                IsActive = true,
                CreatedDateTime = DateTime.Now,
                CreatedByUserId = "1",
                ModifiedDateTime = DateTime.UtcNow,
                ModifiedByUserId = "1",
            }
            ,
            new
            {
                Id = 2L,
                Name = "User",
                Title = "کاربر",
                NormalizedName = "USER",
                Key = Guid.NewGuid(),
                IsDeleted = false,
                IsActive = true,
                CreatedDateTime = DateTime.Now,
                CreatedByUserId = "1",
                ModifiedDateTime = DateTime.UtcNow,
                ModifiedByUserId = "1",
            });
        return builder;
    }

    private static ModelBuilder AddUserRoleSeedData(this ModelBuilder builder)
    {
        var key = Guid.NewGuid();
        var userRoleAdminEntities =
            new
            {
                Id = 1L,
                RoleId = 1L,
                UserId = 1L,
                IsDefault = true,
                Key = key,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(100),
                IsDeleted = false,
                IsActive = true,
                CreatedDateTime = DateTime.Now,
                CreatedByUserId = "1",
                ModifiedDateTime = DateTime.UtcNow,
                ModifiedByUserId = "1",
            };
        var userRoleNormalEntities =
            new
            {
                Id = 2L,
                RoleId = 2L,
                UserId = 2L,
                IsDefault = true,
                Key = key,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(100),
                IsDeleted = false,
                IsActive = true,
                CreatedDateTime = DateTime.Now,
                CreatedByUserId = "1",
                ModifiedDateTime = DateTime.UtcNow,
                ModifiedByUserId = "1",
            };
        builder.Entity<UserRoleEntity>().HasData(userRoleAdminEntities, userRoleNormalEntities);
        return builder;
    }

    private static string GetHash(UserEntity entity,string pass)
    {
        var hasher = new PasswordHasher<UserEntity>();
        return hasher.HashPassword(entity, pass);
    }
}

