using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("UserClaim", Schema = "SEC"), Description("مدعی کاربر")]
    public class UserClaim : IdentityUserClaim<long>
    {

        [Description("کلید")]
        public Guid Guid { get; set; }

        [Description("حذف شده"), DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Description("فعال"), DefaultValue(false)]
        public bool IsActive { get; set; }
    }
}
