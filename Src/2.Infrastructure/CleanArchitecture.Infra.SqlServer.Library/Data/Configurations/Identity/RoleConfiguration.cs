using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Configurations.Identity;

public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        //builder.ToTable("Roles", "Security");
        //builder.HasKey(item => item.Id);
        //builder.Property(item => item.Title).HasColumnName("Title").HasMaxLength(256);
        //builder.Property(item => item.Name).HasColumnName("Name");
        //builder.Property(item => item.NormalizedName).HasColumnName("NormalizedName");
        //builder.Property(item => item.ConcurrencyStamp).HasColumnType("nvarchar(max)").HasColumnName("ConcurrencyStamp").IsConcurrencyToken().HasDefaultValueSql("NEWID()"); // Let SQL Server generate it
        //builder.AddAuditableMapping<RoleEntity, long>();

    }
}

//public class AppRoleConfiguration : IEntityTypeConfiguration<AppRoleEntity>
//{
//    public void Configure(EntityTypeBuilder<AppRoleEntity> builder)
//    {
//        //builder.ToTable("Roles", "Security");
//        //builder.HasKey(item => item.Id);
//        //builder.HasOne<RoleEntity>()
//        //   .WithOne()
//        //   .HasForeignKey<AppRoleEntity>(x => x.Id);
//        //builder.Property(item => item.ConcurrencyStamp).HasColumnType("nvarchar(max)").HasColumnName("ConcurrencyStamp").IsConcurrencyToken().HasDefaultValueSql("NEWID()"); // Let SQL Server generate it

//        //builder.Property(item => item.Title).HasColumnName("Title").HasMaxLength(256);
//        //builder.Property(item => item.Name).HasColumnName("Name").HasMaxLength(256);
//        //builder.Property(item => item.NormalizedName).HasColumnName("NormalizedName").HasMaxLength(256);
//        //builder.AddAuditableMapping<AppRoleEntity, long>();


//    }
//}