using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    /// <summary>
    /// توکن کاربر
    /// </summary>
    [Table("UserToken", Schema = "SEC"), Description("توکن کاربر")]
    public class UserToken : IdentityUserToken<long>
    {
        [Description("کلید")]
        public Guid Guid { get; set; }
        [Description("فعال")]
        public bool IsActive { get; set; }
        [Description("حذف شده"), DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
