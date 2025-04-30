using CleanArchitecture.Core.Application.Library.Providers.UserManagement;
using CleanArchitecture.Core.Application.Library.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Service;

public class UserInfoService : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ClaimsPrincipal? _user;

    public UserInfoService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _user = _httpContextAccessor.HttpContext?.User;
    }

    public string Name => GetClaimValue("Name");
    public string Family => GetClaimValue("Family");
    public string DisplayName => $"{Name} {Family}".Trim();
    public long UserId => GetClaimValueAsLong("UserId");
    public long UserRoleId => GetClaimValueAsLong("UserRoleId");
    public string RoleName => GetClaimValue("Role");
    public string RoleTitle => GetClaimValue("RoleTitle");
    public string Ip => _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
    public string Agent => GetClaimValue("Agent");
    public Dictionary<long, string> RolesName => GetRoles();
    public string Username => GetClaimValue("Username");
    public string Email => GetClaimValue("Email");

    private string GetClaimValue(string claimType)
    {
        if (_user is null)
            return string.Empty;

        return _user.FindFirstValue(claimType) ?? string.Empty;
    }

    private long GetClaimValueAsLong(string claimType)
    {
        var value = GetClaimValue(claimType);
        return string.IsNullOrEmpty(value) ? 0 : value.ToLong();
    }

    private Dictionary<long, string> GetRoles()
    {
        var roles = new Dictionary<long, string>();

        if (_user is null)
            return roles;

        var roleClaims = _user.FindAll(ClaimTypes.Role);
        foreach (var claim in roleClaims)
        {
            if (long.TryParse(claim.Value, out var roleId))
            {
                roles[roleId] = claim.Value;
            }
        }

        return roles;
    }
}