namespace CleanArchitecture.Core.Domain.Library.UseCases.Security;

[Table("UserRoles", Schema = "Security"), Description("User Role Entity Model")]
public class AppUserRoleEntity : BaseAuditableEntity
{
    [ForeignKey(nameof(AppUserEntity))]
    public virtual long UserId { get; set; }
    public virtual AppUserEntity AppUserEntity { get; set; }

    [ForeignKey(nameof(AppRoleEntity))]
    public virtual long RoleId { get; set; }
    public virtual AppRoleEntity AppRoleEntity { get; set; }


    private AppUserRoleEntity()
    {
        
    }

    public AppUserRoleEntity(long userId,long roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
    public void SetId(long id) => Id = id;
}


