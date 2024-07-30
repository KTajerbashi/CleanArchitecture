using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Principal;

namespace CleanArchitecture.WebApi.Controllers.Account.Models;

public class RegisterModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarFile { get; set; } = "";
    public string NationalCode { get; set; } = "";
    public string SignFile { get; set; } = "";

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }

}

public class LoginModel 
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ReturnUrl { get; set; }
    public bool IsRemember { get; set; }
}


public class UserModel
{
    public List<Claim> Claims { get; set; }

    public List<ClaimsIdentity> Identities { get; set; }
    public IIdentity Identity { get; set; }
}

