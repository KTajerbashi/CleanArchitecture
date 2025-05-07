using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace CleanArchitecture.Infra.SqlServer.Library.Providers.HangfireBackgroundTask;

public static class HangfireDependencyInjection
{
    public static IServiceCollection AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
    {
        var hangfireSettings = configuration.GetSection("Hangfire").Get<HangfireSettings>();
        services.Configure<HangfireSettings>(configuration.GetSection("Hangfire"));

        if (hangfireSettings?.Enable == true)
        {
            services.AddHangfire(config =>
                config.UseSqlServerStorage(hangfireSettings.ConnectionString, new Hangfire.SqlServer.SqlServerStorageOptions
                {
                    SchemaName = hangfireSettings.SchemaName
                }));

            services.AddHangfireServer();
        }

        return services;
    }

    public static WebApplication UseHangfireServices(this WebApplication app)
    {


        var hangfireSettings = app.Services.GetRequiredService<IOptions<HangfireSettings>>().Value;

        if (hangfireSettings.Enable)
        {
            app.UseHangfireDashboard(hangfireSettings.Dashboard.BaseUrl, new DashboardOptions
            {
                DashboardTitle = hangfireSettings.Dashboard.Title,
                StatsPollingInterval = hangfireSettings.Dashboard.StatsPollingIntervalMs,
                DisplayStorageConnectionString = hangfireSettings.Dashboard.DisplayConnectionString,
                Authorization = new[] { new HangfireAuthorizationFilter(hangfireSettings.Dashboard.RoleAccess) }
            });
            var adminDashboard = hangfireSettings.Dashboard.RoleAccess.First(item => item.Role == "Administrator");
            if (adminDashboard.Enabled)
            {
                app.UseHangfireDashboard(adminDashboard.Path, new DashboardOptions
                {
                    DashboardTitle = adminDashboard.Title,
                    StatsPollingInterval = hangfireSettings.Dashboard.StatsPollingIntervalMs,
                    DisplayStorageConnectionString = hangfireSettings.Dashboard.DisplayConnectionString,
                    Authorization = new[] { new HangfireAuthorizationFilter([adminDashboard]) }
                });

            }

            var userDashbaord = hangfireSettings.Dashboard.RoleAccess.First(item => item.Role == "User");
            if (userDashbaord.Enabled)
            {
                app.UseHangfireDashboard(userDashbaord.Path, new DashboardOptions
                {
                    DashboardTitle = userDashbaord.Title,
                    StatsPollingInterval = hangfireSettings.Dashboard.StatsPollingIntervalMs,
                    DisplayStorageConnectionString = hangfireSettings.Dashboard.DisplayConnectionString,
                    Authorization = new[] { new HangfireAuthorizationFilter([userDashbaord]) }
                });
            }
        }

        app.MapHangfireDashboard();
        return app;
    }

}

