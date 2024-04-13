using CleanArchitecture.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApp.Controllers.Identity
{
    [ApiController]
    [Route("api/Security/[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> Login(CancellationToken cancellationToken)
        {
            var name = "";
            var timer = new Timer((name) =>
            {
                Console.WriteLine(name);
            });
            _logger.LogInformation("======  Start Login  =======");
            string result = "";
            var StartDate  = DateTime.Now;
            for (int i = 1; i <= 5; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogInformation(i.ToString());
                    result = $"Faild";
                }
                Thread.Sleep(1000);
            }
            var EndDate  = DateTime.Now;
            result = $"{result} \nStart Time : {StartDate}\nEnd Time : {EndDate}";
            _logger.LogInformation("======  End Login  =======");
            return result;
        }
        [HttpPost]
        public IActionResult SignUp()
        {
            return Ok(200);
        }

        [HttpGet]//https://localhost:7288/api/Security/Authentication/Timer
        public IActionResult Timer()
        {
            _logger.LogInformation("======  Start Timer  =======");

            var TimerService = new TimerService(5);
            var autoEvent = new AutoResetEvent(false);

            var myTimer = new Timer(TimerService.Execute,autoEvent,2000,300);

            autoEvent.WaitOne();

            _logger.LogInformation("======  Change Timer 0-500 =======");
            myTimer.Change(0,500);
            autoEvent.WaitOne();

            _logger.LogInformation("======  Change Timer 0-1000 =======");
            myTimer.Change(0, 1000);
            autoEvent.WaitOne();


            _logger.LogInformation("======  End Timer  =======");
            return Ok(200);
        }
    }
}
