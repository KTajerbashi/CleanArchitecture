using CleanArchitecture.Core.Application.Library.Providers.HangfireBackgroundTask;
using Hangfire;

namespace CleanArchitecture.Infra.SqlServer.Library.Providers.HangfireBackgroundTask;

public static class HangfireRecurringJobs
{
    public static void Register()
    {
        RecurringJob.AddOrUpdate<IUserTask>("my-recurring-job", x => x.UpdateUserFromWebService(), Cron.Daily);
    }
}


public class UserTask : IUserTask
{
    public void UpdateUserFromWebService()
    {
        Console.WriteLine($"~> User Update Started On : {DateTime.Now.ToString("G")}");
        Task.Delay(3000);
        Console.WriteLine($"~> User Update Finished On : {DateTime.Now.ToString("G")}");
    }

    [AutomaticRetry(Attempts = 3)]
    public async Task SendEmailAsync(int orderId)
    {
        Console.WriteLine($"~> Send Email Started On : {DateTime.Now.ToString("G")}");
        //var order = await _orderRepository.GetByIdAsync(orderId);
        // Business logic here
        await Task.Delay(3000);
        Console.WriteLine($"~> Send Email Finished On : {DateTime.Now.ToString("G")}");
    }

}