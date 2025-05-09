using CleanArchitecture.Core.Application.Library.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Text;
using System.Text.Json;

namespace CleanArchitecture.Infra.SqlServer.Library.Services;

public class MessageBus : IMessageBus, IDisposable
{
    private readonly ILogger<MessageBus> _logger;
    private readonly ConnectionFactory _connectionFactory;
    private IConnection? _connection;
    private bool _disposed;
    private readonly object _connectionLock = new();

    public MessageBus(ILogger<MessageBus> logger)
    {
        _logger = logger;
        _connectionFactory = new ConnectionFactory
        {
            HostName = "localhost",
            //DispatchConsumersAsync = true,
            RequestedHeartbeat = TimeSpan.FromSeconds(30),
            AutomaticRecoveryEnabled = true,
            NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
        };
    }

    public async Task PublishAsync<T>(T model, string queueName, string routingKey) where T : class
    {
        ValidateParameters(model, queueName, routingKey);

        using var channel = await CreateChannelAsync();
        await DeclareQueueAsync(channel, queueName);

        var message = SerializeMessage(model);

        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: routingKey,
            body: message);

        _logger.LogInformation("Published message to queue {QueueName} with routing key {RoutingKey}.", queueName, routingKey);
    }

    public async Task<T> SubscribeAsync<T>(string queueName, string routingKey, CancellationToken cancellationToken = default) where T : class, new()
    {
        ValidateParameters(queueName, routingKey);

        var channel = await CreateChannelAsync();
        await DeclareQueueAsync(channel, queueName);

        var tcs = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (model, ea) =>
        {
            try
            {
                var message = await ProcessMessage<T>(ea, channel);
                tcs.TrySetResult(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing message from queue {QueueName}.", queueName);
                tcs.TrySetException(ex);
            }
        };

        await channel.BasicConsumeAsync(
            queue: queueName,
            autoAck: false,
            consumer: consumer);

        await using var _ = cancellationToken.Register(() => tcs.TrySetCanceled());

        try
        {
            return await tcs.Task;
        }
        finally
        {
            await Task.Delay(500); // Give time for ack to complete
            channel.Dispose();     // Manual disposal after consumption
        }
    }

    #region Private Helpers

    private async Task<IConnection> GetConnectionAsync()
    {
        if (_connection?.IsOpen == true)
            return _connection;

        //lock (_connectionLock)
        //{
        if (_connection?.IsOpen == true)
            return _connection;

        _connection?.Dispose();
        _connection = await _connectionFactory.CreateConnectionAsync();
        _connection.ConnectionShutdownAsync += OnConnectionShutdownAsync;
        //}

        return _connection;
    }

    private async Task<IChannel> CreateChannelAsync()
    {
        var connection = await GetConnectionAsync();
        return await connection.CreateChannelAsync();
    }

    private static Task DeclareQueueAsync(IChannel channel, string queueName)
    {
        channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        return Task.CompletedTask;
    }

    private static byte[] SerializeMessage<T>(T model)
    {
        var json = JsonSerializer.Serialize(model);
        return Encoding.UTF8.GetBytes(json);
    }

    private async Task<T> ProcessMessage<T>(BasicDeliverEventArgs ea, IChannel channel) where T : class
    {
        var body = ea.Body.ToArray();
        var json = Encoding.UTF8.GetString(body);

        var message = JsonSerializer.Deserialize<T>(json)
                      ?? throw new MessageBusException("Failed to deserialize message.");

        await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
        _logger.LogInformation("Message consumed from queue and acknowledged.");
        return message;
    }

    private static void ValidateParameters<T>(T model, string queueName, string routingKey) where T : class
    {
        if (model == null) throw new ArgumentNullException(nameof(model));
        ValidateParameters(queueName, routingKey);
    }

    private static void ValidateParameters(string queueName, string routingKey)
    {
        if (string.IsNullOrWhiteSpace(queueName))
            throw new ArgumentException("Queue name cannot be null or empty.", nameof(queueName));

        if (string.IsNullOrWhiteSpace(routingKey))
            throw new ArgumentException("Routing key cannot be null or empty.", nameof(routingKey));
    }

    private async Task OnConnectionShutdownAsync(object? sender, ShutdownEventArgs e)
    {
        await Task.CompletedTask;
        _logger.LogWarning("RabbitMQ connection shutdown: {Reason}", e.ReplyText);
    }

    #endregion

    #region Dispose

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            _connection?.Dispose();
            _logger.LogInformation("MessageBus disposed.");
        }

        _disposed = true;
    }

    ~MessageBus()
    {
        Dispose(false);
    }

    #endregion
}

public class MessageBusException : Exception
{
    public MessageBusException(string message) : base(message) { }
    public MessageBusException(string message, Exception innerException) : base(message, innerException) { }
}
