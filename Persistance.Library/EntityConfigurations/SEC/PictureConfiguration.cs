using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Library.EntityConfigurations.SEC
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasIndex(x => x.ID);

            builder.HasMany(x => x.PictureLocations)
                .WithOne(x => x.Picture)
                .HasForeignKey(x => x.PictureID);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Pictures)
                .HasForeignKey(x => x.PersonID);
        }
    }
}
