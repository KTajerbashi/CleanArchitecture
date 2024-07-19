using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Domain.Security.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Security.Entities;

[Table("Users", Schema = "Security"), Description("کاربران")]
public class UserEntity : IdentityUser<long>, IEntity<long>
{

    [Description("کلید")]
    public Guid Key { get; set; }

    [Description("نام"), StringLength(450)]
    public string FirstName { get; set; }

    [Description("نام خانوادگی"), StringLength(450)]
    public string LastName { get; set; }

    [NotMapped]
    public string DisplayName
    {
        get
        {
            var displayName = $"{FirstName} {LastName} ({UserName})";
            return string.IsNullOrWhiteSpace(displayName) ? UserName : displayName;
        }
    }

    [Description("جنسیت")]
    public GenderTypeEnum? Gender { get; set; }

    [Description("کد ملی"), StringLength(10)]
    public string NationalCode { get; set; }

    [Description("عکس")]
    public string AvatarFile { get; set; }

    [Description("امضا")]
    public string SignFile { get; set; }

    [Description("حذف شده"), DefaultValue(false)]
    public bool IsDeleted { get; set; }

    [Description("فعال"), DefaultValue(false)]
    public bool IsActive { get; set; }

    [Description("تاریخ و زمان آخرین تغییر")]
    public DateTime? UpdateDate { get; set; }

    [Description("کد کاربر آخرین تغییر")]
    public long? UpdateBy { get; set; }
}

