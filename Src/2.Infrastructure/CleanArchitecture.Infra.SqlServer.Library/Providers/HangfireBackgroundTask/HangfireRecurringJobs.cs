using CleanArchitecture.Core.Application.Library.Providers.HangfireBackgroundTask;
using Hangfire;

namespace CleanArchitecture.Infra.SqlServer.Library.Providers.HangfireBackgroundTask;

public static class HangfireRecurringJobs
{
    public static void Register()
    {
        RecurringJob
            .AddOrUpdate<IJobService>(
            "CreateDefaultUserRole-Job",
            x => x.CreateDefaultUserRole(),
            Cron.Minutely
            );

        RecurringJob
            .AddOrUpdate<IJobService>(
            "UpdatePhonesFromWebService-Job",
            x => x.UpdatePhonesFromWebService(),
            Cron.Minutely
            );

        RecurringJob
            .AddOrUpdate<IJobService>(
            "RemoveDataExpire-Job",
            x => x.RemoveDataExpire(),
            Cron.Daily
            );

        RecurringJob
            .AddOrUpdate<IJobService>(
            "SendEmail-Job",
            x => x.SendEmail(),
            Cron.Weekly
            );
    }
}


