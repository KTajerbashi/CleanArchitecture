namespace CleanArchitecture.Infra.SqlServer.Library.Providers.HangfireBackgroundTask;

// Infrastructure/Configurations/HangfireSettings.cs
public class HangfireSettings
{
    public bool Enable { get; set; }
    public string ConnectionString { get; set; } = string.Empty;
    public string SchemaName { get; set; } = "Hangfire";

    public DashboardSettings Dashboard { get; set; } = new();
}

public class DashboardSettings
{
    public string BaseUrl { get; set; } = "/hangfire";
    public string Title { get; set; } = "Jobs Dashboard";
    public int StatsPollingIntervalMs { get; set; } = 60000;
    public bool DisplayConnectionString { get; set; } = false;
    public List<RoleAccessSettings> RoleAccess { get; set; } = new();
}

public class RoleAccessSettings
{
    public string Role { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public bool Enabled { get; set; } = false;
}
