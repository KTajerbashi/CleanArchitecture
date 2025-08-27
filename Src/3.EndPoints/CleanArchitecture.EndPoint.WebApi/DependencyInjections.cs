using CleanArchitecture.Core.Application;
using CleanArchitecture.Core.Application.Utilities.Extensions;
using CleanArchitecture.EndPoint.WebApi.Middlewares.AuthorizedHandler;
using CleanArchitecture.EndPoint.WebApi.Middlewares.ExceptionHandler;
using CleanArchitecture.EndPoint.WebApi.Providers;
using CleanArchitecture.EndPoint.WebApi.Providers.Excel;
using CleanArchitecture.EndPoint.WebApi.Providers.HealthChecks;
using CleanArchitecture.EndPoint.WebApi.Providers.MonitoringApp;
using CleanArchitecture.Infra.SqlServer;
using CleanArchitecture.Infra.SqlServer.Data;

namespace CleanArchitecture.EndPoint.WebApi;

public static class DependencyInjections
{
    public static WebApplication WebApplicationBuilder(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
            configuration.WriteTo.Console();
            configuration.WriteTo.File(string.Format("./Logs/File_{0}.txt", DateTime.Now.ToString("yyyy_MM_dd")));
        });

        builder.AddHealthCheckServices();
        builder.AddMonitoringAppServices();

        // Add required services
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddHttpClient();

        var assemblies = ("CleanArchitecture").GetAssemblies().ToArray();

        builder.Services.AddApplicationLibrary(configuration, assemblies);

        builder.Services.AddInfrastructureLibrary(configuration, assemblies);

        builder.Services.AddEPPlusExcelSerializer();
        //  Hangfire
        //builder.Services.AddHangfireServices(configuration);

        //builder.Services.RegisterHostedService();

        //builder.Services.AddHostedService<MessageBrokerHost>();

        builder.Services.AddControllers();

        builder.Services.AddOpenApi();

        builder.Services.AddIdentity(configuration, "IdentityOption");

        builder.Services.AddSwaggerService();

        //builder.Services.AddValidatorsFromAssemblyContaining<Program>();

        builder.Services.AddValidatorsFromAssemblies(assemblies);

        return builder.Build();
    }
    public static async Task<WebApplication> ConfigurePipeline(this WebApplication app)
    {
        // Development-only services
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerService();
            app.MapOpenApi(); // Only map OpenAPI in development
        }

        // Exception handling
        app.UseExceptionMiddleware(); // Custom middleware should be early
                                      // app.UseExceptionHandler(); // Uncomment if using the built-in exception page

        // Health checks and monitoring
        app.UseHealthCheckServices();
        app.UseMonitoringAppServices();

        // Static files and HTTPS redirection
        app.UseStaticFiles();
        app.UseHttpsRedirection();

        // Logging
        app.UseSerilogRequestLogging();

        // Session
        app.UseSession();

        // Routing and endpoint middleware
        app.UseRouting();

        // Authentication/Authorization
        app.UseAuthentication(); // Authentication must come before Authorization
        app.UseAuthorization();

        // Custom authorization middleware
        app.UseAuthorizedMiddleware();

        // Hangfire dashboard setup
        //app.UseHangfireServices(); // Should be placed after auth if it relies on it

        // Controllers and endpoints
        app.MapControllers();

        // SPA fallback
        app.MapFallbackToFile("index.html");

        // Initialize the database (should be done after services are configured)
        await app.InitialiseDatabaseAsync();

        return app;
    }

}
