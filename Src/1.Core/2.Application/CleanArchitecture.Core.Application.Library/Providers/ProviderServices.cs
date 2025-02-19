using CleanArchitecture.Core.Application.Library.Providers.ObjectMapper;
using CleanArchitecture.Core.Application.Library.Providers.Serializer.Objects;

namespace CleanArchitecture.Core.Application.Library.Providers;

public class ProviderServices
{
    public readonly IObjectConvertor Convertor;
    public readonly IObjectMapper Mapper;
    public ProviderServices(IObjectConvertor convertor, IObjectMapper mapper)
    {
        Convertor = convertor;
        Mapper = mapper;
    }
}
