using CleanArchitecture.Core.Domain.Library.Common;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;

[Table("Users", Schema = "Identity")]
public class UserEntity : IdentityUser<long>, IAuditableEntity<long>
{

    [Description("")]
    public string? Name { get; private set; }
    [Description("")]
    public string? Family { get; private set; }
    [Description("")]
    public string? DisplayName { get; private set; }
    [Description("")]
    public string? PersonalCode { get; private set; }

    [Description("")]
    public DateTime CreatedDate { get; private set; }
    [Description("")]
    public long CreatedByUserRoleId { get; private set; }
    [Description("")]
    public DateTime? UpdatedDate { get; private set; }
    [Description("")]
    public long UpdatedByUserRoleId { get; private set; }
    [Description("")]
    public Guid EntityId { get; private set; }

    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }

    public void Access()
    {
        IsActive = true;
        IsDeleted = false;
    }
    public void Delete()
    {
        IsActive = false;
        IsDeleted = true;
    }
    public UserEntity()
    {

    }

}
