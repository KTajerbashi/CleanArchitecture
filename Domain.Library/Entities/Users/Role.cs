using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities
{
    [Table("Role", Schema = "SEC")]
    public class Role : BaseEntity<long>
    {
        public string Title { get; set; }
    }
}
