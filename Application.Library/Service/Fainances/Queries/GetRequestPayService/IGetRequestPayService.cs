using Application.Library.Interfaces;
using Common.Library;

namespace Application.Library.Service
{
    public interface IGetRequestPayService
    {
        ResultDTO<RequestPayDto> Execute(Guid guid);
    }

    public class GetRequestPayService : IGetRequestPayService
    {
        private readonly IDatabaseContext _context;
        public GetRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<RequestPayDto> Execute(Guid guid)
        {
            var requestPay = _context.RequestPays.Where(p => p.Guid == guid).FirstOrDefault();

            if (requestPay != null)
            {
                return new ResultDTO<RequestPayDto>()
                {
                    Data = new RequestPayDto()
                    {
                        Amount = requestPay.Amount,
                        Id = requestPay.ID,
                    }
                };
            }
            else
            {
                throw new Exception("request pay not found");
            }
        }
    }

    public partial class RequestPayDto
    {
        public long Id { get; set; }
        public int Amount { get; set; }

    }
}
