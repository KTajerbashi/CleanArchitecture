using Common.Library.Utilities;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Library.EntityConfigurations.SEC
{
    public class PrivilegeConfiguration : IEntityTypeConfiguration<Privilege>
    {
        public void Configure(EntityTypeBuilder<Privilege> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);
            builder.HasComment(ExtentionUtilities.GetDescription(typeof(Privilege)));

            builder.HasIndex(x => x.ID);

            builder.HasOne(x => x.Role)
                .WithOne(x => x.Privilege)
                .HasForeignKey<Privilege>(x => x.RoleID);
        }
    }
}
