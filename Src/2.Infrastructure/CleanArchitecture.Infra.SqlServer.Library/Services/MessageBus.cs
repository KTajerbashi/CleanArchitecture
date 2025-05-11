using CleanArchitecture.Core.Application.Library.Interfaces;
using CleanArchitecture.Infra.SqlServer.Library.Common.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CleanArchitecture.Infra.SqlServer.Library.Services;

public class MessageBus : IMessageBroker, IDisposable
{
    private readonly ILogger<MessageBus> _logger;
    private readonly IConfiguration _configuration;
    private readonly RabbitMQOption _option;
    public MessageBus(ILogger<MessageBus> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _option = new RabbitMQOption();
        configuration.Bind("RabbitMQ", _option);
    }

    public string HostName => _option.HostName;

    public string Username => _option.Username;

    public string Password => _option.Password;

    public int Port => _option.Port;

    public string ExchageName => _option.ExchageName;

    public string QueueName => _option.QueueName;

    public string RoutingKey => _option.RoutingKey;

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public async Task PublishAsync<T>(T data, string queueName, string exchangeName, string routingKey)
    {
        var factory = new ConnectionFactory() { HostName = _option.HostName };
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        await channel.ExchangeDeclareAsync(
            exchange: exchangeName,
            type: ExchangeType.Fanout);

        var message = JsonSerializer.Serialize(data);
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(
            exchange: exchangeName,
            routingKey: string.Empty, // Fanout ignores routing key
            body: body);
    }

    public async Task<T> SubscribeAsync<T>(string queueName, string exchangeName, string routingKey, Func<T, Task> onMessage)
    {
        var factory = new ConnectionFactory() { HostName = _option.HostName };
        var connection = await factory.CreateConnectionAsync();
        var channel = await connection.CreateChannelAsync();

        await channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Fanout);

        var queueDeclareOk = await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false);
        await channel.QueueBindAsync(queue: queueName, exchange: exchangeName, routingKey: string.Empty);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var obj = JsonSerializer.Deserialize<T>(message);
            if (obj is not null)
                await onMessage(obj);
        };

        await channel.BasicConsumeAsync(queue: queueName, autoAck: true, consumer: consumer);

        return default;
    }
}