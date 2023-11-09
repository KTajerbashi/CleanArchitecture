using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("Users", Schema = "SEC")]
    public class User : IdentityUser
    {
    }
    [Table("Roles", Schema = "SEC")]
    public class Role : IdentityRole
    {
    }
    [Table("UserRoles", Schema = "SEC")]
    public class UserRole : IdentityUserRole<long>
    {
    }
}
