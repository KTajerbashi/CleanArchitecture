using Application.Library.Interfaces;
using Application.Library.Validators;
using Common.Library;
using Common.Library.Configuration;
using Domain.Library.Entities;
using FluentValidation;
using System.ComponentModel;

namespace Application.Library.Service
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDatabaseContext _context;
        public RegisterUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDTO<ResultRegisterUserDto>()
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
                    return new ResultDTO<ResultRegisterUserDto>()
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
                    return new ResultDTO<ResultRegisterUserDto>()
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
                Password= PasswordHash.GetHash(request.Password),
            };
            List<UserRole> userRoles = new List<UserRole>();
            foreach (var item in request.Roles)
            {
                var roles = _context.Roles.Find(item.Id);
                userRoles.Add(new UserRole
                {
                    Role = roles,
                    RoleId = roles.ID,
                    UserId = user.ID,
                    User = user,
                });
            }
            user.UserRoles = userRoles;
            _context.Users.Add(user);
            _context.SaveChanges();

            return new ResultDTO<ResultRegisterUserDto>()
            {
                Data = new ResultRegisterUserDto()
                {
                    UserId = user.ID,
                },
                IsSuccess = true,
                Message = "ثبت نام با موفقیت انجام شد"
            };
        }
    }

}
