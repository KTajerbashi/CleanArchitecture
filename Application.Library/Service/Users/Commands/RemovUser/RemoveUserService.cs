using Application.Library.Interfaces;
using Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Library.Entities;

namespace Application.Library.Service
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDatabaseContext _context;
        public RemoveUserService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDTO<User> RemoveUser(long userId)
        {
            var userData = _context.Users.Find(userId);
            if (userData == null)
            {
                return new ResultDTO<User>
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            userData.DeletedDate = DateTime.Now;
            userData.IsDeleted = true;
            _context.SaveChanges();
            return new ResultDTO<User>
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شده است"
            };
        }
    }
}
