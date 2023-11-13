using Domain.Library.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.BUS
{
    [Table("Categories", Schema ="BUS"),Description("دسته بندی ها")]
    public class Category : GeneralEntity
    {
        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(x => x.ID).IsUnique();
            builder.HasMany(x => x.ProductTypes)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.ID);
        }
    }
}
