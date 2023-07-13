using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities
{
    [Table("Sliders", Schema = "GEN")]
    public class Slider : BaseEntity
    {
        public string Src { get; set; }
        public string link { get; set; }
    }
}
