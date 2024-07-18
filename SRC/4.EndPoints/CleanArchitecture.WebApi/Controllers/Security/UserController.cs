using CleanArchitecture.Application.Repositories.Security.User.Model;
using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.Domain.Security;
using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Security;

public class UserController : BaseController
{
    private readonly IUserRepository commandUserRepository;
    public UserController(IUserRepository commandUserRepository)
    {
        this.commandUserRepository = commandUserRepository;
    }


    [HttpPost]
    public async Task<IActionResult> Create(UserDTO user)
    {
        var entity = new UserEntity
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gender = user.Gender,
            NationalCode = user.NationalCode,
            AvatarFile = user.AvatarFile,
            SignFile = user.SignFile,

        };
        commandUserRepository.Insert(entity);
        await commandUserRepository.SaveChangeAsync();
        return Ok(entity);
    }
}
