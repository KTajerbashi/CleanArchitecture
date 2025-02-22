using CleanArchitecture.Core.Application.Library.Providers.CacheSystem;
using CleanArchitecture.Core.Application.Library.Providers.ObjectMapper;
using CleanArchitecture.Core.Application.Library.Providers.Serializer.Objects;

namespace CleanArchitecture.Core.Application.Library.Providers;

public class ProviderServices
{
    public readonly IObjectConvertor Convertor;
    public readonly IObjectMapper Mapper;
    public readonly ICacheAdapter CacheAdapter;
    public ProviderServices(
        IObjectConvertor convertor, 
        IObjectMapper mapper, 
        ICacheAdapter cacheAdapter
        )
    {
        Convertor = convertor;
        Mapper = mapper;
        CacheAdapter = cacheAdapter;
    }
}
