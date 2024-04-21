
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CleanArchitecture.WebApp.MessageContainer.RabbitMQ.ConsumerReceiveMessage
{
    public class ConsumerService
    {
    }
    public class ReceiverMessageTask : BackgroundService
    {
        private IModel Channel;
        private IConnection Connection;
        public ReceiverMessageTask()
        {
            var factory = new ConnectionFactory
            {
                HostName="localhost",
                UserName="guest",
                Password="guest",
            };
            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var resultHandelMessage = HandleMessage(content);
                if (resultHandelMessage)
                {
                    Channel.BasicAck(ea.DeliveryTag, false);
                }
            };
            Channel.BasicConsume("FirstMessages", false,consumer);
            return Task.CompletedTask;
        }

        private bool HandleMessage(string content)
        {
            Console.WriteLine(content);
            return true;
        }
    }
}
