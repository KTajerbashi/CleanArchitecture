using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("UserLogin", Schema = "SEC"), Description("ورود کاربر")]
    public class UserLogin : IdentityUserLogin<long>
    {
    }
}
