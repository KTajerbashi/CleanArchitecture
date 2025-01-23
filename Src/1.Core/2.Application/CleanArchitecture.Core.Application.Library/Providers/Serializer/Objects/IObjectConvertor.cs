namespace CleanArchitecture.Core.Application.Library.Providers.Serializer.Objects;

public interface IObjectConvertor
{
    string Serialize<TInput>(TInput input);
    TOutput Deserialize<TOutput>(string input);
    object Deserialize(string input, Type type);
}
