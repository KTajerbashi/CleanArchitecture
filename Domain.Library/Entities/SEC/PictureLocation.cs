using Domain.Library.BasesEntity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("PictureLocations", Schema = "SEC")]
    [Description("این جدول موقعیت نمایش هر تصویر را نمایش میدهد")]
    public class PictureLocation : BaseEntity
    {
        [ForeignKey("Location")]
        public long LocationID { get; set; }
        public Location Location { get; set; }

        [ForeignKey("Picture")]
        public long PictureID { get; set; }
        public Picture Picture { get; set; }
    }
}
