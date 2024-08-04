using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;

namespace CleanArchitecture.WebApi.Extensions.Providers.Logging;

public static class LoggingServices
{
    public static ColumnOptions GetColumnOptions()
    {
        var columnOptions = new ColumnOptions();

        // Add custom columns
        columnOptions.AdditionalDataColumns = new Collection<DataColumn>
        {
            new DataColumn { DataType = typeof(string), ColumnName = "UserId" },
            new DataColumn { DataType = typeof(string), ColumnName = "CurrentUser" },
            new DataColumn { DataType = typeof(string), ColumnName = "EntityName" },
            new DataColumn { DataType = typeof(string), ColumnName = "LastData" },
            new DataColumn { DataType = typeof(string), ColumnName = "NewData" },
            new DataColumn { DataType = typeof(string), ColumnName = "ServiceName" },
            new DataColumn { DataType = typeof(string), ColumnName = "MethodName" },
            new DataColumn { DataType = typeof(string), ColumnName = "NameSpace" },
            new DataColumn { DataType = typeof(string), ColumnName = "Parameters" },
            new DataColumn { DataType = typeof(DateTime), ColumnName = "CreateDate" }
        };

        return columnOptions;
    }
}
public class LogModel
{
    public string UserId { get; set; }
    public string CurrentUser { get; set; }
    public string EntityName { get; set; }
    public string LastData { get; set; }
    public string NewData { get; set; }
    public string ServiceName { get; set; }
    public string MethodName { get; set; }
    public string NameSpace { get; set; }
    public string Parameters { get; set; }
    public DateTime CreateDate { get; set; }
}