using CleanArchitecture.Core.Application.Library.Providers.HangfireBackgroundTask;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace CleanArchitecture.Infra.SqlServer.Library.Providers.HangfireBackgroundTask;

public static class DependencyInjection
{
    public static IServiceCollection AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add Hangfire services
        services.AddHangfire(config =>
        {
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage(); // For development

            // For production, use SQL Server:
            // .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"));
        });

        // Add Hangfire server
        services.AddHangfireServer(options =>
        {
            options.ServerName = "CleanArchitecture.Hangfire";
            options.Queues = new[] { "default" };
        });

        services.AddScoped<IBackgroundJobService, BackgroundJobService>();

        return services;
    }

    public static WebApplication UseHangfireServices(this WebApplication app)
    {
        // Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                DashboardTitle = "CleanArchitecture Jobs Dashboard",
                Authorization = new[] { new HangfireAuthorizationFilter() }
            });
        }

        return app;
    }
}
