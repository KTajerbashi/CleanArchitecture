using CleanArchitecture.Domain.BasesDomain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Security.Entities;

/// <summary>
/// مدعی نقش
/// </summary>
[Table("RoleClaim", Schema = "Security"), Description("مدعی نقش")]
public class RoleClaimEntity : IdentityRoleClaim<long>, IEntity<int>
{
    [Description("کلید")]
    public Guid Key { get; set; }


}









