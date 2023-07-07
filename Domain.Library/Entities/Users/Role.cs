using Domain.Library.Bases.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities
{
    [Table("Role", Schema = "SEC")]
    public class Role : BaseEntity
    {
        public string Title { get; set; }
    }
}
