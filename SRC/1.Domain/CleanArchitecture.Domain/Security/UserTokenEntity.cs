﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Security;

/// <summary>
/// توکن کاربر
/// </summary>
[Table("UserToken", Schema = "Security"), Description("توکن کاربر")]
public class UserTokenEntity : IdentityUserToken<long>
{
    [Description("کلید")]
    public Guid Guid { get; set; }
    [Description("فعال")]
    public bool IsActive { get; set; }
    [Description("حذف شده"), DefaultValue(false)]
    public bool IsDeleted { get; set; }
}









