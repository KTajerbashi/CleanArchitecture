using CleanArchitecture.Core.Application.Providers.DataDapper;
using System.Data.Common;
using System.Diagnostics;

namespace CleanArchitecture.Infra.SqlServer.Providers.DataDapper;


public class DataDapper : IDataDapper
{
    private readonly ILogger<DataDapper> _logger;
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;
    private bool _disposed = false;
    private readonly Stopwatch _queryTimer = new();

    public DataDapper(IConfiguration configuration, IDbConnection connection, ILogger<DataDapper> logger)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        InitializeConnection();
    }

    private void InitializeConnection()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("DefaultConnection string not found");

        _connection.ConnectionString = connectionString;

        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
            _logger.LogInformation("Database connection opened");
        }
    }

    public async Task<TModel> ReadAsync<TModel>(string query, object parameters = null, IDbTransaction transaction = null)
    {
        _queryTimer.Restart();
        try
        {
            var result = await _connection.QueryFirstOrDefaultAsync<TModel>(query, parameters, transaction);
            _logger.LogDebug("ReadAsync executed in {ElapsedMilliseconds}ms: {Query}",
                _queryTimer.ElapsedMilliseconds, query);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing ReadAsync: {Query}", query);
            throw;
        }
    }

    public async Task<IEnumerable<TModel>> ReadListAsync<TModel>(string query, object parameters = null, IDbTransaction transaction = null)
    {
        _queryTimer.Restart();
        try
        {
            var result = await _connection.QueryAsync<TModel>(query, parameters, transaction);
            _logger.LogDebug("ReadListAsync returned {Count} items in {ElapsedMilliseconds}ms: {Query}",
                result.Count(), _queryTimer.ElapsedMilliseconds, query);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing ReadListAsync: {Query}", query);
            throw;
        }
    }

    public async Task<int> ExecuteAsync(string command, object parameters = null, IDbTransaction transaction = null)
    {
        _queryTimer.Restart();
        try
        {
            var result = await _connection.ExecuteAsync(command, parameters, transaction);
            _logger.LogDebug("ExecuteAsync affected {RowsAffected} rows in {ElapsedMilliseconds}ms: {Command}",
                result, _queryTimer.ElapsedMilliseconds, command);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing ExecuteAsync: {Command}", command);
            throw;
        }
    }

    public async Task<T> ExecuteScalarAsync<T>(string command, object parameters = null, IDbTransaction transaction = null)
    {
        _queryTimer.Restart();
        try
        {
            var result = await _connection.ExecuteScalarAsync<T>(command, parameters, transaction);
            _logger.LogDebug("ExecuteScalarAsync completed in {ElapsedMilliseconds}ms: {Command}",
                _queryTimer.ElapsedMilliseconds, command);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing ExecuteScalarAsync: {Command}", command);
            throw;
        }
    }

    public IDbTransaction BeginTransaction()
    {
        try
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection.BeginTransaction();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error beginning transaction");
            throw;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _queryTimer.Stop();
                if (_connection != null)
                {
                    if (_connection.State != ConnectionState.Closed)
                    {
                        _connection.Close();
                        _logger.LogInformation("Database connection closed");
                    }
                    _connection.Dispose();
                }
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~DataDapper()
    {
        Dispose(false);
    }
}
