using CleanArchitecture.Core.Domain.Library.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Configurations.Identity;

public static class CommonExtensions
{
    public static void AddAuditableMapping<TEntity, TId>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IAuditableEntity<TId>
        where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
    {
        builder.Property(item => item.EntityId).HasColumnName("EntityId");
        builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");
        builder.Property(item => item.IsActive).HasColumnName("IsActive");
        builder.Property(item => item.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(item => item.CreatedByUserRoleId).HasColumnName("CreatedByUserRoleId").IsRequired();
        builder.Property(item => item.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(item => item.UpdatedByUserRoleId).HasColumnName("UpdatedByUserRoleId");
    }
}
