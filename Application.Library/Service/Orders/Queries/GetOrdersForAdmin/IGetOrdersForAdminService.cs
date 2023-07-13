using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Service
{
    public interface IGetOrdersForAdminService
    {
        ResultDTO<List<OrdersDto>> Execute(OrderState orderState);
    }

    public class GetOrdersForAdminService : IGetOrdersForAdminService
    {
        private readonly IDatabaseContext _context;
        public GetOrdersForAdminService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<OrdersDto>> Execute(OrderState orderState)
        {
            var orders = _context.Orders
                 .Include(p => p.OrderDetails)
                 .Where(p => p.OrderState == orderState)
                 .OrderByDescending(p => p.ID)
                 .ToList()
                 .Select(p => new OrdersDto
                 {
                     CreateDate = p.CreateDate,
                     OrderId = p.ID,
                     OrderState = p.OrderState,
                     ProductCount = p.OrderDetails.Count(),
                     RequestId = p.RequestPayId,
                     UserId = p.UserId,
                 }).ToList();

            return new ResultDTO<List<OrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };
        }
    }
    public class OrdersDto
    {
        public long OrderId { get; set; }
        public DateTime CreateDate { get; set; }
        public long RequestId { get; set; }
        public long UserId { get; set; }
        public OrderState OrderState { get; set; }
        public int ProductCount { get; set; }

    }
}
