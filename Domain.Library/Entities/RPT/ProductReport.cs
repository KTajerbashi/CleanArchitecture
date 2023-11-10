using Domain.Library.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.RPT
{
    [Table("ProductReports", Schema = "RPT"), Description("گزارش محصول")]
    public class ProductReport : BaseEntity
    {
    }
    public class ProductReportConfiguration : IEntityTypeConfiguration<ProductReport>
    {
        public void Configure(EntityTypeBuilder<ProductReport> builder)
        {
        }
    }
}
