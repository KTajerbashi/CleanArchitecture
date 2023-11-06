using Domain.Library.BasesEntity;
using Domain.Library.Entities.CNT;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("Location", Schema = "SEC")]
    [Description("برای موقعیت تصاویر و اسلایدر ها")]
    public class Location : GeneralEntity
    {
        [Description("سلایدر های وب سایت")]
        public Slider? Slider { get; set; }

        [Description("لیست تصاویر که درین موقعیت نمایش داده میشود")]
        public ICollection<PictureLocation> PictureLocations { get; set; }

    }
}
