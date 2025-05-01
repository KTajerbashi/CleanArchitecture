using CleanArchitecture.Core.Domain.Library.Common;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities.Parameters;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;

public class UserTokenEntity : IdentityUserToken<long>, IAuditableEntity<long>
{

    public DateTime CreatedDate { get; private set; }

    public long CreatedByUserRoleId { get; private set; }

    public DateTime? UpdatedDate { get; private set; }

    public long? UpdatedByUserRoleId { get; private set; }

    public EntityId EntityId { get; private set; } = Guid.NewGuid();
    public long Id { get; private set; }

    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }

    public string RefreshToken { get; private set; }
    public void SetToken(string refToken) => RefreshToken = refToken;

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
    public UserTokenEntity()
    {

    }
    public UserTokenEntity(UserTokenParameters parameters)
    {
        UserId = parameters.UserId;
        LoginProvider = parameters.LoginProvider;
        Name = parameters.Name;
        Value = parameters.Value;
        RefreshToken = parameters.RefreshToken;
    }
}
