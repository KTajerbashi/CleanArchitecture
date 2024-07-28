namespace CleanArchitecture.WebApi.Models;

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsRemember { get; set; }
}
