using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Configurations.Identity;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        //// Each User can have many UserClaims
        //builder.HasMany(e => e.Claims)
        //    .WithOne()
        //    .HasForeignKey(uc => uc.UserId)
        //    .IsRequired();

        //// Each User can have many UserLogins
        //builder.HasMany(e => e.Logins)
        //    .WithOne()
        //    .HasForeignKey(ul => ul.UserId)
        //    .IsRequired();

        //// Each User can have many UserTokens
        //builder.HasMany(e => e.Tokens)
        //    .WithOne()
        //    .HasForeignKey(ut => ut.UserId)
        //    .IsRequired();
    }
}


public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
{
    public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
    {
    }
}


public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
    }
}
