namespace CleanArchitecture.WebApi.Models;

public class ChangePasswordModel
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}