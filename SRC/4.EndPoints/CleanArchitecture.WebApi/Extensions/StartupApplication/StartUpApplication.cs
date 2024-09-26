using Serilog;
using System.Configuration;

namespace CleanArchitecture.WebApi.Extensions.StartupApplication;

public class StartUpApplication
{
    public static void StartApplication(Action action)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console().CreateLogger();
        try
        {
            Log.Information("Starting server ...");
            action();
        }
        catch (Exception ex)
        {
            Log.Fatal("Application Down ...");
        }
        finally
        {
            Log.Fatal("Application ShutDown ...");
            Log.CloseAndFlush();
        }
    }
}
