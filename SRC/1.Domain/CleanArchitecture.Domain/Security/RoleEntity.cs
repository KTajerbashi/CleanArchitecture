﻿using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Domain.BasesDomain.ValueObjects.BusinessId;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Security;

[Table("Roles", Schema = "Security"), Description("نقش ها")]
public class RoleEntity : IdentityRole<long>, IEntity<long>
{
    public RoleEntity() { }

    public RoleEntity(string name) { Name = name; }

    public RoleEntity(string name, string title) : this(name)
    {
        Title = title;
    }

    [Description("کلید")]
    public BusinessId Key { get; set; }

    [Description("عنوان نقش"), StringLength(100)]
    public string Title { get; set; }

    [Description("تاریخ آخرین ویرایش")]
    public DateTime? UpdateDate { get; set; }

    [Description("کاربر ویراش")]
    public long? UpdateBy { get; set; }

    [Description("حذف شده"), DefaultValue(false)]
    public bool IsDeleted { get; set; }

    [Description("فعال"), DefaultValue(false)]
    public bool IsActive { get; set; }

    public override string ToString()
    {
        return $"{Title} ({Name})";
    }
}









