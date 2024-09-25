﻿using CleanArchitecture.WebApi.Extensions.Providers.Logging;
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
                .WriteTo.Console()
                .CreateBootstrapLogger();
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
