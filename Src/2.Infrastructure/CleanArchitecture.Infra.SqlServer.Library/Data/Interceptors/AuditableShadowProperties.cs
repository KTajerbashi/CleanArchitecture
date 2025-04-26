using CleanArchitecture.Core.Application.Library.Providers.UserManagement;
using CleanArchitecture.Core.Domain.Library.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Interceptors;

public static class AuditableShadowProperties
{
    public static readonly Func<object, bool> EFPropertyIsActive = entity => EF.Property<bool>(entity, IsActive);
    public static readonly string IsActive = nameof(IsActive);

    public static readonly Func<object, string> EFPropertyIsDeleted = entity => EF.Property<string>(entity, IsDeleted);
    public static readonly string IsDeleted = nameof(IsDeleted);

    public static readonly Func<object, long> EFPropertyCreatedByUserRoleId = entity => EF.Property<long>(entity, CreatedByUserRoleId);
    public static readonly string CreatedByUserRoleId = nameof(CreatedByUserRoleId);

    public static readonly Func<object, long> EFPropertyUpdatedByUserRoleId = entity => EF.Property<long>(entity, UpdatedByUserRoleId);
    public static readonly string UpdatedByUserRoleId = nameof(UpdatedByUserRoleId);

    public static readonly Func<object, DateTime?> EFPropertyCreatedDate = entity => EF.Property<DateTime?>(entity, CreatedDate);
    public static readonly string CreatedDate = nameof(CreatedDate);

    public static readonly Func<object, DateTime?> EFPropertyUpdatedDate = entity => EF.Property<DateTime?>(entity, UpdatedDate);
    public static readonly string UpdatedDate = nameof(UpdatedDate);

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
        foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(c => typeof(IAuditableEntity<TId>).IsAssignableFrom(c.ClrType)))
        {
            modelBuilder.Entity(entityType.ClrType)
                        .Property<bool>(IsDeleted).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity(entityType.ClrType)
                        .Property<bool>(IsActive).IsRequired().HasDefaultValue(true);
            modelBuilder.Entity(entityType.ClrType)
                        .Property<string>(CreatedByUserRoleId).HasMaxLength(50);
            modelBuilder.Entity(entityType.ClrType)
                        .Property<string>(UpdatedByUserRoleId).HasMaxLength(50);
            modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime?>(CreatedDate);
            modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime?>(UpdatedDate);
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
        IUser user)
    {

        var userAgent = user.Agent;
        var userIp = user.Ip;
        var now = DateTime.Now;
        var userRoleId = user.UserRoleId;

        var modifiedEntries = changeTracker.Entries().Where(x => x.State == EntityState.Modified);
        foreach (var modifiedEntry in modifiedEntries)
        {
            modifiedEntry.Property(UpdatedDate).CurrentValue = now;
            modifiedEntry.Property(UpdatedByUserRoleId).CurrentValue = userRoleId;
        }

        var addedEntries = changeTracker.Entries().Where(x => x.State == EntityState.Added);
        foreach (var addedEntry in addedEntries)
        {
            addedEntry.Property(CreatedDate).CurrentValue = now;
            addedEntry.Property(CreatedByUserRoleId).CurrentValue = userRoleId;
            addedEntry.Property(IsActive).CurrentValue = true;
            addedEntry.Property(IsDeleted).CurrentValue = false;
        }
    }

}
