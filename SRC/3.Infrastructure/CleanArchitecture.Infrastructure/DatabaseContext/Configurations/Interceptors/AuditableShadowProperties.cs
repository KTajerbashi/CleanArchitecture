﻿using CleanArchitecture.Application.BaseApplication.UserManagement;
using CleanArchitecture.Domain.BasesDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CleanArchitecture.Infrastructure.DatabaseContext.Configurations.Interceptors;

public static class AuditableShadowProperties
{
    public static readonly Func<object, bool> EFPropertyIsActive =
                                    entity => EF.Property<bool>(entity, IsActive);
    public static readonly string IsActive = nameof(IsActive);

    public static readonly Func<object, string> EFPropertyIsDeleted =
                                    entity => EF.Property<string>(entity, IsDeleted);
    public static readonly string IsDeleted = nameof(IsDeleted);

    public static readonly Func<object, string> EFPropertyCreatedByUserId =
                                    entity => EF.Property<string>(entity, CreatedByUserId);
    public static readonly string CreatedByUserId = nameof(CreatedByUserId);

    public static readonly Func<object, string> EFPropertyModifiedByUserId =
                                    entity => EF.Property<string>(entity, ModifiedByUserId);
    public static readonly string ModifiedByUserId = nameof(ModifiedByUserId);

    public static readonly Func<object, DateTime?> EFPropertyCreatedDateTime =
                                    entity => EF.Property<DateTime?>(entity, CreatedDateTime);
    public static readonly string CreatedDateTime = nameof(CreatedDateTime);

    public static readonly Func<object, DateTime?> EFPropertyModifiedDateTime =
                                    entity => EF.Property<DateTime?>(entity, ModifiedDateTime);
    public static readonly string ModifiedDateTime = nameof(ModifiedDateTime);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    public static ModelBuilder AddAuditableShadowProperties<TId>(this ModelBuilder modelBuilder)
        where TId : struct,
              IComparable,
              IComparable<TId>,
              IConvertible,
              IEquatable<TId>,
              IFormattable
    {
        /// تمامی کلاس های که اینترفس 
        /// IAuditableEntity
        /// را دارند را بگیر و پراپرتی های مورد نظر را به آنها اضافه کن
        /// و این فقط فبلد دیتابیس ساخته میشود
        foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(c => typeof(IEntity<TId>).IsAssignableFrom(c.ClrType)))
        {
            modelBuilder.Entity(entityType.ClrType)
                        .Property<bool>(IsActive).HasDefaultValue(true);

            modelBuilder.Entity(entityType.ClrType)
                        .Property<bool>(IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity(entityType.ClrType)
                        .Property<string>(CreatedByUserId).HasMaxLength(50);

            modelBuilder.Entity(entityType.ClrType)
                        .Property<string>(ModifiedByUserId).HasMaxLength(50);

            modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime?>(CreatedDateTime);

            modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime?>(ModifiedDateTime);
        }
        return modelBuilder;
    }

    /// <summary>
    /// این متد فیلد های که ساخته میشود را مقدار دهی میکند
    /// </summary>
    /// <param name="changeTracker"></param>
    /// <param name="userInfoService"></param>
    public static void SetAuditableEntityPropertyValues(
        this ChangeTracker changeTracker,
        IUserWebInfoRepositories userInfoService)
    {

        var userAgent = userInfoService.GetUserAgent();
        var userIp = userInfoService.GetUserIp();
        var now = DateTime.UtcNow;
        var userId = userInfoService.UserIdOrDefault();

        var modifiedEntries = changeTracker.Entries().Where(x => x.State == EntityState.Modified);
        foreach (var modifiedEntry in modifiedEntries)
        {
            modifiedEntry.Property(ModifiedDateTime).CurrentValue = now;
            modifiedEntry.Property(ModifiedByUserId).CurrentValue = userId;
        }

        var addedEntries = changeTracker.Entries().Where(x => x.State == EntityState.Added);
        foreach (var addedEntry in addedEntries)
        {
            addedEntry.Property(CreatedDateTime).CurrentValue = now;
            addedEntry.Property(CreatedByUserId).CurrentValue = userId;
            addedEntry.Property(IsActive).CurrentValue = true;
            addedEntry.Property(IsDeleted).CurrentValue = false;
        }
    }

}

