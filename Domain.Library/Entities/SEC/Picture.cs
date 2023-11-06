using Domain.Library.BasesEntity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("Pictures", Schema = "SEC")]
    [Description("این جدول اطلاعات تصاویر ذخیره شده را نگهداری میکند")]
    public class Picture : BaseEntity
    {
        [Description("نام عکس")]
        public string Name { get; set; }
        [Description("نام پوشه")]
        public string Folder { get; set; }
        [Description("لینک برای عکس")]
        public string Link { get; set; }
        [Description("آدرس عکس در پوشه")]
        public string Address
        {
            get
            {
                return Address;
            }
            set
            {
                Address = @$"/{Folder}/{Name}";
            }
        }

        [ForeignKey("User")]
        public long UserID { get; set; }
        public User User { get; set; }

        [Description("موقعیت های که عکس استفاده شود")]
        public ICollection<PictureLocation> PictureLocations { get; set; }
    }
}
