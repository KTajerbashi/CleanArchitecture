using Domain.Library.BaseEntities;
using Domain.Library.Entities.GEN;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Library.Entities.BUS
{
    [Table("Products", Schema = "BUS"), Description("محصولات")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }


        [ForeignKey("Category")]
        public long CategoryID { get; set; }
        public Category Category { get; set; }

        [ForeignKey("ProductType")]
        public long ProductTypeID { get; set; }
        public ProductType ProductType { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }
        public ICollection<FactorProduct> FactorProducts { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public string AttachmentObject { get; set; }

    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(p => p.ID).IsUnique();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryID);

            builder.HasOne(x => x.ProductType)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductTypeID);

            builder.HasMany(x => x.ProductDetails)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ID);

            builder.HasMany(x => x.FactorProducts)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ID);

            builder.HasMany(x => x.Pictures)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID);



        }
    }
}
