using CleanArchitecture.Core.Application.Library.Providers.Scrutor;

namespace CleanArchitecture.Core.Application.Library.Interfaces;
public interface IMessageBroker : ISingletonLifeTime
{
    Task PublishAsync<T>(T data, string queueName, string exchangeName, string routingKey);
    Task<T> SubscribeAsync<T>(string queueName, string exchangeName, string routingKey, Func<T, Task> onMessage);

    string HostName { get; }
    string Username { get; }
    string Password { get; }
    int Port { get; }
    string ExchageName { get; }
    string QueueName { get; }
    string RoutingKey { get; }
}