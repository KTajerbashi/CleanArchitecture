using BackgroundTaskProvider.HangfireProvider.Filters;
using BackgroundTaskProvider.HangfireProvider.Services;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackgroundTaskProvider.HangfireProvider.Extension;

public static class HangfireExtension
{
    public static IServiceCollection AddHangfireService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(option => option
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"),
                    new SqlServerStorageOptions
                    {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        DisableGlobalLocks = true
                    }
                ));
        services.AddHangfireServer();
        services.AddScoped<BackgroundTaskService>();

        return services;
    }

    public static void UseHangfire(this WebApplication app)
    {
        var Configuration = app.Configuration;

        app.UseHangfireServer();

        app.UseHangfireDashboard("/dashboard", new DashboardOptions
        {
            DashboardTitle = "Dashboard CleanArchitecture"
        });

        app.UseHangfireDashboard("/dashboard.admin", new DashboardOptions
        {
            Authorization = new[] { new AuthenticationHangfireFilter() }
        });
    }
}
