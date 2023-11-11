using Domain.Library.BaseEntities;
using Domain.Library.Entities.SEC;
using Domain.Library.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.BUS
{
    [Table("Factors", Schema ="BUS"),Description("فاکتور")]
    public class Factor : GeneralEntity
    {
        public FactorTypeEnum FactorType { get; set; }
        public string Code { get; set; }


        [ForeignKey("Customer")]
        public long CustomerID { get; set; }
        public User Customer { get; set; }

        public ICollection<FactorProduct> FactorProducts { get; set; }
    }
    public class FactorConfiguration : IEntityTypeConfiguration<Factor>
    {
        public void Configure(EntityTypeBuilder<Factor> builder)
        {
            builder.HasIndex(x => new { x.ID });

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.CustomerFactores)
                .HasForeignKey(x => x.CustomerID);

            builder.HasMany(x => x.FactorProducts)
                .WithOne(x => x.Factor)
                .HasForeignKey(x => x.ID);
        }
    }
}
