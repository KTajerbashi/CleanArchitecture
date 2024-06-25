using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Domain.BasesDomain.ValueObjects.BusinessId;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Security;

[Table("UserRoles", Schema = "Security"), Description("نقش کاربران")]
public class UserRoleEntity : IdentityUserRole<long>, IEntity<long>
{
    [Description("کلید")]
    public BusinessId Key { get; set; }

    [Description("کلید")]
    [NotMapped]
    public long Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("کد")]
    public long ID { get; set; }

    [Description("تاریخ شروع")]
    public DateTime? StartDate { get; set; }

    [Description("تاریخ پایان")]
    public DateTime? EndDate { get; set; }

    [Description("پیش فرض")]
    public bool IsDefault { get; set; }

    [Description("فعال")]
    public bool IsActive { get; set; }
    [Description("حذف شده"), DefaultValue(false)]
    public bool IsDeleted { get; set; }

}









