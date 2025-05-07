using CleanArchitecture.Core.Application.Library;
using CleanArchitecture.Core.Application.Library.Utilities.Extensions;
using CleanArchitecture.EndPoint.WebApi.Middlewares.AuthorizedHandler;
using CleanArchitecture.EndPoint.WebApi.Middlewares.ExceptionHandler;
using CleanArchitecture.EndPoint.WebApi.Providers;
using CleanArchitecture.EndPoint.WebApi.Providers.HealthChecks;
using CleanArchitecture.EndPoint.WebApi.Providers.HostedServer;
using CleanArchitecture.EndPoint.WebApi.Providers.MonitoringApp;
using CleanArchitecture.Infra.SqlServer.Library;
using CleanArchitecture.Infra.SqlServer.Library.Data;
using CleanArchitecture.Infra.SqlServer.Library.Providers.HangfireBackgroundTask;
using FluentValidation;
using Hangfire;
using Serilog;

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
        //  Hangfire
        builder.Services.AddHangfireServices(configuration);
        
        builder.Services.RegisterHostedService();

        builder.Services.AddControllers();

        builder.Services.AddOpenApi();

        builder.Services.AddIdentity(configuration, "IdentityOption");

        builder.Services.AddSwaggerService();

        //builder.Services.AddValidatorsFromAssemblyContaining<Program>();

        builder.Services.AddValidatorsFromAssemblies(assemblies);

        return builder.Build();
    }
    //public static async Task<WebApplication> ConfigurePipeline(this WebApplication app)
    //{
    //    // Configure the HTTP request pipeline.
    //    if (app.Environment.IsDevelopment())
    //    {
    //        app.UseSwaggerService();
    //        app.MapOpenApi(); // Only map OpenAPI in development
    //    }

    //    //app.UseExceptionHandler();
    //    app.UseExceptionMiddleware();

    //    app.UseHealthCheckServices();
    //    app.UseMonitoringAppServices();

    //    // Static files middleware
    //    app.UseStaticFiles();

    //    // Logging middleware
    //    app.UseSerilogRequestLogging();

    //    // HTTPS redirection middleware (should be early in the pipeline)
    //    app.UseHttpsRedirection();

    //    // Session middleware
    //    app.UseSession();

    //    app.UseRouting();

    //    // Authentication and authorization middleware
    //    app.UseAuthentication(); // Must come before UseAuthorization
    //    app.UseAuthorization();

    //    app.UseAuthorizedMiddleware();

    //    // Exception handling middleware (custom middleware)
    //    //app.UseExceptionMiddleware();

    //    // Map controllers
    //    app.MapControllers();

    //    // Fallback to index.html for SPA (ensure this is after MapControllers)
    //    app.MapFallbackToFile("index.html");

    //    // Initialize the database asynchronously
    //    await app.InitialiseDatabaseAsync();

    //    // Configure await for async operations
    //    app.ConfigureAwait(true);

    //    app.UseHangfireServices();

    //    return app;
    //}


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
        app.UseHangfireServices(); // Should be placed after auth if it relies on it

        // Controllers and endpoints
        app.MapControllers();

        // SPA fallback
        app.MapFallbackToFile("index.html");

        // Initialize the database (should be done after services are configured)
        await app.InitialiseDatabaseAsync();

        return app;
    }

}
