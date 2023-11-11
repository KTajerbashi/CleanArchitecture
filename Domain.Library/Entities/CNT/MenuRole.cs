using Domain.Library.BaseEntities;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.CNT
{
    [Table("MenuRole", Schema = "CNT"), Description("دسترسی منو")]
    public class MenuRole : GeneralEntity
    {
        [ForeignKey("MenuLink")]
        public long MenuLinkID { get; set; }
        public virtual MenuLink MenuLink { get; set; }

        [ForeignKey("Role")]
        public long RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
    public class MenuRoleConfiguration : IEntityTypeConfiguration<MenuRole>
    {
        public void Configure(EntityTypeBuilder<MenuRole> builder)
        {
            builder.HasOne(x => x.MenuLink)
                .WithMany(x => x.MenuRoles)
                .HasForeignKey(x => x.MenuLinkID);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.MenuRoles)
                .HasForeignKey(x => x.RoleID);
        }
    }
}
