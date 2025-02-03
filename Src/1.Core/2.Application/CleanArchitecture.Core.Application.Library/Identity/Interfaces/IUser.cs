namespace CleanArchitecture.Core.Application.Library.Identity.Interfaces;

public interface IUser
{
    string Name { get; }
    string Family { get; }
    string DisplayName { get; }
    long UserId { get; }
    long UserRoleId { get; }
    long RoleName { get; }
    long RoleTitle { get; }
    string Ip { get; }
    string Agent { get; }
    Dictionary<long, string> RolesName { get; }
}
