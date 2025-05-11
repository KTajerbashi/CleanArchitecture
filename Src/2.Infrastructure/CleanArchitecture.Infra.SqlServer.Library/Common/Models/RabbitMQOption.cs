namespace CleanArchitecture.Infra.SqlServer.Library.Common.Models;

public class RabbitMQOption
{
    public string HostName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ExchageName { get; set; }
    public string QueueName { get; set; }
    public string RoutingKey { get; set; }
    public int Port { get; set; }
}
