using AutoMapper;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Core.Application.Providers.ObjectMapper;

public class ObjectMapperService : IObjectMapper
{
    private readonly IMapper _mapper;
    private readonly ILogger<ObjectMapperService> _logger;

    public ObjectMapperService(IMapper mapper, ILogger<ObjectMapperService> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        _logger.LogTrace("AutoMapper Adapter Map {source} To {destination} with data {sourcedata}",typeof(TSource),typeof(TDestination),source);
        return _mapper.Map<TDestination>(source);
    }

    public List<TDestination> Map<TSource, TDestination>(List<TSource> source)
    {
        _logger.LogTrace("AutoMapper Adapter Map List Of {source} To List {destination} with data {sourcedata}",typeof(TSource),typeof(TDestination),source);
        return _mapper.Map<List<TDestination>>(source);
    }

    public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
    {
        _logger.LogTrace("AutoMapper Adapter Map List Of {source} To List {destination} with data {sourcedata}",typeof(TSource),typeof(TDestination),source);
        return _mapper.Map<IEnumerable<TDestination>>(source);
    }
}