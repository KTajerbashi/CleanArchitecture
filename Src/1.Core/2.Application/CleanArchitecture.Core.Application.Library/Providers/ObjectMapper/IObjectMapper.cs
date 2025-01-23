namespace CleanArchitecture.Core.Application.Library.Providers.ObjectMapper;

public interface IObjectMapper
{
    TDestination Map<TSource, TDestination>(TSource source);

    List<TDestination> Map<TSource, TDestination>(List<TSource> source);
    IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source);
}
