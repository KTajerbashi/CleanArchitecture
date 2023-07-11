using Application.Library.Interfaces;
using Common.Library;

namespace Application.Library.Service
{
    public interface IUserSatusChangeService
    {
        ResultDTO Execute(long UserId);
    }

    public class UserSatusChangeService : IUserSatusChangeService
    {
        private readonly IDatabaseContext _context;


        public UserSatusChangeService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDTO Execute(long UserId)
        {
            var user = _context.Users.Find( UserId);
            if (user == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            string userstate = user.IsActive == true ? "فعال" : "غیر فعال";
            return new ResultDTO()
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {userstate} شد!",
            };
        }
    }
}
