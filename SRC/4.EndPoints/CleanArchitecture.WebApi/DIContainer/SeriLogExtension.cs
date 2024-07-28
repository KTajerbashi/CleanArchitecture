using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Collections.ObjectModel;
using static Serilog.Sinks.MSSqlServer.ColumnOptions;
using CleanArchitecture.WebApi.DIContainer.LoggingExtensions;

namespace CleanArchitecture.WebApi.DIContainer;

public  class SeriLogExtension
{
    public static void StartApplication(Action action)
    {

		try
		{
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .Build();
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
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
            Log.Information(configuration.GetConnectionString("DefaultConnection"));
            Log.Information("Starting web host");
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
