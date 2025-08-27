using CleanArchitecture.Core.Application.Interfaces;
using CleanArchitecture.EndPoint.WebApi.Controllers.Common;

namespace CleanArchitecture.EndPoint.WebApi.Providers.HostedServer;

public class MessageBrokerHost(IMessageBroker messageBroker) : BackgroundService
{
    private readonly IMessageBroker _messageBroker = messageBroker;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _messageBroker.SubscribeAsync<MessageParameter>(
            _messageBroker.QueueName,
            _messageBroker.ExchageName,
            _messageBroker.RoutingKey, async (model) =>
        {
            await Task.Delay(1000);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now.ToString("G")} ~> [x] Subscribe On : {JsonSerializer.Serialize(model)}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        });

        await _messageBroker.SubscribeAsync<MessageParameter>(
           $"{_messageBroker.QueueName}_1",
           $"{_messageBroker.ExchageName}_1",
           $"{_messageBroker.RoutingKey}_1",
            async (model) =>
        {
            await Task.Delay(3000);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{DateTime.Now.ToString("G")} ~> [x] Subscribe On : {JsonSerializer.Serialize(model)}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        });
    }
}