using WorkerServiceBackupDatabase;

var builder = Host.CreateDefaultBuilder(args).UseWindowsService(option =>
{
    option.ServiceName = "TajerbashiBackupService";
}).ConfigureServices(service =>
{
    service.AddHostedService<Worker>();
})
;
//builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
