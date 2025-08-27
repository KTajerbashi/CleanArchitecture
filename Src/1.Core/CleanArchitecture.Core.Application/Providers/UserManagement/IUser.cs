namespace CleanArchitecture.Core.Application.Providers.UserManagement;

public interface IUser
{
    string Name { get; }
    string Family { get; }
    string DisplayName { get; }
    long UserId { get; }
    long UserRoleId { get; }
    string RoleName { get; }
    string RoleTitle { get; }
    string Ip { get; }
    string Agent { get; }
    string Username { get; }
    string Email { get; }
    Dictionary<long, string> RolesName { get; }
}
