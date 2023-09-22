using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("Pictures", Schema = "SEC")]
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

        [ForeignKey("Person")]
        public long PersonID { get; set; }
        public Person Person { get; set; }

        [Description("موقعیت های که عکس استفاده شود")]
        public ICollection<PictureLocation> PictureLocations { get; set; }
    }
}
