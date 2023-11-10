using Domain.Library.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.BUS
{
    [Table("ProductDetails", Schema ="BUS"),Description("ویژگی محصولات")]
    public class ProductDetail : GeneralEntity
    {
        public string Value { get; set; }

        [ForeignKey("Product")]
        public long ProductID { get; set; }
        public Product Product { get; set; }
    }
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasIndex(x => x.ID);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductDetails)
                .HasForeignKey(x => x.ProductID);
        }
    }
}
