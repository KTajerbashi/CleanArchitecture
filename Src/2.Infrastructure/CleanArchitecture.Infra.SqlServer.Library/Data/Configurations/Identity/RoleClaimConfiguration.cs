using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Configurations.Identity;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaimEntity>
{
    public void Configure(EntityTypeBuilder<RoleClaimEntity> builder)
    {
        builder.ToTable("RoleClaims", "Security");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.RoleId).HasColumnName("RoleId");
        builder.Property(item => item.ClaimType).HasColumnName("ClaimType");
        builder.Property(item => item.ClaimValue).HasColumnName("ClaimValue");
        builder.Property(item => item.IsActive).HasColumnName("IsActive");
        builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");

    }
}

public class AppRoleClaimConfiguration : IEntityTypeConfiguration<AppRoleClaimEntity>
{
    public void Configure(EntityTypeBuilder<AppRoleClaimEntity> builder)
    {
        builder.ToTable("RoleClaims", "Security");
        builder.HasKey(item => item.Id);
        builder.HasOne<RoleClaimEntity>()
                  .WithOne()
                  .HasForeignKey<AppRoleClaimEntity>(x => x.Id);

        builder.Property(item => item.RoleId).HasColumnName("RoleId");
        builder.Property(item => item.ClaimType).HasColumnName("ClaimType");
        builder.Property(item => item.ClaimValue).HasColumnName("ClaimValue");
        builder.Property(item => item.IsActive).HasColumnName("IsActive");
        builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");
    }
}