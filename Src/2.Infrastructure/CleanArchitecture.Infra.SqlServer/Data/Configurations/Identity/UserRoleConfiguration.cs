using CleanArchitecture.Infra.SqlServer.Identity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Data.Configurations.Identity;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
{
    public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
    {
        //builder.ToTable("UserRoles", "Security");
        builder.HasKey(item => new { item.Id, item.UserId, item.RoleId });
        //builder.AddAuditableMapping<UserRoleEntity, long>();
        //builder.Property(item => item.UserId).HasColumnName("UserId");
        //builder.Property(item => item.RoleId).HasColumnName("RoleId");

    }
}
//public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRoleEntity>
//{
//    public void Configure(EntityTypeBuilder<AppUserRoleEntity> builder)
//    {
//        //builder.ToTable("UserRoles", "Security");
//        //builder.HasKey(item => new { item.Id, item.UserId, item.RoleId });

//        //builder.HasOne<UserRoleEntity>()
//        //  .WithOne()
//        //  .HasForeignKey<AppUserRoleEntity>(e => new { e.Id, e.UserId, e.RoleId })
//        //  .HasPrincipalKey<UserRoleEntity>(e => new { e.Id, e.UserId, e.RoleId });

//        //builder.AddAuditableMapping<AppUserRoleEntity, long>();

//        //builder.Property(item => item.UserId).HasColumnName("UserId");
//        //builder.Property(item => item.RoleId).HasColumnName("RoleId");

//    }
//}

