using CleanArchitecture.Core.Application.Library.Providers.Scrutor;

namespace CleanArchitecture.Core.Application.Library.Interfaces;

public interface IMessageBus : ISingletonLifeTime
{
    Task PublishAsync<T>(T model, string queueName, string routingKey) where T : class;

    Task<T> SubscribeAsync<T>(string queueName, string routingKey, CancellationToken cancellationToken = default) where T : class, new();

}