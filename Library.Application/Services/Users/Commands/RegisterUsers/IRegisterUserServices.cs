using Library.Common;
using Library.Domain;

namespace Library.Application
{
    public interface IRegisterUserServices
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }
    public class RegisterUserServices : IRegisterUserServices
    {
        private readonly IDataBaseContext context;
        public RegisterUserServices(IDataBaseContext context)
        {
            this.context = context;
        }

        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            User user =new User()
            {
                Email= request.Email,
                FullName= request.FullName,
            };
            List<UserRole> userRoles = new List<UserRole>();
            foreach (var item in request.roles)
            {
                var role = context.Roles.Find(item.Id);
                userRoles.Add(new UserRole
                {
                    Role = role,
                    RoleId = role.Id,
                    User = user,
                    UserId = user.Id
                });
            }
            user.UserRoles = userRoles;
            context.Users.Add(user);
            context.SaveChanges();

            return new ResultDto<ResultRegisterUserDto>()
            {
                Data = new ResultRegisterUserDto()
                {
                    Id = user.Id,
                },
                IsSuccess = true,
                Message = "با موفقیت انجام شد"
            };
        }
    }
    public class RequestRegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<RolesInRegisterUserDto> roles { get; set; }
    }
    public class RolesInRegisterUserDto
    {
        public int Id { get; set; }
    }
    public class ResultRegisterUserDto
    {
        public int Id { get; set; }

    }
    public enum Roles
    {
        None, Manager, User, Admin, Employee
    }
}
