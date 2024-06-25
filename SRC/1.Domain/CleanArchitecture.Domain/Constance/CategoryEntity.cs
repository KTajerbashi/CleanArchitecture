using CleanArchitecture.Domain.BasesDomain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Constance;

/// <summary>
/// مدعی نقش
/// </summary>
[Table("Categories", Schema = "Constance"), Description("دسته بندی")]
public class CategoryEntity : GeneralEntity
{
}
