using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Configurations.Identity;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserTokenEntity>
{
    public void Configure(EntityTypeBuilder<UserTokenEntity> builder)
    {
        builder.ToTable("UserTokens", "Security");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.IsActive).HasColumnName("IsActive");
        builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");
        builder.Property(item => item.UserId).HasColumnName("UserId");
        builder.Property(item => item.LoginProvider).HasColumnName("LoginProvider");
        builder.Property(item => item.Name).HasColumnName("Name");
        builder.Property(item => item.Value).HasColumnName("Value");
    }
}



public class AppUserTokenConfiguration : IEntityTypeConfiguration<AppUserTokenEntity>
{
    public void Configure(EntityTypeBuilder<AppUserTokenEntity> builder)
    {
        builder.ToTable("UserTokens", "Security");
        builder.HasKey(item => item.Id);
        builder.HasOne<UserTokenEntity>()
             .WithOne()
             .HasForeignKey<AppUserTokenEntity>(x => x.Id);

        //builder.Property(item => item.IsActive).HasColumnName("IsActive");
        //builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");
        //builder.Property(item => item.UserId).HasColumnName("UserId");
        //builder.Property(item => item.LoginProvider).HasColumnName("LoginProvider");
        //builder.Property(item => item.Name).HasColumnName("Name");
        //builder.Property(item => item.Value).HasColumnName("Value");

    }
}