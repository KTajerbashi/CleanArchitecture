using CleanArchitecture.Domain.Library.BaseEntities;
using CleanArchitecture.Domain.Library.Entities.BUS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Library.Entities.GEN
{
    [Table("Pictures", Schema = "GEN"), Description("تصویر")]
    public class Picture : GeneralEntity
    {
        [ForeignKey("Product")]
        public long ProductID { get; set; }
        public virtual Product Product { get; set; }



        public string Name { get; set; }
        public string Folder { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return $"/{Folder}/{Name}";
        }
    }
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasOne(x => x.Product)
                .WithMany(x => x.Pictures)
                .HasForeignKey(x => x.ProductID);
        }
    }
}
