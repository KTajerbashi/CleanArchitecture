using CleanArchitecture.Domain.Library.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CleanArchitecture.Domain.Library.Entities.Constance
{
    /// <summary>
    /// مدعی نقش
    /// </summary>
    [Table("Variables", Schema = "Constance"), Description("متغییر ها")]
    public class VariableEntity : BaseEntity
    {


        public string Key { get; set; }
        public string Value { get; set; }

        [ForeignKey(nameof(VariableEntity))]
        public long ParentId { get; set; }
        public VariableEntity Children { get; set; }
    }
}
