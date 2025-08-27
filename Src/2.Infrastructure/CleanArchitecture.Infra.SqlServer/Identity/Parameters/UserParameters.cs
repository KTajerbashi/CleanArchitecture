namespace CleanArchitecture.Infra.SqlServer.Identity.Parameters;

public class UserCreateParameters
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string DisplayName { get; set; }
    public string PhoneNumber { get; set; }
    public string PersonalCode { get; set; }
    public UserCreateParameters(
        string userName,
        string password,
        string email,
        string name,
        string family,
        string displayName,
        string phoneNumber,
        string personalCode)
    {
        UserName = userName;
        Password = password;
        Email = email;
        Name = name;
        Family = family;
        DisplayName = displayName;
        PhoneNumber = phoneNumber;
        PersonalCode = personalCode;
    }

}
