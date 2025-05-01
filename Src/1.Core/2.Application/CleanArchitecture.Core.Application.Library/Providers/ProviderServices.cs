using CleanArchitecture.Core.Application.Library.Providers.CacheSystem;
using CleanArchitecture.Core.Application.Library.Providers.DataDapper;
using CleanArchitecture.Core.Application.Library.Providers.ObjectMapper;
using CleanArchitecture.Core.Application.Library.Providers.Serializer.Objects;
using CleanArchitecture.Core.Application.Library.Providers.UserManagement;

namespace CleanArchitecture.Core.Application.Library.Providers;

public class ProviderServices
{
    public readonly IObjectSerializer Convertor;
    public readonly IObjectMapper Mapper;
    public readonly ICacheAdapter CacheAdapter;
    public readonly IMediator Mediator;
    public readonly IDataDapper DataDapper;
    public readonly IUser User;
    public ProviderServices(
        IObjectSerializer convertor, 
        IObjectMapper mapper, 
        ICacheAdapter cacheAdapter, 
        IMediator mediator, 
        IUser user, 
        IDataDapper dataDapper)
    {
        Convertor = convertor;
        Mapper = mapper;
        CacheAdapter = cacheAdapter;
        Mediator = mediator;
        User = user;
        DataDapper = dataDapper;
    }
}
