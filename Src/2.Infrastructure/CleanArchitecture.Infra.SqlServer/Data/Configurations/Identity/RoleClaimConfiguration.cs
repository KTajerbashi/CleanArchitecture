using CleanArchitecture.Infra.SqlServer.Identity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Data.Configurations.Identity;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaimEntity>
{
    public void Configure(EntityTypeBuilder<RoleClaimEntity> builder)
    {
        //builder.ToTable("RoleClaims", "Security");
        //builder.HasKey(item => item.Id);
        //builder.Property(item => item.RoleId).HasColumnName("RoleId");
        //builder.Property(item => item.ClaimType).HasColumnName("ClaimType");
        //builder.Property(item => item.ClaimValue).HasColumnName("ClaimValue");
        //builder.AddAuditableMapping<RoleClaimEntity, int>();


    }
}

//public class AppRoleClaimConfiguration : IEntityTypeConfiguration<AppRoleClaimEntity>
//{
//    public void Configure(EntityTypeBuilder<AppRoleClaimEntity> builder)
//    {
//        //builder.ToTable("RoleClaims", "Security");
//        //builder.HasKey(item => item.Id);
//        //builder.HasOne<RoleClaimEntity>()
//        //          .WithOne()
//        //          .HasForeignKey<AppRoleClaimEntity>(x => x.Id);

//        //builder.Property(item => item.RoleId).HasColumnName("RoleId");
//        //builder.Property(item => item.ClaimType).HasColumnName("ClaimType");
//        //builder.Property(item => item.ClaimValue).HasColumnName("ClaimValue");
//        //builder.AddAuditableMapping<AppRoleClaimEntity, int>();
//    }
//}