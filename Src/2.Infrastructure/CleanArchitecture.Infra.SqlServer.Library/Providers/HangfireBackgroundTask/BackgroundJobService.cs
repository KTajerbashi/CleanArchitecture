using CleanArchitecture.Core.Application.Library.Providers.HangfireBackgroundTask;
using CleanArchitecture.Core.Application.Library.Utilities.Extensions;
using Hangfire;

namespace CleanArchitecture.Infra.SqlServer.Library.Providers.HangfireBackgroundTask;

//public class BackgroundJobService : IBackgroundJobService
//{
//    private readonly IBackgroundJobClient _backgroundJobClient;
//    public BackgroundJobService(IBackgroundJobClient backgroundJobClient)
//    {
//        _backgroundJobClient = backgroundJobClient;
//    }

//    public void Continuations(string parnentId, Expression<Action> action)
//    {
//        ConsoleWriterExtension.PrintConsole($"~> Start Continuations On {DateTime.Now.ToString("G")}");
//        BackgroundJob.Enqueue(parnentId, action);
//        ConsoleWriterExtension.PrintConsole($"~> Finish Continuations On {DateTime.Now.ToString("G")}");
//    }

//    public void Delayed(Expression<Action> action, int secondDelay)
//    {
//        ConsoleWriterExtension.PrintConsole($"~> Start Delayed On {DateTime.Now.ToString("G")}");
//        BackgroundJob.Schedule(action, TimeSpan.FromMinutes(secondDelay));
//        ConsoleWriterExtension.PrintConsole($"~> Finish Delayed On {DateTime.Now.ToString("G")}");
//    }

//    public void FireAndForget(Expression<Action> action)
//    {
//        ConsoleWriterExtension.PrintConsole($"~> Start FireAndForget On {DateTime.Now.ToString("G")}");
//        BackgroundJob.Enqueue(action);
//        ConsoleWriterExtension.PrintConsole($"~> Finish FireAndForget On {DateTime.Now.ToString("G")}");
//    }

//    public void Recurring(string jonId, Expression<Action> action, CornType corn)
//    {
//        ConsoleWriterExtension.PrintConsole($"~> Start Recurring On {DateTime.Now.ToString("G")}");
//        RecurringJob.AddOrUpdate(jonId, action, Cron.Minutely);
//        ConsoleWriterExtension.PrintConsole($"~> Finish Recurring On {DateTime.Now.ToString("G")}");
//    }
//}
