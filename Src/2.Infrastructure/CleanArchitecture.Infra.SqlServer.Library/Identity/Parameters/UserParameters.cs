namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;

public class UserCreateParameters
{
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string DisplayName { get; private set; }
    public string PhoneNumber { get; private set; }
    public string PersonalCode { get; private set; }
    public UserCreateParameters()
    {
        
    }
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
