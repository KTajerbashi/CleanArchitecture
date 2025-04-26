using CleanArchitecture.Core.Application.Library.Common.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.EndPoint.WebApi.Models;

public class LoginRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
   
    public bool IsRemember { get; set; }
}

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

public class RefreshTokenRequest
{
    [Required]
    public string Token { get; set; }

    [Required]
    public string RefreshToken { get; set; }
}



public class AuthenticationResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public int ExpiresIn { get; set; }
    public long UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public Dictionary<string, string> Claims { get; set; }
}