namespace CleanArchitecture.Core.Application.Library.Providers.Serializer.Objects;

public interface IObjectSerializer
{
    string Serialize<TInput>(TInput input);
    TOutput Deserialize<TOutput>(string input);
    object Deserialize(string input, Type type);
}
