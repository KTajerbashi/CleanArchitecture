using CleanArchitecture.Domain.Library.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CleanArchitecture.Domain.Library.Entities.Constance
{
    /// <summary>
    /// مدعی نقش
    /// </summary>
    [Table("Categories", Schema = "Constance"), Description("دسته بندی")]
    public class CategoryEntity : GeneralEntity
    {
    }
}
