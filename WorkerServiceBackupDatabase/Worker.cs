using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using WorkerServiceBackupDatabase.Models;

namespace WorkerServiceBackupDatabase
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration configuration;
        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    BackupDatabase();
                }
                await Task.Delay(10000, stoppingToken);
            }
        }
        private void BackupDatabase()
        {
            string DatabaseName = configuration["BackupOptions:DbName"];
            string ServerName = configuration["BackupOptions:ServerName"];
            string DestinationPath = configuration["BackupOptions:DestinationPath"];
            string UserName = configuration["BackupOptions:UserName"];
            string Password = configuration["BackupOptions:Password"];

            Backup sqlBackup = new();

            sqlBackup.Action = Microsoft.SqlServer.Management.Smo.BackupActionType.Database;
            sqlBackup.BackupSetDescription = $"Backup Of:{DatabaseName} On {DateTime.Now.ToShortDateString()}";
            sqlBackup.BackupSetName = "FullBackup";
            sqlBackup.Database = DatabaseName;

            //  Declare a BackupDeviceItem
            DateTime Now = DateTime.Now;
            string FileName = $"{DatabaseName}_{Now.Year}_{Now.Month}_{Now.Day}_{Now.Hour}_{Now.Minute}_{Now.Second}.bak";
            BackupDeviceItem backupDeviceItem = new BackupDeviceItem($"{DestinationPath}\\{FileName}",DeviceType.File);

            /// Define Server Connection
            ServerConnection connection = new(ServerName,UserName,Password);
            Server server = new(connection);
            server.ConnectionContext.StatementTimeout = 60 * 60;
            Database db = server.Databases[DatabaseName];

            sqlBackup.Initialize = true;
            sqlBackup.Checksum = true;
            sqlBackup.ContinueAfterError = true;

            sqlBackup.Devices.Add(backupDeviceItem);

            sqlBackup.Incremental = false;
            sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
            sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
            sqlBackup.FormatMedia = false;
            sqlBackup.SqlBackup(server);
            sqlBackup.Devices.Remove(backupDeviceItem);
            _logger.LogInformation("Successful Backup is Created!");


        }
    }
}
