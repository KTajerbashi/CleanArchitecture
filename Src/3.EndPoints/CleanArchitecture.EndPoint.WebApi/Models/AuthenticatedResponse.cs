namespace CleanArchitecture.EndPoint.WebApi.Models;


public class AuthenticatedResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public int ExpiresIn { get; set; }
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public IList<string> Roles { get; set; }
    public Dictionary<string, string> Claims { get; set; }
}