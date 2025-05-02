using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Prometheus;

namespace CleanArchitecture.EndPoint.WebApi.MonitoringApp;

public static class DependencyInjections
{
    public static WebApplicationBuilder AddMonitoringAppServices(this WebApplicationBuilder builder)
    {
        // In Program.cs
        builder.Services.AddApplicationInsightsTelemetry();
        //builder.Services.AddApplicationInsightsKubernetesEnricher(); // If using Kubernetes

        // In Program.cs
        builder.Services.AddOpenTelemetry().WithTracing(tracing => tracing
                                                                        .AddAspNetCoreInstrumentation()
                                                                        .AddHttpClientInstrumentation()
                                                                        .AddOtlpExporter()
                                                                        .AddConsoleExporter()
                                                                        ); // Export to Jaeger/Zipkin

        builder.Services.AddOpenTelemetry().WithTracing(tracing =>
        {
            tracing
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            //.AddSqlClientInstrumentation()
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("CleanArchitecture"))
            .AddConsoleExporter();
        });
        return builder;
    }



    public static WebApplication UseMonitoringAppServices(this WebApplication app)
    {
        app.MapGet("OpenTelemetery",() => "Open Telemetry Service");
        // In Program.cs
        app.UseMetricServer(url: "/metrics");
        app.UseHttpMetrics();
        return app;
    }
}







