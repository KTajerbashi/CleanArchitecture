using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Service
{
    public interface IGetUserOrdersService
    {
        ResultDTO<List<GetUserOrdersDto>> Execute(long UserId);
    }


    public class GetUserOrdersService : IGetUserOrdersService
    {
        private readonly IDatabaseContext _context;

        public GetUserOrdersService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDTO<List<GetUserOrdersDto>> Execute(long UserId)
        {
            var orders = _context.Orders
                .Include(p => p.OrderDetails)
                .ThenInclude(p => p.Product)
                .Where(p => p.UserId == UserId)
                .OrderByDescending(p => p.ID).ToList().Select(p => new GetUserOrdersDto
                {
                    OrderId = p.ID,
                    OrderState = p.OrderState,
                    RequestPayId = p.RequestPayId,
                    OrderDetails = p.OrderDetails.Select(o => new OrderDetailsDto
                    {
                        Count = o.Count,
                        OrderDetailId = o.ID,
                        Price = o.Price,
                        ProductId = o.ProductId,
                        ProductName = o.Product.Name,
                    }).ToList(),
                }).ToList();

            return new ResultDTO<List<GetUserOrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };


        }
    }

    public class GetUserOrdersDto
    {
        public long OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public long RequestPayId { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
    }

    public class OrderDetailsDto
    {
        public long OrderDetailId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
