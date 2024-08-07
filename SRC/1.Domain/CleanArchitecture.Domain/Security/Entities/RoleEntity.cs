﻿using CleanArchitecture.Domain.BasesDomain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Security.Entities;

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
    public Guid Key { get; set; }

    [Description("عنوان نقش"), StringLength(100)]
    public string Title { get; set; }

    public override string ToString()
    {
        return $"{Title} ({Name})";
    }
}









