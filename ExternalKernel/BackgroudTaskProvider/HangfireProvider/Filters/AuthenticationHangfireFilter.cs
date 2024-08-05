using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace BackgroundTaskProvider.HangfireProvider.Filters;

public class AuthenticationHangfireFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        // Allow only authenticated users to see the dashboard
        return httpContext.User.Identity?.IsAuthenticated ?? false;
    }
}
