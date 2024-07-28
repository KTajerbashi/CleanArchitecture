namespace CleanArchitecture.WebApi.Models;

public class ResetPasswordModel
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
}
