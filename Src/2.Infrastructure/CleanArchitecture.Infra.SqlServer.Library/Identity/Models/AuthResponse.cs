using CleanArchitecture.Core.Application.Library.Common.Models.DTOs;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Models;

public class UserProfileDTO : BaseDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string DisplayName { get => $"{Name} {Family}"; }
}


public class IdentityOption
{
    public JwtOptions Jwt { get; set; }
}
public class JwtOptions
{
    public int ExpireMinutes { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
}

public class AuthResponse
{
    public string RefreshToken { get; set; }
    public string Token { get; set; }
    public UserProfileDTO User { get; set; }
    public DateTime ExpiresIn { get; set; }
}

