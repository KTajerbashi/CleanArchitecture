using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace BackgroundTaskProvider.HangfireProvider.Filters;

public class AuthenticationHangfireFilter : IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] DashboardContext context)
    {
        return context.GetHttpContext().User.Identity.IsAuthenticated;
    }
}
