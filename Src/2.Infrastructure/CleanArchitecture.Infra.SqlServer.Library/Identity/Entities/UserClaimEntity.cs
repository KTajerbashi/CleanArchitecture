﻿namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;

public class UserClaimEntity : IdentityUserClaim<long>, IAuditableEntity<long>
{

    public long Id { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public long CreatedByUserRoleId { get; private set; }

    public DateTime? UpdatedDate { get; private set; }

    public long? UpdatedByUserRoleId { get; private set; }

    public EntityId EntityId { get; private set; } = Guid.NewGuid();

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
