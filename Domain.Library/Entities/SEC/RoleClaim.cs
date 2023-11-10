using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    /// <summary>
    /// مدعی نقش
    /// </summary>
    [Table("RoleClaim", Schema = "SEC"), Description("مدعی نقش")]
    public class RoleClaim : IdentityRoleClaim<long>
    {
    }
}
