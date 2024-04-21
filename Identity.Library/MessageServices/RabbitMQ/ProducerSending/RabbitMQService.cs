using RabbitMQ.Client;
using System.Text;

namespace Identity.Library.MessageServices.RabbitMQ.ProducerSending
{
    public class RabbitMQService
    {
        private int Counter;
        public RabbitMQService(int counter)
        {
            Counter = counter;
        }
        public void Execute()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("FirstMessages", false, false, false, null);
            for (int i = 1; i <= 30; i++)
            {
                string message = $"{i} Message Sending From Identity Server on Time : {DateTime.Now.ToString("G:fff")} {DateTime.Now.Ticks}";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", "FirstMessages", null,body);
            }
            Console.WriteLine($"::::::::::::::::::::::{Counter}:::::::::::::::::::::");
            Counter++;
            channel.Close();
            connection.Close();
        }
    }
}
