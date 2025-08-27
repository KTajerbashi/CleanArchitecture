using CleanArchitecture.Core.Application.Interfaces;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Common;

public class MessageParameter
{
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}

public class MessageBrokerController : BaseController
{
    private readonly IMessageBroker _messageBroker;

    public MessageBrokerController(IMessageBroker messageBroker)
    {
        _messageBroker = messageBroker;
    }

    [HttpPost("Publish")]
    public async Task<IActionResult> Publish(MessageParameter parameter)
    {
        await _messageBroker.PublishAsync(
            parameter,
            _messageBroker.QueueName,
            _messageBroker.ExchageName,
            _messageBroker.RoutingKey);

        await _messageBroker.PublishAsync(
           parameter,
           $"{_messageBroker.QueueName}_1",
           $"{_messageBroker.ExchageName}_1",
           $"{_messageBroker.RoutingKey}_1");
        return Ok("Success");
    }
  
}
