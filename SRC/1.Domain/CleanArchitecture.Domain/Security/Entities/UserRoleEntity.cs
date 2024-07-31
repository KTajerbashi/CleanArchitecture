using CleanArchitecture.Domain.BasesDomain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Security.Entities;

[Table("UserRoles", Schema = "Security"), Description("نقش کاربران")]
public class UserRoleEntity : IdentityUserRole<long>, IEntity<long>
{
    [Description("کلید")]
    public Guid Key { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("کد")]
    public long Id { get; set; }

    [Description("نقش پیشفرض")]
    public bool IsDefault { get; set; }

    [Description("تاریخ شروع")]
    public DateTime? StartDate { get; set; }

    [Description("تاریخ پایان")]
    public DateTime? EndDate { get; set; }


}









