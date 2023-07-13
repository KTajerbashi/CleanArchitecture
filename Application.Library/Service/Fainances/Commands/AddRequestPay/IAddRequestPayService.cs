using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;

namespace Application.Library.Service
{
    public interface IAddRequestPayService
    {
        ResultDTO<ResultRequestPayDto> Execute(int Amount, long UserId);
    }


    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly IDatabaseContext _context;
        public AddRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ResultRequestPayDto> Execute(int Amount, long UserId)
        {
            var user = _context.Users.Find(UserId);
            RequestPay requestPay = new RequestPay()
            {
                Amount = Amount,
                Guid = Guid.NewGuid(),
                IsPay = false,
                User = user,

            };
            _context.RequestPays.Add(requestPay);
            _context.SaveChanges();

            return new ResultDTO<ResultRequestPayDto>()
            {
                Data = new ResultRequestPayDto
                {
                    guid = requestPay.Guid,
                    Amount = requestPay.Amount,
                    Email = user.Email,
                    RequestPayId = requestPay.ID,
                },
                IsSuccess = true,
            };
        }
    }

    public class ResultRequestPayDto
    {
        public Guid guid { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public long RequestPayId { get; set; }
    }
}
