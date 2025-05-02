namespace CleanArchitecture.Core.Domain.Library.UseCases.Security;

[Table("Roles", Schema = "Security"), Description("Roles Entity Model")]
public class AppRoleEntity : BaseAuditableEntity
{
    public string? Title { get; private set; }
    public string? Name { get; private set; }
    public string NormalizedName { get; private set; }
    private List<AppUserRoleEntity>? _userRoleEntities;
    public virtual IReadOnlyCollection<AppUserRoleEntity> UserRoleEntities => _userRoleEntities!;


    private AppRoleEntity()
    {
        
    }
    public AppRoleEntity(string title,string name)
    {
        Title = title; 
        Name = name;
        NormalizedName = name.ToUpper();
    }
}


