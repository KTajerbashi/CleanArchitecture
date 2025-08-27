using CleanArchitecture.Infra.SqlServer.Identity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Data.Configurations.Identity;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLoginEntity>
{
    public void Configure(EntityTypeBuilder<UserLoginEntity> builder)
    {
        //builder.ToTable("UserLogins", "Security");
        //builder.HasKey(item => item.Id);
        //builder.AddAuditableMapping<UserLoginEntity, long>();

        //builder.Property(item => item.LoginProvider).HasColumnName("LoginProvider");
        //builder.Property(item => item.ProviderKey).HasColumnName("ProviderKey");
        //builder.Property(item => item.ProviderDisplayName).HasColumnName("ProviderDisplayName");
        //builder.Property(item => item.UserId).HasColumnName("UserId");
    }
}

//public class AppUserLoginConfiguration : IEntityTypeConfiguration<AppUserLoginEntity>
//{
//    public void Configure(EntityTypeBuilder<AppUserLoginEntity> builder)
//    {
//        //builder.ToTable("UserLogins", "Security");
//        //builder.HasKey(item => item.Id);
//        //builder.HasOne<UserLoginEntity>()
//        //     .WithOne()
//        //     .HasForeignKey<AppUserLoginEntity>(x => x.Id);

//        //builder.AddAuditableMapping<AppUserLoginEntity, long>();

//        //builder.Property(item => item.LoginProvider).HasColumnName("LoginProvider");
//        //builder.Property(item => item.ProviderKey).HasColumnName("ProviderKey");
//        //builder.Property(item => item.ProviderDisplayName).HasColumnName("ProviderDisplayName");
//        //builder.Property(item => item.UserId).HasColumnName("UserId");

//    }
//}
