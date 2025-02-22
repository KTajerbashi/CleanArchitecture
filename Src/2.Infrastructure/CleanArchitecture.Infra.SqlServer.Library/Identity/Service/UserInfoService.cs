using CleanArchitecture.Core.Application.Library.Identity.Interfaces;
using CleanArchitecture.Core.Application.Library.Utilities.Extensions;
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

    private string getValue(string name)
    {
        return $"0844";
    }
    private Dictionary<long, string> getRolesName()
    {
        return new Dictionary<long, string>();
    }
}
