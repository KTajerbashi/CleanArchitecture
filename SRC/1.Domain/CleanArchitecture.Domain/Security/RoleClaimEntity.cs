using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Domain.BasesDomain.ValueObjects.BusinessId;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Security;

/// <summary>
/// مدعی نقش
/// </summary>
[Table("RoleClaim", Schema = "Security"), Description("مدعی نقش")]
public class RoleClaimEntity : IdentityRoleClaim<long>, IEntity<int>
{
    [Description("کلید")]
    public BusinessId Key { get; set; }

    [Description("حذف شده"), DefaultValue(false)]
    public bool IsDeleted { get; set; }

    [Description("فعال"), DefaultValue(false)]
    public bool IsActive { get; set; }


}









