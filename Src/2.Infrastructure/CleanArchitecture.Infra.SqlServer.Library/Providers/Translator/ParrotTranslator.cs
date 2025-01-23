using CleanArchitecture.Core.Application.Library.Providers.Translator;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.SqlServer.Library.Providers.Translator;

public class ParrotTranslator : ITranslator, IDisposable
{
    private readonly string _currentCulture;
    private readonly ParrotSqlRepository _localizer;
    private readonly ILogger<ParrotTranslator> _logger;

    public ParrotTranslator(IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger)
    {
        _currentCulture = CultureInfo.CurrentCulture.ToString();
        _logger = logger;
        if (string.IsNullOrWhiteSpace(_currentCulture))
        {
            _currentCulture = "en-US";
            _logger.LogInformation("Parrot Translator current culture is null and set to en-US");
        }
        _localizer = new ParrotSqlRepository(configuration.Value, logger);
        _logger.LogInformation("Parrot Translator Start working with culture {Culture}", _currentCulture);
    }


    public string this[string name] { get => GetString(name); set => throw new NotImplementedException(); }
    public string this[CultureInfo culture, string name] { get => GetString(culture, name); set => throw new NotImplementedException(); }


    public string this[string name, params string[] arguments] { get => GetString(name, arguments); set => throw new NotImplementedException(); }
    public string this[CultureInfo culture, string name, params string[] arguments] { get => GetString(culture, name, arguments); set => throw new NotImplementedException(); }


    public string this[char separator, params string[] names] { get => GetConcateString(separator, names); set => throw new NotImplementedException(); }
    public string this[CultureInfo culture, char separator, params string[] names] { get => GetConcateString(culture, separator, names); set => throw new NotImplementedException(); }


    public string GetString(string name)
    {
        _logger.LogTrace("Parrot Translator GetString with name {name}", name);
        return _localizer.Get(name, _currentCulture);

    }
    public string GetString(CultureInfo culture, string name)
    {
        _logger.LogTrace("Parrot Translator GetString  with culture {culture} name {name}", culture, name);
        if (culture is null)
            return _localizer.Get(name, _currentCulture);
        else return _localizer.Get(name, culture.ToString());
    }


    public string GetString(string pattern, params string[] arguments)
    {
        _logger.LogTrace("Parrot Translator GetString with pattern {pattern} and arguments {arguments}", pattern, arguments);

        for (int i = 0; i < arguments.Length; i++)
        {
            arguments[i] = GetString(arguments[i]);
        }

        pattern = GetString(pattern);

        for (int i = 0; i < arguments.Length; i++)
        {
            string placeHolder = $"{{{i}}}";
            pattern = pattern.Replace(placeHolder, arguments[i]);
        }

        return pattern;
    }

    public string GetString(CultureInfo culture, string pattern, params string[] arguments)
    {
        _logger.LogTrace("Parrot Translator GetString with culture {culture} and  pattern {pattern} and arguments {arguments}", culture, pattern, arguments);

        for (int i = 0; i < arguments.Length; i++)
        {
            arguments[i] = GetString(culture, arguments[i]);
        }

        pattern = GetString(culture, pattern);

        for (int i = 0; i < arguments.Length; i++)
        {
            string placeHolder = $"{{{i}}}";
            pattern = pattern.Replace(placeHolder, arguments[i]);
        }

        return pattern;
    }

    public string GetConcateString(char separator = ' ', params string[] names)
    {
        _logger.LogTrace("Parrot Translator GetConcateString with separator {separator} and names {names}", separator, names);

        for (int i = 0; i < names.Length; i++)
        {
            names[i] = GetString(names[i]);
        }

        return string.Join(separator, names);
    }

    public string GetConcateString(CultureInfo culture, char separator = ' ', params string[] names)
    {
        _logger.LogTrace("Parrot Translator GetConcateString with culture {culture} and separator {separator} and names {names}", culture, separator, names);

        for (int i = 0; i < names.Length; i++)
        {
            names[i] = GetString(culture, names[i]);
        }

        return string.Join(separator, names);
    }

    public void Dispose()
    {
        _logger.LogInformation("Parrot Translator Stop working with culture {Culture}", _currentCulture);
    }
}

public class ParrotSqlRepository
{
    private readonly IDbConnection _dbConnection;
    private List<LocalizationRecord> _localizationRecords;

    static readonly object _locker = new();

    private readonly ParrotTranslatorOptions _configuration;
    private readonly ILogger _logger;
    private readonly string _selectCommand = "Select * from [{0}].[{1}]";
    private readonly string _insertCommand = "INSERT INTO [{0}].[{1}]([Key],[Value],[Culture]) VALUES (@Key,@Value,@Culture) select SCOPE_IDENTITY()";

    public ParrotSqlRepository(ParrotTranslatorOptions configuration,
                               ILogger logger)
    {
        _configuration = configuration;
        _logger = logger;
        _dbConnection = new SqlConnection(configuration.ConnectionString);

        if (_configuration.AutoCreateSqlTable)
            CreateTableIfNeeded();

        _selectCommand = string.Format(_selectCommand, configuration.SchemaName, configuration.TableName);

        _insertCommand = string.Format(_insertCommand, configuration.SchemaName, configuration.TableName);

        LoadLocalizationRecords(null);

        SeedData();

        LoadLocalizationRecords(null);

        _ = new Timer(LoadLocalizationRecords,
                           null,
                           TimeSpan.FromMinutes(configuration.ReloadDataIntervalInMinuts),
                           TimeSpan.FromMinutes(configuration.ReloadDataIntervalInMinuts));

    }

    private void CreateTableIfNeeded()
    {
        try
        {
            string table = _configuration.TableName;
            string schema = _configuration.SchemaName;

            _logger.LogInformation("Parrot Translator try to create table in database with connection {ConnectionString}. Schema name is {Schema}. Table name is {TableName}", _configuration.ConnectionString, schema, table);


            string createTable = $"IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES WHERE " +
                $"TABLE_SCHEMA = '{schema}' AND  TABLE_NAME = '{table}' )) Begin " +
                $"CREATE TABLE [{schema}].[{table}]( " +
                $"Id bigint  Primary Key Identity(1,1)," +
                $"[BusinessId] [UNIQUEIDENTIFIER] NOT NULL UNIQUE  default(newId())," +
                $"[Key] [nvarchar](255) NOT NULL," +
                $"[Value] [nvarchar](500) NOT NULL," +
                $"[Culture] [nvarchar](5) NULL)" +
            $" End";

            //    TODO
            //_dbConnection.Execute(createTable);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Create table for Parrot Translator Failed");
            throw;
        }

    }

    private void LoadLocalizationRecords(object? state)
    {
        lock (_locker)
        {
            _logger.LogInformation("Parrot Translator load localization recored at {DateTime}", DateTime.Now);

            //    TODO
            //_localizationRecords = _dbConnection.Query<LocalizationRecord>(_selectCommand, commandType: CommandType.Text).ToList();

            _logger.LogInformation("Parrot Translator loaded localization recored at {DateTime}. Total record count is {RecordCount}", DateTime.Now, _localizationRecords.Count);
        }
    }

    private void SeedData()
    {
        string values = string.Empty;

        var newItemsInDefaultTranslations = _configuration.DefaultTranslations.
            Where(c => !_localizationRecords.Any(d => d.Key.Equals(c.Key) && d.Culture.Equals(c.Culture)))
            .Select(c => $"(N'{c.Key}',N'{c.Value}',N'{c.Culture}')").ToList();

        var count = newItemsInDefaultTranslations.Count;
        if (count > 0)
        {
            string _command = $"INSERT INTO [{_configuration.SchemaName}].[{_configuration.TableName}]([Key],[Value],[Culture]) VALUES {string.Join(",", newItemsInDefaultTranslations)}";

            using IDbConnection db = new SqlConnection(_configuration.ConnectionString);

            //    TODO
            //db.Execute(_command, commandType: CommandType.Text);

            _logger.LogInformation("Parrot Translator Add {Count} items to its dictionary from default translations at {DateTime}", count, DateTime.Now);

        }
    }

    public string Get(string key, string culture)
    {
        try
        {
            var record = _localizationRecords.FirstOrDefault(c => c.Key == key && c.Culture == culture);
            if (record == null)
            {
                _logger.LogInformation("The key was not found and was registered with the default value in Parrot Translator. Key is {Key} and culture is {Culture}", key, culture);
                record = new LocalizationRecord
                {
                    Key = key,
                    Culture = culture,
                    Value = key
                };

                var parameters = new DynamicParameters();
                parameters.Add("@Key", key);
                parameters.Add("@Culture", culture);
                parameters.Add("@Value", key);

                record.Id = _dbConnection.Query<int>(_insertCommand, param: parameters, commandType: CommandType.Text).FirstOrDefault();
                _localizationRecords.Add(record);
            }
            return record.Value;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get Key value from Sql Server for Parrot Translator Failed");
            throw;
        }

    }
}
