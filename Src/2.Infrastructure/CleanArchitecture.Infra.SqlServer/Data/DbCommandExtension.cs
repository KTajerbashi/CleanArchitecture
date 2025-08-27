using System.Data.Common;
using System.Data;
using CleanArchitecture.Core.Application.Utilities.Extensions;
using CleanArchitecture.Infra.SqlServer.Data;

namespace CleanArchitecture.Infra.SqlServer.Data;

/// <summary>
/// قابلیت های که میخواهیم روی دستورات اعمال شود
/// </summary>
public static class DbCommandExtension
{
    /// <summary>
    /// روی کاماند اجرا میشود و "ی - ک " را درست میکند
    /// </summary>
    /// <param name="command"></param>
    public static void ApplyCorrectYeKe(this DbCommand command)
    {
        command.CommandText = command.CommandText.ApplyCorrectYeKe();

        foreach (DbParameter parameter in command.Parameters)
        {
            switch (parameter.DbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.Xml:
                    parameter.Value =
                        parameter.Value is DBNull ?
                        parameter.Value :
                        parameter.Value.ApplyCorrectYeKe();
                    break;
            }
        }
    }
}

