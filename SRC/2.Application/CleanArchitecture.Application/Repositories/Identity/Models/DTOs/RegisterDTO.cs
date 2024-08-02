using CleanArchitecture.Application.BaseApplication.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Repositories.Identity.Models.DTOs;

public class RegisterDTO : ModelDTO
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



