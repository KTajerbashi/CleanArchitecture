using CleanArchitecture.Application.BaseApplication.Models.Views;

namespace CleanArchitecture.Application.Repositories.Identity.Models.Views;

public class ProfileView : ModelView
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}



