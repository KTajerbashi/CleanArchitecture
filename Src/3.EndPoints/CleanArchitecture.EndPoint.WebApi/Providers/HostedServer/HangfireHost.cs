using CleanArchitecture.Infra.SqlServer.Library.Providers.HangfireBackgroundTask;

namespace CleanArchitecture.EndPoint.WebApi.Providers.HostedServer;

public class HangfireHost : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine($"HangfireHost Started On : {DateTime.Now.ToString("G")}");
        Console.BackgroundColor = ConsoleColor.Black;
        HangfireRecurringJobs.Register();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"HangfireHost Stoped On : {DateTime.Now.ToString("G")}");
        Console.BackgroundColor = ConsoleColor.Black;
    }
}
