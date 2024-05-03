using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Library.Entities.Security
{
    [Table("UserLogin", Schema = "Security"), Description("ورود کاربر")]
    public class UserLoginEntity : IdentityUserLogin<long>
    {

        [Description("کلید")]
        public Guid Guid { get; set; }

        [Description("حذف شده"), DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Description("فعال"), DefaultValue(false)]
        public bool IsActive { get; set; }
    }
}
