using Application.Library.ModelBase;

namespace Application.Library.Repositories.SEC.UserRepositories.Models.DTOs
{
    public class UserDTO : BaseDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
