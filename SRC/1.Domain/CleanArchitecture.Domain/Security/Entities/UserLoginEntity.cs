﻿using CleanArchitecture.Domain.BasesDomain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Security.Entities;

[Table("UserLogin", Schema = "Security"), Description("ورود کاربر")]
public class UserLoginEntity : IdentityUserLogin<long>, IEntity<long>
{

    [Description("کلید")]
    public Guid Key { get; set; }

    [Description("کلید")]
    public long Id { get; set; }

}









