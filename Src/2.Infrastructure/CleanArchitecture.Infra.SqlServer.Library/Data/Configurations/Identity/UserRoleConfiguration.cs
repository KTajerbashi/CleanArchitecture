using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Configurations.Identity;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
{
    public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
    {
        builder.ToTable("UserRoles", "Security");
        builder.HasKey(item => new { item.Id, item.UserId, item.RoleId });
        builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");
        builder.Property(item => item.IsActive).HasColumnName("IsActive");
        builder.Property(item => item.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(item => item.CreatedByUserRoleId).HasColumnName("CreatedByUserRoleId");
        builder.Property(item => item.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(item => item.UpdatedByUserRoleId).HasColumnName("UpdatedByUserRoleId");
        builder.Property(item => item.UserId).HasColumnName("UserId");
        builder.Property(item => item.RoleId).HasColumnName("RoleId");

    }
}
public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRoleEntity>
{
    public void Configure(EntityTypeBuilder<AppUserRoleEntity> builder)
    {
        builder.ToTable("UserRoles", "Security");
        builder.HasKey(item => new { item.Id, item.UserId, item.RoleId });

        builder.HasOne<UserRoleEntity>()
          .WithOne()
          .HasForeignKey<AppUserRoleEntity>(e => new { e.Id, e.UserId, e.RoleId })
          .HasPrincipalKey<UserRoleEntity>(e => new { e.Id, e.UserId, e.RoleId });

        builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");
        builder.Property(item => item.IsActive).HasColumnName("IsActive");
        builder.Property(item => item.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(item => item.CreatedByUserRoleId).HasColumnName("CreatedByUserRoleId");
        builder.Property(item => item.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(item => item.UpdatedByUserRoleId).HasColumnName("UpdatedByUserRoleId");
        builder.Property(item => item.UserId).HasColumnName("UserId");
        builder.Property(item => item.RoleId).HasColumnName("RoleId");

    }
}

