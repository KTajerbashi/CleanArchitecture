using Domain.Library.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.BUS
{
    [Table("FactorProducts", Schema ="BUS"),Description("فاکتور محصولات")]
    public class FactorProduct : GeneralEntity
    {
        [ForeignKey("Product")]
        public long ProductID { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Factor")]
        public long FactorID { get; set; }
        public Factor Factor { get; set; }
    }
    public class FactorProductConfiguration : IEntityTypeConfiguration<FactorProduct>
    {
        public void Configure(EntityTypeBuilder<FactorProduct> builder)
        {
            builder.HasOne(x => x.Product)
                .WithMany(x => x.FactorProducts)
                .HasForeignKey(x => x.ProductID);

            builder.HasOne(x => x.Factor)
                .WithMany(x => x.FactorProducts)
                .HasForeignKey(x => x.FactorID);
        }
    }
}
