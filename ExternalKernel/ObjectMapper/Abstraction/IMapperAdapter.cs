namespace ObjectMapper.Abstraction;

public interface IMapperAdapter
{
    TDestination Map<TSource, TDestination>(TSource source);
}
