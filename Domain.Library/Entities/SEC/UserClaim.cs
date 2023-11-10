using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("UserClaim", Schema = "SEC"), Description("مدعی کاربر")]
    public class UserClaim : IdentityUserClaim<long>
    {
    }
}
