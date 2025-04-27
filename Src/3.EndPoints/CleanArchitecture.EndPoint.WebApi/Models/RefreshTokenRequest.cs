using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.EndPoint.WebApi.Models;

public class RefreshTokenRequest
{
    [Required]
    public string Token { get; set; }

    [Required]
    public string RefreshToken { get; set; }
}
