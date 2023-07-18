
namespace Application.Library.Service
{
    public class RequestRegisterUserDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePasword { get; set; }
        public int Age { get; set; }
        public List<string> Address { get; set; }
        public List<RolesInRegisterUserDto> Roles { get; set; }
    }
}
