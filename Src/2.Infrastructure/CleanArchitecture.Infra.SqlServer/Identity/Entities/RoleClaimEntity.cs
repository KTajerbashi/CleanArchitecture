using CleanArchitecture.Core.Domain.Common;

namespace CleanArchitecture.Infra.SqlServer.Identity.Entities;

public class RoleClaimEntity : IdentityRoleClaim<long>, IAuditableEntity<int>
{
    public EntityId EntityId { get; private set; } = Guid.NewGuid();

    public DateTime CreatedDate { get; private set; }
    public int CreatedByUserRoleId { get; private set; }

    public DateTime? UpdatedDate { get; private set; }
    public int? UpdatedByUserRoleId { get; private set; }

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
    public RoleClaimEntity()
    {

    }
}
