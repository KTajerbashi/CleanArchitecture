namespace CleanArchitecture.Application.Providers.MapperProvider.Abstract;

public interface IMapperAdapter
{
    TDestination Map<TSource, TDestination>(TSource source);
}
