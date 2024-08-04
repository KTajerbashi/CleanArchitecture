using BackgroundTaskProvider.HangfireProvider.Services;
using CleanArchitecture.WebApi.BaseEndPoints;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.BackgroundTask;

public class MessageController : BaseController
{
    private readonly ILogger<MessageController> _logger;
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly IRecurringJobManager _recurringJobManager;
    private readonly BackgroundTaskService _backgroundTaskService;
    int _taskId=1;
    public MessageController(IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, BackgroundTaskService backgroundTaskService, ILogger<MessageController> logger)
    {
        _backgroundJobClient = backgroundJobClient;
        _recurringJobManager = recurringJobManager;
        _backgroundTaskService = backgroundTaskService;
        _logger = logger;
    }

    [HttpGet("SendMessage")]
    public IActionResult SendMessage()
    {
        _backgroundTaskService.RecurringJobManager.AddOrUpdate<SenderProvider>("Sending",item => _logger.LogInformation(item.Apply(_taskId)),Cron.MinuteInterval(1));
        
        _logger.LogInformation("\n\n\nMessages Sending ...\n\n\n");
        return Ok("Messages Sending ...");
    }
}
public class SenderProvider
{
    public string Apply(int number)
    {
        ISendProvider service;
        if (number % 2 == 0)
            service = new SendEmail();
        else
            service = new SendSMS();

        return service.Send(number);
    }
}

public interface ISendProvider
{
    string Send(int counter);
}
public class SendEmail : ISendProvider
{


    public string Send(int counter)
    {
        return $"Email {counter} Number Sending ...";
    }
}

public class SendSMS : ISendProvider
{
    public string Send(int counter)
    {
        return $"SMS {counter} Number Sending ...";
    }
}
