using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities
{
    [Table("Roles", Schema = "SEC")]
    public class Role : BaseEntity
    {
        public string Title { get; set; }
    }
}
