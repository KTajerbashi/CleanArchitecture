using CleanArchitecture.Domain.BasesDomain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Security.Entities;

[Table("UserClaim", Schema = "Security"), Description("مدعی کاربر")]
public class UserClaimEntity : IdentityUserClaim<long>, IEntity<int>
{

    [Description("کلید")]
    public Guid Key { get; set; }

}









