using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Configurations.Identity;
public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaimEntity>
{
    public void Configure(EntityTypeBuilder<UserClaimEntity> builder)
    {
        builder.ToTable("UserClaims", "Security");
        builder.HasKey(item => item.Id);

        builder.Property(item => item.IsActive).HasColumnName("IsActive");
        builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");
        builder.Property(item => item.UserId).HasColumnName("UserId");
        builder.Property(item => item.ClaimType).HasColumnName("ClaimType");
        builder.Property(item => item.ClaimValue).HasColumnName("ClaimValue");

    }
}


public class AppUserClaimConfiguration : IEntityTypeConfiguration<AppUserClaimEntity>
{
    public void Configure(EntityTypeBuilder<AppUserClaimEntity> builder)
    {
        builder.ToTable("UserClaims", "Security");
        builder.HasKey(item => item.Id);
        builder.HasOne<UserClaimEntity>()
            .WithOne()
            .HasForeignKey<AppUserClaimEntity>(x => x.Id);

        //builder.Property(item => item.IsActive).HasColumnName("IsActive");
        //builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");
        //builder.Property(item => item.UserId).HasColumnName("UserId");
        //builder.Property(item => item.ClaimType).HasColumnName("ClaimType");
        //builder.Property(item => item.ClaimValue).HasColumnName("ClaimValue");
    }
}


