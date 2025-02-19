using CleanArchitecture.Core.Application.Library.Common.Models.DTOs;

namespace CleanArchitecture.Core.Application.Library.Identity.Models.DTOS;

public class RegisterDTO : BaseDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
