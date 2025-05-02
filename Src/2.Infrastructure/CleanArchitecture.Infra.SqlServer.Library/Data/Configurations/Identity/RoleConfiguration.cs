using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Configurations.Identity;

public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("Roles", "Security");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Name).HasColumnName("Name");
        builder.Property(item => item.NormalizedName).HasColumnName("NormalizedName");
        builder.Property(item => item.ConcurrencyStamp).HasColumnName("ConcurrencyStamp");
        builder.Property(item => item.IsActive).HasColumnName("IsActive");
        builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");
    }
}

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRoleEntity>
{
    public void Configure(EntityTypeBuilder<AppRoleEntity> builder)
    {
        builder.ToTable("Roles", "Security");
        builder.HasKey(item => item.Id);
        builder.HasOne<RoleEntity>()
           .WithOne()
           .HasForeignKey<AppRoleEntity>(x => x.Id);

        builder.Property(item => item.Name).HasColumnName("Name");
        builder.Property(item => item.NormalizedName).HasColumnName("NormalizedName");
        builder.Property(item => item.IsActive).HasColumnName("IsActive");
        builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");

    }
}