using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("UserLogin", Schema = "SEC"), Description("ورود کاربر")]
    public class UserLogin : IdentityUserLogin<long>
    {

        [Description("کلید")]
        public Guid Guid { get; set; }

        [Description("حذف شده"), DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Description("فعال"), DefaultValue(false)]
        public bool IsActive { get; set; }
    }
}
