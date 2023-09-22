using Application.Library.Interfaces.SEC.Role.DTOs;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Library.EntityConfigurations.SEC
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasIndex(x => x.ID);

            builder.HasMany(x => x.PersonRoles)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleID);

            builder.HasOne(x => x.Privilege)
                .WithOne(x => x.Role)
                .HasForeignKey<Privilege>(x => x.RoleID);
        }
    }
}
