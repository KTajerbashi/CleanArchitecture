namespace CleanArchitecture.Domain.TestLibrary.Security.User
{
    public class UserTestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}
