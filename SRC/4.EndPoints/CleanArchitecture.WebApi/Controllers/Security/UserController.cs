using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;
using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.Domain.Security;
using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Security;

public class UserController : BaseController
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
