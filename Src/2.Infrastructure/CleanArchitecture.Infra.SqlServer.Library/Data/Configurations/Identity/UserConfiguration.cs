using CleanArchitecture.Core.Domain.Library.Common;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Configurations.Identity;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(item => item.Id);
        builder.ToTable("Users", "Security");

        builder.Property(item => item.Name).HasColumnName("Name");
        builder.Property(item => item.Family).HasColumnName("Family");
        builder.Property(item => item.DisplayName).HasColumnName("DisplayName");
        builder.Property(item => item.PersonalCode).HasColumnName("PersonalCode");
        builder.Property(item => item.UserName).HasColumnName("UserName");
        builder.Property(item => item.NormalizedUserName).HasColumnName("NormalizedUserName");
        builder.Property(item => item.Email).HasColumnName("Email");
        builder.Property(item => item.NormalizedEmail).HasColumnName("NormalizedEmail");
        builder.Property(item => item.EmailConfirmed).HasColumnName("EmailConfirmed");
        builder.Property(item => item.PasswordHash).HasColumnName("PasswordHash");
        builder.Property(item => item.SecurityStamp).HasColumnName("SecurityStamp");
        builder.Property(item => item.ConcurrencyStamp).HasColumnType("nvarchar(max)").HasColumnName("ConcurrencyStamp");
        builder.Property(item => item.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(item => item.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
        builder.Property(item => item.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
        builder.Property(item => item.LockoutEnd).HasColumnName("LockoutEnd");
        builder.Property(item => item.LockoutEnabled).HasColumnName("LockoutEnabled");
        builder.Property(item => item.AccessFailedCount).HasColumnName("AccessFailedCount");
        builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");
        builder.Property(item => item.IsActive).HasColumnName("IsActive");
    }
}
public class AppUserConfiguration : IEntityTypeConfiguration<AppUserEntity>
{
    public void Configure(EntityTypeBuilder<AppUserEntity> builder)
    {
        builder.HasKey(item => item.Id);
        builder.ToTable("Users", "Security");
        builder.HasOne<UserEntity>()
           .WithOne()
           .HasForeignKey<AppUserEntity>(x => x.Id);

        //builder.Property(item => item.Name).HasColumnName("Name");
        //builder.Property(item => item.Family).HasColumnName("Family");
        //builder.Property(item => item.DisplayName).HasColumnName("DisplayName");
        //builder.Property(item => item.PersonalCode).HasColumnName("PersonalCode");
        //builder.Property(item => item.UserName).HasColumnName("UserName");
        //builder.Property(item => item.NormalizedUserName).HasColumnName("NormalizedUserName");
        //builder.Property(item => item.Email).HasColumnName("Email");
        //builder.Property(item => item.NormalizedEmail).HasColumnName("NormalizedEmail");
        //builder.Property(item => item.EmailConfirmed).HasColumnName("EmailConfirmed");
        //builder.Property(item => item.PasswordHash).HasColumnName("PasswordHash");
        //builder.Property(item => item.SecurityStamp).HasColumnName("SecurityStamp");
        ////builder.Property(item => item.ConcurrencyStamp).HasColumnType("nvarchar(max)").HasColumnName("ConcurrencyStamp");
        //builder.Property(item => item.PhoneNumber).HasColumnName("PhoneNumber");
        //builder.Property(item => item.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
        //builder.Property(item => item.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
        //builder.Property(item => item.LockoutEnd).HasColumnName("LockoutEnd");
        //builder.Property(item => item.LockoutEnabled).HasColumnName("LockoutEnabled");
        //builder.Property(item => item.AccessFailedCount).HasColumnName("AccessFailedCount");
        //builder.Property(item => item.IsDeleted).HasColumnName("IsDeleted");
        //builder.Property(item => item.IsActive).HasColumnName("IsActive");

    }
}



