namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;

public class RoleEntity : IdentityRole<long>, IAuditableEntity<long>
{
    public DateTime CreatedDate { get; private set; }

    public long CreatedByUserRoleId { get; private set; }

    public DateTime? UpdatedDate { get; private set; }

    public long? UpdatedByUserRoleId { get; private set; }

    public EntityId EntityId { get; private set; } = Guid.NewGuid();

    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }
    public string Title { get; private set; }
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
    public RoleEntity()
    {
        IsActive = true;
        IsDeleted = false;
    }
    public RoleEntity(string name,string title)
    {
        Name = name;
        Title = title;
    }
}
