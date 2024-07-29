using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;
using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CleanArchitecture.WebApi.Controllers.Home;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> logger;
    private readonly IUserRepository _userRepository;
    public HomeController(IUserRepository userRepository, ILogger<HomeController> logger)
    {
        _userRepository = userRepository;
        Log.Information("Logging an entry with custom data");
        Log.ForContext("EntityName", "MyEntity")
           .ForContext("LastData", "OldData")
           .ForContext("NewData", "NewData")
           .ForContext("ServiceName", "MyService")
           .ForContext("MethodName", "MyMethod")
           .ForContext("NameSpace", "MyNamespace")
           .ForContext("Parameters", "param1, param2")
           .ForContext("CreateDate", DateTime.Now)
           .Information("Custom log entry");
        this.logger = logger;
        logger.LogInformation("1234000");
    }


    [HttpPost]
    public async Task<IActionResult> Create(UserDTO user) => await OkResultAsync(_userRepository.InsertAsync(user));

    [HttpPut]
    public async Task<IActionResult> Update(UserDTO user) => await OkResultAsync(_userRepository.UpdateAsync(user));


    [HttpDelete]
    public async Task<IActionResult> Delete(long id) => await OkResultAsync(_userRepository.Delete(id));

    [HttpGet]
    public async Task<IActionResult> Get() => await OkResultAsync(_userRepository.GetAsync());

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(long id) => await OkResultAsync(_userRepository.GetAsync(id));

}

