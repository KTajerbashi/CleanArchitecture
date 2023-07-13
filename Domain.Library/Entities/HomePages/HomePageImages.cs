
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities
{
    [Table("HomePaheImages", Schema = "GEN")]
    public class HomePageImages : BaseEntity
    {
        public string Src { get; set; }
        public string link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }

    public enum ImageLocation
    {
        L1=0,
        L2=1,
        R1=3,
        CenterFullScreen=4,
        G1=5,
        G2=6,
    }

}
