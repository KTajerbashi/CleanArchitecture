using Microsoft.SqlServer.Management.Smo;

namespace WorkerServiceBackupDatabase.Models
{
    public class BackupModel
    {
        public BackupActionType Action { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string BackupSetName { get; set; }
        public string Database { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Initial { get; internal set; }
        public bool ContinueAfterError { get; internal set; }
        public bool Checksum { get; internal set; }
    }
}
