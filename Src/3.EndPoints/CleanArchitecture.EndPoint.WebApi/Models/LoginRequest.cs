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
