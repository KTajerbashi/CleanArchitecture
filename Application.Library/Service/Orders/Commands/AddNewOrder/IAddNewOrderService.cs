using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Service
{
    public interface IAddNewOrderService
    {
        ResultDTO Execute(RequestAddNewOrderSericeDto request);
    }

    public class AddNewOrderService : IAddNewOrderService
    {
        private readonly IDatabaseContext _context;
        public AddNewOrderService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDTO Execute(RequestAddNewOrderSericeDto request)
        {
            var user = _context.Users.Find(request.UserId);
            var requestPay = _context.RequestPays.Find(request.RequestPayId);
            var cart = _context.Carts.Include(p => p.CartItems)
                .ThenInclude(p=> p.Product)
                .Where(p => p.ID == request.CartId).FirstOrDefault();

            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;
            requestPay.RefId = request.RefId;
            requestPay.Authority = requestPay.Authority;
            cart.Finished = true;

            Order order = new Order()
            {
                Address = "",
                OrderState = OrderState.Processing,
                RequestPay = requestPay,
                User = user,

            };
            _context.Orders.Add(order);

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cart.CartItems)
            {

                OrderDetail orderDetail = new OrderDetail()
                {
                    Count = item.Count,
                    Order = order,
                    Price = item.Product.Price,
                    Product = item.Product,
                };
                orderDetails.Add(orderDetail);
            }


            _context.OrderDetails.AddRange(orderDetails);

            _context.SaveChanges();
            
            return new ResultDTO()
            {
                IsSuccess = true,
                Message = "",
            };
        }
    }
    public class RequestAddNewOrderSericeDto
    {
        public long CartId { get; set; }
        public long RequestPayId { get; set; }
        public long UserId { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;

    }
}
