using CleanArchitecture.Core.Domain.Library.Common;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Core.Domain.Library.Identity;

public class UserClaimEntity : IdentityUserClaim<long>, IAuditableEntity<long>
{

    public DateTime CreatedDate { get; private set; }

    public long CreatedByUserRoleId { get; private set; }

    public DateTime? UpdatedDate { get; private set; }

    public long UpdatedByUserRoleId { get; private set; }

    public Guid EntityId { get; private set; }
    public long Id { get; private set; }

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
    public UserClaimEntity()
    {
        
    }
}
