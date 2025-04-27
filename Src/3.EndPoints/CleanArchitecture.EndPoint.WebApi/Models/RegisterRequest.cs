using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.EndPoint.WebApi.Models;

public class RegisterRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [MinLength(8)]
    public string Password { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(10)]
    public string PhoneNumber { get; set; }

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
