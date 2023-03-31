namespace Library.Application
{
    public class RequestRegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<RolesInRegisterUserDto> roles { get; set; }
    }
}
