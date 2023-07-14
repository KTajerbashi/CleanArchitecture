using Application.Library.Interfaces;
using Common.Library;
using Common.Library.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Service
{
    public interface IUserLoginServices
    {
        ResultDTO<ResultUserLoginDTO> Execute(string Username, string Password);
    }
    public class UserLoginServices : IUserLoginServices
    {
        IDatabaseContext _context;
        public UserLoginServices(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ResultUserLoginDTO> Execute(string Username, string Password)
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                return new ResultDTO<ResultUserLoginDTO>()
                {
                    Data = new ResultUserLoginDTO()
                    {

                    },
                    IsSuccess = false,
                    Message = "نام کاربری و رمز کاربری اشتباه است"
                };
            }
            var user = _context.Users.Include(p => p.UserRoles)
                .ThenInclude(p => p.Role)
                .Where(p => p.Email.Equals(Username)
                && p.IsActive && !p.IsDeleted
                ).FirstOrDefault();
            if (user == null)
            {
                return new ResultDTO<ResultUserLoginDTO>()
                {
                    Data = new ResultUserLoginDTO()
                    {
                    },
                    IsSuccess = false,
                    Message = "کاربری با این اطلاعات پیدا نشد"
                };

            }
            bool resultVerifyPassword = PasswordHash.Verfiyed(Password,user.Password);
            if (!resultVerifyPassword)
            {
                return new ResultDTO<ResultUserLoginDTO>()
                {
                    Data = new ResultUserLoginDTO()
                    {
                    },
                    IsSuccess = false,
                    Message = "رمز کاربری اشتباه است"
                };
            }
            var roles = new List<string>();

            foreach (var item in user.UserRoles)
            {
                roles.Add(item.Role.Title);
            }

            var result = new ResultDTO<ResultUserLoginDTO>()
            {
                Data = new ResultUserLoginDTO()
                {
                    Roles = roles,
                    UserId = user.ID,
                    Name= user.Name,
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد"
            };
            return result;

        }
    }
    public class ResultUserLoginDTO
    {
        public ResultUserLoginDTO() { }

        public long UserId { get; set; }
        public bool IsSuccess { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }


    }
}
