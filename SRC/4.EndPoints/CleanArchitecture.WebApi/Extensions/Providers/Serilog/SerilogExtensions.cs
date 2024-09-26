using Serilog;

namespace CleanArchitecture.WebApi.Extensions.Providers.Serilog;

public static class SerilogExtensions
{
    public static WebApplicationBuilder AddSerilogService(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Host.UseSerilog((context,logConfig) =>
        {
            logConfig.WriteTo.Console();
            logConfig.ReadFrom.Configuration(context.Configuration);
            Log.Logger = new LoggerConfiguration()
            .ReadFrom
            .Configuration(context.Configuration)
            .CreateLogger();
        });
        
        builder.Services
        .AddSerilogConsole(configuration)
        .AddSerilogFile(configuration)
        .AddSerilogContext(configuration)
        ;
        return builder;
    }

    public static IServiceCollection AddSerilogConsole(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection AddSerilogFile(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection AddSerilogContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}

