using Application.Library.Interfaces;
using Common.Library;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Service
{
    public interface IGetRequestPayForAdminService
    {
        ResultDTO<List<RequestPayDto>> Execute();
    }

    public class GetRequestPayForAdminService : IGetRequestPayForAdminService
    {
        private readonly IDatabaseContext _context;
        public GetRequestPayForAdminService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<RequestPayDto>> Execute()
        {
            var requestPay = _context.RequestPays
                .Include(p=>p.User)
                .ToList()
                 .Select(p => new RequestPayDto
                 {
                     ID=p.ID,
                     Amount = p.Amount,
                     Authority = p.Authority,
                     Guid = p.Guid,
                     IsPay = p.IsPay,
                     PayDate = p.PayDate,
                     RefId = p.RefId,
                     UserId = p.UserId,
                     UserName = p.User.Name
                 }).ToList();

            return new ResultDTO<List<RequestPayDto>>()
            {
                Data = requestPay,
                IsSuccess = true,
            };
        }
    }
    public partial class RequestPayDto
    {
        public long ID { get; set; }
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public long UserId { get; set; }
        //public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
    }
}
