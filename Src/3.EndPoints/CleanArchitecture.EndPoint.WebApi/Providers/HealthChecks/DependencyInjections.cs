using HealthChecks.SqlServer;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace CleanArchitecture.EndPoint.WebApi.Providers.HealthChecks;

public static class DependencyInjections
{
    public static WebApplicationBuilder AddHealthCheckServices(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;
        // Configuration values
        var sqlConnection = configuration.GetConnectionString("DefaultConnection");
        var externalServiceUri = configuration["ExtenalApi:OpenId"];
        var userApiBaseUrl = configuration["BaseUrl"];

        // Required services
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddHttpClient();

        // Health Checks Registration
        builder.Services.AddHealthChecks()
            .AddSqlServer(new SqlServerHealthCheckOptions
            {
                ConnectionString = sqlConnection,
            })
            .AddTcpHealthCheck(option =>
            {
                var uri = new Uri(externalServiceUri);
                option.AddHost(uri.Host, uri.Port);
            })
            .AddCheck<UserApiHealthCheck>("UserApi")
            .AddUrlGroup(new Uri($"{userApiBaseUrl}/index.html"), "Swagger")
            ;

        // Health Checks UI Configuration
        builder.Services.AddHealthChecksUI(setup =>
        {
            setup.AddHealthCheckEndpoint("API Health", "/health");
            setup.SetEvaluationTimeInSeconds(30);
            setup.SetMinimumSecondsBetweenFailureNotifications(60);
            setup.MaximumHistoryEntriesPerEndpoint(50);
        }).AddInMemoryStorage();

        // Named HTTP Client for User API
        builder.Services.AddHttpClient("UserApi", client =>
        {
            client.BaseAddress = new Uri(userApiBaseUrl);
        });

        return builder;
    }


    private static string GetBaseUrl(IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var config = provider.GetRequiredService<IConfiguration>();

        // Try to get from configuration first
        var configuredUrl = config["BaseUrl"];
        if (!string.IsNullOrWhiteSpace(configuredUrl))
        {
            return configuredUrl.TrimEnd('/');
        }

        // Fall back to request context
        var httpContextAccessor = provider.GetService<IHttpContextAccessor>();
        var request = httpContextAccessor?.HttpContext?.Request;

        if (request != null)
        {
            return $"{request.Scheme}://{request.Host}";
        }

        // Default fallback (adjust for your environment)
        return "https://localhost:2235";
    }

    public static WebApplication UseHealthCheckServices(this WebApplication app)
    {
        // Health Check Endpoint
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        // Health Check UI Dashboard
        app.MapHealthChecksUI(options =>
        {
            options.UIPath = "/health-dashboard";
            options.AddCustomStylesheet("wwwroot/assets/css/healthchecks.css");
        });

        return app;
    }
}







