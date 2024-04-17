using Identity.Library.MessageServices.RabbitMQ.ProducerSending;
using Identity.Library.Models;
using Identity.Library.Services.BackgroundTask.TimerService;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Library.Controllers
{
    [ApiController]
    [Route("Identity/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private int Counter = 0;
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine("Start Method");
            var service = new TimerService(5);
            var autoEvent = new AutoResetEvent(false);

            Console.WriteLine("Change One Calling {2000} {1000}");
            var timer = new Timer(service.Execute,autoEvent,2000,1000);
            
            autoEvent.WaitOne();    ///

            Console.WriteLine("Change One Calling {0} {500}");
            timer.Change(0,500);
            autoEvent.WaitOne();    ///


            Console.WriteLine("End Method");
            timer.Dispose();

            var model = new ResultModel<string>
            {
                Data = string.Empty,
                Message = string.Empty,
                StatusCode=StatusCode(200),
                Result = false,
            };
            return Ok(model);
        }
        [HttpGet]
        public string SendMessages()
        {
            RabbitMQService service = new RabbitMQService(Counter);
            Counter++;
            service.Execute();
            return "";
        }
    }
}
