using CleanArchitecture.Domain.BasesDomain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Constance.Entities;

/// <summary>
/// مدعی نقش
/// </summary>
[Table("Variables", Schema = "Constance"), Description("متغییر ها")]
public class VariableEntity : Entity
{
    public string Key { get; set; }
    public string Value { get; set; }

    [ForeignKey(nameof(VariableEntity))]
    public long ParentId { get; set; }
    public VariableEntity Children { get; set; }
}
