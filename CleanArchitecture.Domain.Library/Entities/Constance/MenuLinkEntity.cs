using CleanArchitecture.Domain.Library.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CleanArchitecture.Domain.Library.Entities.Constance
{
    /// <summary>
    /// منو بار
    /// </summary>
    [Table("MenuLinks", Schema = "Constance"), Description("منو بار")]
    public class MenuLinkEntity : GeneralEntity
    {

        public string Icon { get; set; }
        public string Link { get; set; }

        [ForeignKey(nameof(Children))]
        public long ParentId { get; set; }
        public MenuLinkEntity Children { get; set; }
    }
}
