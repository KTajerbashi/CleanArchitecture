using Common.Library.Utilities;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Library.EntityConfigurations.SEC
{
    public class PictureLocationConfiguration : IEntityTypeConfiguration<PictureLocation>
    {
        public void Configure(EntityTypeBuilder<PictureLocation> builder)
        {

            builder.HasQueryFilter(x => x.IsDeleted == false);
            builder.HasComment(ClassExtention.GetDescription(typeof(PictureLocation)));


            builder.HasIndex(x => x.ID);

            builder.HasOne(x => x.Location)
                .WithMany(x => x.PictureLocations)
                .HasForeignKey(x => x.LocationID);

            builder.HasOne(x => x.Picture)
                .WithMany(x => x.PictureLocations)
                .HasForeignKey(x => x.PictureID);
        }
    }
}
