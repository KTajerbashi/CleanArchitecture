using CleanArchitecture.Core.Application.Library.Providers.CacheSystem;

namespace CleanArchitecture.EndPoint.WebApi.HostedServer;

public class ServiceHost: IHostedService
{
    private readonly ILogger<ServiceHost> _logger;
    private readonly ICacheAdapter _cacheAdapter;
    private readonly Dictionary<string, string> _data;
    public ServiceHost(ILogger<ServiceHost> logger, ICacheAdapter cacheAdapter)
    {
        _logger = logger;
        _cacheAdapter = cacheAdapter;
        _data = new Dictionary<string, string>();
        fillData();

    }
    private void fillData()
    {
        _data.Add("LoginCode","https://logincode/clean");
        _data.Add("SecretKey", "https://secret/key");
        _data.Add("ApplicationId", "https://application/id");
        _data.Add("AppKey", "https://app/key");
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            foreach (var key in _data)
            {
                _cacheAdapter.Add(key.Key, key.Value, DateTime.Now.AddDays(7), DateTime.Now.TimeOfDay);
            }
        });
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            foreach (var key in _data)
            {
                _cacheAdapter.RemoveCache(key.Key);
            }
        });
    }
}
