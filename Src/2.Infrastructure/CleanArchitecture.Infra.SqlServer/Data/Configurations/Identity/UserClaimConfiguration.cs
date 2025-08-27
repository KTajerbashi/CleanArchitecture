using CleanArchitecture.Infra.SqlServer.Identity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Data.Configurations.Identity;
public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaimEntity>
{
    public void Configure(EntityTypeBuilder<UserClaimEntity> builder)
    {
        //builder.ToTable("UserClaims", "Security");
        //builder.HasKey(item => item.Id);

        //builder.AddAuditableMapping<UserClaimEntity, long>();

        //builder.Property(item => item.UserId).HasColumnName("UserId");
        //builder.Property(item => item.ClaimType).HasColumnName("ClaimType");
        //builder.Property(item => item.ClaimValue).HasColumnName("ClaimValue");

    }
}


//public class AppUserClaimConfiguration : IEntityTypeConfiguration<AppUserClaimEntity>
//{
//    public void Configure(EntityTypeBuilder<AppUserClaimEntity> builder)
//    {
//        //    builder.ToTable("UserClaims", "Security");
//        //    builder.HasKey(item => item.Id);
//        //    builder.HasOne<UserClaimEntity>()
//        //        .WithOne()
//        //        .HasForeignKey<AppUserClaimEntity>(x => x.Id);

//        //    builder.AddAuditableMapping<AppUserClaimEntity, long>();

//        //    builder.Property(item => item.UserId).HasColumnName("UserId");
//        //    builder.Property(item => item.ClaimType).HasColumnName("ClaimType");
//        //    builder.Property(item => item.ClaimValue).HasColumnName("ClaimValue");
//    }
//}


