using CleanArchitecture.Application.Repositories.Security.Model;
using CleanArchitecture.Application.Repositories.Security.Repository;
using CleanArchitecture.Domain.Security;
using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Security;

public class HomeController : BaseController
{
    private readonly ICommandUserRepository commandUserRepository;
    private readonly IQueryUserRepository queryUserRepository;

    public HomeController(ICommandUserRepository commandUserRepository, IQueryUserRepository queryUserRepository)
    {
        this.commandUserRepository = commandUserRepository;
        this.queryUserRepository = queryUserRepository;
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
        commandUserRepository.SaveChange();
        return Ok(entity);
    }
}
