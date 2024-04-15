using CleanArchitecture.Domain.Library.BaseEntities;
using CleanArchitecture.Domain.Library.Entities.SEC;
using CleanArchitecture.Domain.Library.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Library.Entities.BUS
{
    [Table("Factors", Schema = "BUS"), Description("فاکتور")]
    public class Factor : GeneralEntity
    {
        public FactorTypeEnum FactorType { get; set; }
        public string Code { get; set; }


        [ForeignKey("Customer")]
        public long CustomerID { get; set; }
        public virtual User Customer { get; set; }

        public virtual ICollection<FactorProduct> FactorProducts { get; set; }
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
