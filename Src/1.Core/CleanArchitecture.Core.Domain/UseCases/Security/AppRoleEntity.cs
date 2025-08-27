using CleanArchitecture.Core.Domain.Common;

namespace CleanArchitecture.Core.Domain.UseCases.Security;

[Table("Roles", Schema = "Security"), Description("Roles Entity Model")]
public class AppRoleEntity : BaseAuditableEntity
{
    public string? Title { get; private set; }
    public string? Name { get; private set; }
    public string? NormalizedName { get; private set; }
    public string? ConcurrencyStamp { get;private set; }
    private List<AppUserRoleEntity>? _userRoleEntities;
    public virtual IReadOnlyCollection<AppUserRoleEntity> UserRoleEntities => _userRoleEntities!;

    public bool IsActive { get; }
    public bool IsDeleted { get; }

    private AppRoleEntity()
    {

    }
    public AppRoleEntity(string title, string name)
    {
        Title = title;
        Name = name;
        NormalizedName = name.ToUpper();
    }

    public AppRoleEntity(long id, string name, string normalizedName, string concurrencyStamp, string title, bool isActive, bool isDeleted)
    {
        Id = id;
        Name = name;
        NormalizedName = normalizedName;
        ConcurrencyStamp = concurrencyStamp;
        Title = title;
        IsActive = isActive;
        IsDeleted = isDeleted;
    }

    public void SetId(long id) => Id = id;
}


