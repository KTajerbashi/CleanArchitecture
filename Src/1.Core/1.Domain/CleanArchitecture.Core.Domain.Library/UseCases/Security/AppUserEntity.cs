using CleanArchitecture.Core.Domain.Library.UseCases.Security.Parameters;
using System.Security.Cryptography;

namespace CleanArchitecture.Core.Domain.Library.UseCases.Security;
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
    //public string? ConcurrencyStamp { get; set; }
    public string PhoneNumber { get; private set; }
    public bool PhoneNumberConfirmed { get; private set; }
    public bool TwoFactorEnabled { get; private set; }
    public DateTime? LockoutEnd { get; private set; }
    public bool LockoutEnabled { get; private set; }
    public int AccessFailedCount { get; private set; }

    private List<AppUserRoleEntity>? _userRoleEntities;
    public virtual IReadOnlyCollection<AppUserRoleEntity> UserRoleEntities => _userRoleEntities!;

    private AppUserEntity()
    {

    }

    public AppUserEntity(AppUserCreateParameters parameters)
    {
        Name = parameters.Name;
        Family = parameters.Family;
        PersonalCode = parameters.PersonalCode;
        UserName = parameters.UserName;
        NormalizedUserName = UserName.ToUpper();
        Email = parameters.Email;
        NormalizedEmail = Email.ToUpper();
        PhoneNumber = parameters.PhoneNumber;

    }

    public void SetPassword(string securityStamp,string passwordHash,string concurrencyStamp)
    {
        SecurityStamp = securityStamp;
        PasswordHash = passwordHash;
        //ConcurrencyStamp = concurrencyStamp;
    }

    public void AddUserRole(AppUserRoleEntity entity)
    {
        if (_userRoleEntities is null)
        {
            _userRoleEntities = new();
        }
        _userRoleEntities.Add(entity);
    }
 
}


