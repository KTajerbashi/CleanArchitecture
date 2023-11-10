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
    }
}
