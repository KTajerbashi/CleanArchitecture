using Application.Library.Interfaces;
using Common.Library;

namespace Application.Library.Service
{
    public interface IEditUserService
    {
        ResultDTO Execute(RequestEdituserDto request);
    }
    public class EditUserService : IEditUserService
    {
        private readonly IDatabaseContext _context;

        public EditUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(RequestEdituserDto request)
        {
            var user = _context.Users.Find(request.UserId);
            if (user == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.Name = request.Name;
            _context.SaveChanges();

            return new ResultDTO()
            {
                IsSuccess = true,
                Message = "ویرایش کاربر انجام شد"
            };

        }
    }


    public class RequestEdituserDto
    {
        public long UserId { get; set; }
        public string Name { get; set; }
    }
}
