using Domain.Library.BasesEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.PRD
{
    [Table("Books", Schema = "PRD")]
    public class Book : BaseEntity
    {
    }
}
