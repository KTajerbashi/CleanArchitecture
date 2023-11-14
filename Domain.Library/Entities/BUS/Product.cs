using Domain.Library.BaseEntities;
using Domain.Library.Entities.GEN;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.BUS
{
    [Table("Products", Schema = "BUS"), Description("محصولات")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }

        [ForeignKey("ProductType")]
        public long ProductTypeID { get; set; }
        public virtual ProductType ProductType { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        public virtual ICollection<FactorProduct> FactorProducts { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public string AttachmentObject { get; set; }

    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasOne(x => x.ProductType)
               .WithMany(p => p.Products)
               .HasForeignKey(x => x.ProductTypeID);

            builder.HasMany(x => x.ProductDetails)
                .WithOne(x => x.Product)
                .HasPrincipalKey(x => x.ID);

            builder.HasMany(x => x.FactorProducts)
                .WithOne(x => x.Product)
                .HasPrincipalKey(x => x.ID);

            builder.HasMany(x => x.Pictures)
                .WithOne(x => x.Product)
                .HasPrincipalKey(x => x.ID);
        }
    }
}
