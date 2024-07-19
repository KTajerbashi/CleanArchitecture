using CleanArchitecture.Domain.BasesDomain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Constance.Entities;

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
