using CleanArchitecture.Core.Application.Library.Interfaces;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Common;

public class MessageParameter
{
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}

public class MessageBusController : BaseController
{
    private readonly IMessageBus _messageBus;

    public MessageBusController(IMessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    [HttpPost("Publish")]
    public async Task<IActionResult> Publish(MessageParameter parameter)
    {
        await _messageBus.PublishAsync(parameter, "messagebus", "messagebus");

        return Ok("Success");
    }
    [HttpPost("Subscribe")]
    public async Task<IActionResult> Subscribe()
    {
       var response = await _messageBus.SubscribeAsync<MessageParameter>("messagebus", "messagebus");

        return Ok(response);

    }
}
