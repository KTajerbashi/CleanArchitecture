using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("UserRoles", Schema = "SEC"), Description("نقش کاربران")]
    public class UserRole : IdentityUserRole<long>
    {
        [Description("کلید")]
        public Guid Guid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("کد")]
        public long ID { get; set; }

        [Description("تاریخ شروع")]
        public DateTime? StartDate { get; set; }

        [Description("تاریخ پایان")]
        public DateTime? EndDate { get; set; }

        [Description("پیش فرض")]
        public bool IsDefault { get; set; }

        [Description("فعال")]
        public bool IsActive { get; set; }
        [Description("حذف شده"), DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
