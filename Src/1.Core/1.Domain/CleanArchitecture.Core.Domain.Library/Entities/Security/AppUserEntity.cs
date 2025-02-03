using CleanArchitecture.Core.Domain.Library.Common;

namespace CleanArchitecture.Core.Domain.Library.Entities.Security;

public class AppUserEntity : BaseAuditableEntity
{
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string DisplayName { get; private set; }
    public string PersonalCode { get; private set; }
}

public class RoleEntity : BaseAuditableEntity
{

}


public class UserRoleEntity : BaseAuditableEntity
{

}


