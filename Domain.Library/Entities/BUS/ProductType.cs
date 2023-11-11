using Domain.Library.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.BUS
{
    [Table("ProductTypes", Schema ="BUS"),Description("نوع محصول")]
    public class ProductType : GeneralEntity
    {
        public virtual ICollection<Product> Products { get; set; }
    }
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasIndex(x => x.ID).IsUnique();

            builder.HasMany(p => p.Products)
                .WithOne(p => p.ProductType)
                .HasForeignKey(x => x.ID);
        }
    }
}
