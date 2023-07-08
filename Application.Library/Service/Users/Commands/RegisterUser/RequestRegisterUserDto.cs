
namespace Application.Library.Service
{
    public class RequestRegisterUserDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<RolesInRegisterUserDto> Roles { get; set; }
    }
}
