using System.Data;

namespace CleanArchitecture.Core.Application.Library.Providers.DataDapper;

public interface IDataDapper
{
    Task<TModel> ReadAsync<TModel>(string query, object parameters = null!, IDbTransaction transaction = null!);
    Task<IEnumerable<TModel>> ReadListAsync<TModel>(string query, object parameters = null!, IDbTransaction transaction = null!);
    Task<int> ExecuteAsync(string command, object parameters = null!, IDbTransaction transaction = null!);
    Task<T> ExecuteScalarAsync<T>(string command, object parameters = null!, IDbTransaction transaction = null!);
    IDbTransaction BeginTransaction();
}
