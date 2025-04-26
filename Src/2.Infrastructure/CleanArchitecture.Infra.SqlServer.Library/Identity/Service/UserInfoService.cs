using CleanArchitecture.Core.Application.Library.Providers.UserManagement;
using CleanArchitecture.Core.Application.Library.Utilities.Extensions;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Extensions;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Service;

public class UserInfoService : IUser
{
    private readonly IHttpContextAccessor? _httpContextAccessor;

    public UserInfoService(IHttpContextAccessor? httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string Name => getValue("Name");

    public string Family => getValue("Family");

    public string DisplayName => getValue("DisplayName");

    public long UserId => getValue("UserId").ToLong();

    public long UserRoleId => getValue("UserRoleId").ToLong();

    public long RoleName => getValue("RoleName").ToLong();

    public long RoleTitle => getValue("RoleTitle").ToLong();

    public string Ip => getValue("Ip");

    public string Agent => getValue("Agent");

    public Dictionary<long, string> RolesName => getRolesName();

    public string Username => getValue("Username");

    public string Email => getValue("Email");

    private string getValue(string name)
    {
        if (_httpContextAccessor is null) return "Accessor NULL";
        if (_httpContextAccessor.HttpContext is null) return "Context NULL";
        if (_httpContextAccessor.HttpContext.User is null) return "User NULL";
        return _httpContextAccessor!.HttpContext!.User.GetClaimValue(name)!;
    }
    private Dictionary<long, string> getRolesName()
    {
        return new Dictionary<long, string>();
    }
}
