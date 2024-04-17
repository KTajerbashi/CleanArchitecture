using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace CleanArchitecture.Infrastructure.Library.ORM.Dapper
{
    public static class DapperService
    {
        //public static List<T> ExecuteQuery<T>(string command, object param)
        //{
        //    //using (IDbConnection db = new SqlConnection((string)ConfigurationManager.GetSection("DefaultConnection")))
        //    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //    {
        //        //FileLogger.Log($"DapperService Start : {command}");
        //        var result = db.Query<T>(command,param:param,commandType:CommandType.StoredProcedure);
        //        //FileLogger.Log($"DapperService End : {command}");
        //    }
        //}
    }
}
