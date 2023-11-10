using Domain.Library.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.CNT
{
    [Table("MenuLinks", Schema = "CNT"), Description("منو")]
    public class MenuLink : GeneralEntity
    {
        [ForeignKey(nameof(MenuLink))]
        public long? ParentId { get; set; }
        public MenuLink MenuLinkChild { get; set; }

        public string Route { get; set; }
        public string Icon { get; set; }
        public bool IsPublic { get; set; }
        public int Order { get; set; }
        public ICollection<MenuRole> MenuRoles { get; set; }
    }
    public class MenuLinkConfiguration : IEntityTypeConfiguration<MenuLink>
    {
        public void Configure(EntityTypeBuilder<MenuLink> builder)
        {

            builder.HasMany(x => x.MenuRoles)
                .WithOne(x => x.MenuLink)
                .HasForeignKey(x => x.ID);
        }
    }
}
