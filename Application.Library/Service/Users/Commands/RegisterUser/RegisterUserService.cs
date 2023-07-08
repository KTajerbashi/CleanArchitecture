using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;

namespace Application.Library.Service
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDatabaseContext _context;
        public RegisterUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            //  TO DO Fluent Validation
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess= false,
                        Message="پست الکترونیک را وارد کنید ..."
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = " نام را وارد کنید ..."
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Family))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = " فامیلی را وارد کنید ..."
                    };
                }
            }
            catch
            {

                throw;
            }
            User user = new User()
            {
                Email= request.Email,
                Name= request.Name,
                Family= request.Family,
                Username= request.Username,
                Password= request.Password,
            };
            List<UserRole> userRoles = new List<UserRole>();
            foreach (var item in request.Roles)
            {
                var roles = _context.Roles.Find(item.Id);
                userRoles.Add(new UserRole
                {
                    Role = roles,
                    RoleId = roles.Id,
                    UserId = user.Id,
                    User = user,
                });
            }
            user.UserRoles = userRoles;
            _context.Users.Add(user);
            _context.SaveChanges();

            return new ResultDto<ResultRegisterUserDto>()
            {
                Data = new ResultRegisterUserDto()
                {
                    UserId = user.Id,
                },
                IsSuccess = true,
                Message = "ثبت نام با موفقیت انجام شد"
            };
        }
    }

}
