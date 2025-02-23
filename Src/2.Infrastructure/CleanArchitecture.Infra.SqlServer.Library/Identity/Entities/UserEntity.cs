using CleanArchitecture.Core.Domain.Library.Common;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;
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
    public long? UpdatedByUserRoleId { get; private set; }
    [Description("")]
    public Guid EntityId { get; private set; } = Guid.NewGuid();

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
    private UserEntity()
    {

    }
    public UserEntity(UserCreateParameters parameters)
    {
        Name = parameters.Name;
        Family = parameters.Family;
        DisplayName = parameters.DisplayName;
        PersonalCode = parameters.PersonalCode;
        Email = parameters.Email;
        UserName = parameters.UserName;
        PhoneNumber = parameters.PhoneNumber;
    }

}
