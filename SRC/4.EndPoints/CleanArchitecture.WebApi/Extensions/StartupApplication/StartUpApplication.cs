using CleanArchitecture.WebApi.Extensions.Providers.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace CleanArchitecture.WebApi.Extensions.StartupApplication;

public class StartUpApplication
{
    public static void StartApplication(Action action)
    {

        try
        {
            #region Configuration
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .Build();
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File($"Logs/log_{DateTime.Now.ToString()}.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(
                connectionString: configuration.GetConnectionString("DefaultConnection"),
                sinkOptions: new MSSqlServerSinkOptions
                {
                    TableName = "Logs",
                    SchemaName = "Log",
                    AutoCreateSqlTable = true
                },
                restrictedToMinimumLevel: LogEventLevel.Information,
                columnOptions: LoggingServices.GetColumnOptions())
            .CreateLogger();
            Log.Fatal(configuration.GetConnectionString("DefaultConnection"));
            Log.Information("Starting web host");
            #endregion
            action();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
