using CleanArchitecture.Application.BaseApplication.Models.DTOs;

namespace CleanArchitecture.Application.Repositories.Identity.Models.DTOs;

public class LoginDTO : ModelDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ReturnUrl { get; set; }
    public bool IsRemember { get; set; }

}



