using Application.Library.Interfaces;
using Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Application.Library.Service
{
    public interface IGetRequestPayService
    {
        ResultDTO<RequestPayDTO> Execute(Guid guid);
    }

    public class GetRequestPayService : IGetRequestPayService
    {
        private readonly IDatabaseContext _context;
        public GetRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<RequestPayDTO> Execute(Guid guid)
        {
            var requestPay = _context.RequestPays.Where(p => p.Guid == guid).FirstOrDefault();

            if (requestPay != null)
            {
                return new ResultDTO<RequestPayDTO>()
                {
                    Data = new RequestPayDTO()
                    {
                        Amount = requestPay.Amount,
                        Id=requestPay.ID,
                    }
                };
            }
            else
            {
                throw new Exception("request pay not found");
            }
        }
    }

    public class RequestPayDTO
    {
        public int Amount { get; set; }
        public long Id { get; set; }

    }
}
