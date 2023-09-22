using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Library.EntityConfigurations.SEC
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasIndex(i => i.ID);
            builder
                .HasMany(pl => pl.PictureLocations)
                .WithOne(l => l.Location)
                .HasForeignKey(l => l.LocationID);
        }
    }
}
