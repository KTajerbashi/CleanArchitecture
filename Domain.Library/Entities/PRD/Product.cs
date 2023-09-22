using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.PRD
{
    [Table("Products", Schema = "PRD")]
    public class Product : BaseEntity
    {
    }
}
