using CleanArchitecture.Core.Application.Library.Providers.CacheSystem;
using CleanArchitecture.Core.Application.Library.Providers.Serializer.Objects;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infra.SqlServer.Library.Providers.CacheSystem.InMemory;

public class InMemoryCacheAdapter : ICacheAdapter
{
    private readonly IMemoryCache _memoryCache;
    private readonly IObjectConvertor _convertor;
    private readonly ILogger<InMemoryCacheAdapter> _logger;

    public InMemoryCacheAdapter(IMemoryCache memoryCache,
                                IObjectConvertor convertor,
                                ILogger<InMemoryCacheAdapter> logger)
    {
        _memoryCache = memoryCache;
        _convertor = convertor;
        _logger = logger;
        _logger.LogInformation("InMemoryCache Adapter Start working");
    }

    public void Add<TInput>(string key, TInput obj, DateTime? absoluteExpiration, TimeSpan? slidingExpiration)
    {
        _logger.LogTrace("InMemoryCache Adapter Cache {obj} with key : {key} " +
                         ", with data : {data} " +
                         ", with absoluteExpiration : {absoluteExpiration} " +
                         ", with slidingExpiration : {slidingExpiration}",
                         typeof(TInput),
                         key,
                         _convertor.Serialize(obj),
                         absoluteExpiration.ToString(),
                         slidingExpiration.ToString());

        _memoryCache.Set(key, obj, new MemoryCacheEntryOptions
        {
            AbsoluteExpiration = absoluteExpiration,
            SlidingExpiration = slidingExpiration,
        });
    }

    public TOutput Get<TOutput>(string key)
    {
        _logger.LogTrace("InMemoryCache Adapter Try Get Cache with key : {key}", key);

        var result = _memoryCache.TryGetValue(key, out TOutput resultObject);

        if (result)
            _logger.LogTrace("InMemoryCache Adapter Successful Get Cache with key : {key} and data : {data}",
                             key,
                             _convertor.Serialize(resultObject));
        else
            _logger.LogTrace("InMemoryCache Adapter Failed Get Cache with key : {key}", key);

        return resultObject;
    }

    public void RemoveCache(string key)
    {
        _logger.LogTrace("InMemoryCache Adapter Remove Cache with key : {key}", key);

        _memoryCache.Remove(key);
    }
}