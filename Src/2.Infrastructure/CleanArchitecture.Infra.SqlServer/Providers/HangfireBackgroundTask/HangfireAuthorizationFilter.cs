using Hangfire.Dashboard;

namespace CleanArchitecture.Infra.SqlServer.Providers.HangfireBackgroundTask;


public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    private readonly IEnumerable<RoleAccessSettings> _roleAccess;

    public HangfireAuthorizationFilter(IEnumerable<RoleAccessSettings> roleAccess)
    {
        _roleAccess = roleAccess;
    }

    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        if (!httpContext.User.Identity?.IsAuthenticated ?? true)
            return false;

        var userRoles = _roleAccess.Where(x => x.Enabled).Select(x => x.Role).ToList();
        return userRoles.Any(role => httpContext.User.IsInRole(role));
    }
}




