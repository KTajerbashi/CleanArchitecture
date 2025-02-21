﻿
namespace CleanArchitecture.Core.Domain.Library.Entities.Security;
[Table("Users",Schema ="Security"),Description("User Entity Model")]
public class AppUserEntity : BaseAuditableEntity
{
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string DisplayName { get; private set; }
    public string PersonalCode { get; private set; }

    private List<AppUserRoleEntity>? _userRoleEntities;
    public virtual IReadOnlyCollection<AppUserRoleEntity> UserRoleEntities => _userRoleEntities!;
}


