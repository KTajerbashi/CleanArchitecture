using Domain.Library.Entities.CNT;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace Domain.Library.Entities.SEC
{
    [Table("Roles", Schema = "SEC"), Description("نقش ها")]
    public class Role : IdentityRole<long>
    {
        [Description("کلید")]
        public Guid Guid { get; set; }
        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
        }

        public Role(string name, string title)
            : this(name)
        {
            Title = title;
        }

        [Description("عنوان نقش"), StringLength(100)]
        public string Title { get; set; }

        [Description("تاریخ آخرین ویرایش")]
        public DateTime? UpdateDate { get; set; }

        [Description("کاربر ویراش")]
        public long? UpdateBy { get; set; }

        public ICollection<MenuRole> MenuRoles { get; set; }

        //#region Relation
        //public virtual ICollection<UserRole> Users { get; set; }

        //public virtual ICollection<RoleClaim> Claims { get; set; }
        //#endregion
        public override string ToString()
        {
            return $"{Title} ({Name})";
        }
    }
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(m => m.MenuRoles)
                .WithOne(r => r.Role);
        }
    }
}
