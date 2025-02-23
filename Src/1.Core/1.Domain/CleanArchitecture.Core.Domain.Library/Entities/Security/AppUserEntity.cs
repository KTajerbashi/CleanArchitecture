
namespace CleanArchitecture.Core.Domain.Library.Entities.Security;
[Table("Users", Schema = "Security"), Description("User Entity Model")]
public class AppUserEntity : BaseAuditableEntity
{
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string DisplayName { get; private set; }
    public string PersonalCode { get; private set; }
    public string UserName { get; private set; }
    public string NormalizedUserName { get; private set; }
    public string Email { get; private set; }
    public string NormalizedEmail { get; private set; }
    public bool EmailConfirmed { get; private set; }
    public string PasswordHash { get; private set; }
    public string SecurityStamp { get; private set; }
    public string ConcurrencyStamp { get; private set; }
    public string PhoneNumber { get; private set; }
    public bool PhoneNumberConfirmed { get; private set; }
    public bool TwoFactorEnabled { get; private set; }
    public DateTime? LockoutEnd { get; private set; }
    public bool LockoutEnabled { get; private set; }
    public int AccessFailedCount { get; private set; }

    private List<AppUserRoleEntity>? _userRoleEntities;
    public virtual IReadOnlyCollection<AppUserRoleEntity> UserRoleEntities => _userRoleEntities!;
}


