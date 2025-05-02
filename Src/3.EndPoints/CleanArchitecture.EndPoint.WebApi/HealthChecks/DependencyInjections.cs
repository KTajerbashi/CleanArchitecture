using CleanArchitecture.Infra.SqlServer.Library.Data.Constants;
using HealthChecks.SqlServer;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json.Serialization;

namespace CleanArchitecture.EndPoint.WebApi.HealthChecks;

public static class DependencyInjections
{
    public static WebApplicationBuilder AddHealthCheckServices(this WebApplicationBuilder builder)
    {
        // Configuration values
        var sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
        var externalServiceUri = builder.Configuration["ExtenalApi:OpenId"];
        var userApiBaseUrl = builder.Configuration["UserApi:BaseUrl"] ?? "https://localhost:2235";

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
            //.AddControllerHealthChecks(builder.Services)
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

    //public static IHealthChecksBuilder AddControllerHealthChecks(
    //   this IHealthChecksBuilder builder,
    //   IServiceCollection services)
    //{
    //    try
    //    {
    //        var assembly = Assembly.GetExecutingAssembly();
    //        var baseUrl = GetBaseUrl(services);

    //        if (string.IsNullOrWhiteSpace(baseUrl))
    //        {
    //            throw new InvalidOperationException("Base URL could not be determined");
    //        }

    //        foreach (var controllerType in assembly.GetTypes()
    //            .Where(t => typeof(BaseController).IsAssignableFrom(t)))
    //        {
    //            var controllerRoute = controllerType.GetCustomAttribute<RouteAttribute>()?.Template?.Trim('/');

    //            foreach (var method in controllerType.GetMethods()
    //                .Where(m => m.GetCustomAttributes<HealthCheckAttribute>().Any()))
    //            {
    //                var attr = method.GetCustomAttribute<HealthCheckAttribute>();
    //                var methodRoute = method.GetCustomAttribute<RouteAttribute>()?.Template?.Trim('/');

    //                // Skip if no route attributes found
    //                if (controllerRoute == null && methodRoute == null)
    //                {
    //                    continue;
    //                }

    //                // Build the full path
    //                var pathParts = new List<string>();
    //                if (!string.IsNullOrEmpty(controllerRoute)) pathParts.Add(controllerRoute);
    //                if (!string.IsNullOrEmpty(methodRoute)) pathParts.Add(methodRoute);
    //                var fullPath = string.Join("/", pathParts);

    //                if (string.IsNullOrEmpty(fullPath))
    //                {
    //                    continue;
    //                }

    //                // Ensure the base URL ends with a slash
    //                if (!baseUrl.EndsWith("/"))
    //                {
    //                    baseUrl += "/";
    //                }

    //                // Construct and validate the full URL
    //                var fullUrl = $"{baseUrl}{fullPath}";
    //                if (!Uri.TryCreate(fullUrl, UriKind.Absolute, out var uri))
    //                {
    //                    continue; // Skip invalid URLs
    //                }

    //                builder.AddUrlGroup(
    //                    uri: uri,
    //                    name: attr.Name,
    //                    failureStatus: HealthStatus.Degraded,
    //                    tags: attr.Tags,
    //                    timeout: TimeSpan.FromSeconds(attr.TimeoutInSeconds));
    //            }
    //        }

    //        return builder;
    //    }
    //    catch (Exception ex)
    //    {
    //        // Log the error or handle it appropriately
    //        Console.WriteLine($"Error registering health checks: {ex.Message}");
    //        return builder;
    //    }
    //}

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







