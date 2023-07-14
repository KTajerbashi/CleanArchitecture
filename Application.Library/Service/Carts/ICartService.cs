using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;
namespace Application.Library.Service
{
    //  Table Module Mode Service
    public interface ICartService
    {
        ResultDTO AddToCart(long ProductId, Guid BrowserId);
        ResultDTO RemoveFromCart(long ProductId, Guid BrowserId);
        ResultDTO<CartDto> GetMyCart(Guid BrowserId, long? UserId);

        ResultDTO Add(long CartItemId);
        ResultDTO LowOff(long CartItemId);
    }

    public class CartService : ICartService
    {
        private readonly IDatabaseContext _context;
        public CartService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDTO Add(long CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);
            cartItem.Count++;
            _context.SaveChanges();
            return new ResultDTO()
            {
                IsSuccess = true,
            };
        }

        public ResultDTO AddToCart(long ProductId, Guid BrowserId)
        {
            var cart = _context.Carts.Where(p => p.BrowserId == BrowserId && p.Finished == false).FirstOrDefault();
            if (cart == null)
            {
                Cart newCart = new Cart()
                {
                    Finished = false,
                    BrowserId = BrowserId,
                };
                _context.Carts.Add(newCart);
                _context.SaveChanges();
                cart = newCart;
            }


            var product = _context.Products.Find(ProductId);

            var cartItem = _context.CartItems.Where(p => p.ProductId == ProductId && p.CartId == cart.ID).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Count++;
            }
            else
            {
                CartItem newCartItem = new CartItem()
                {
                    Cart = cart,
                    Count = 1,
                    Price = product.Price,
                    Product = product,

                };
                _context.CartItems.Add(newCartItem);
                _context.SaveChanges();
            }

            return new ResultDTO()
            {
                IsSuccess = true,
                Message = $"محصول  {product.Name} با موفقیت به سبد خرید شما اضافه شد ",
            };
        }

        public ResultDTO<CartDto> GetMyCart(Guid BrowserId, long? UserId)
        {
            try
            {
                var cart = _context.Carts
                    .Include(p => p.CartItems)
                    .ThenInclude(p => p.Product)
                    .ThenInclude(p => p.ProductImages)
                    .Where(p => p.BrowserId == BrowserId && p.Finished == false)
                    .OrderByDescending(p => p.ID)
                    .FirstOrDefault();

                if (cart == null)
                {
                    return new ResultDTO<CartDto>()
                    {
                        Data = new CartDto()
                        {
                            CartItems = new List<CartItemDto>(),

                        },
                    };
                }

                if (UserId != null)
                {
                    var user = _context.Users.Find(UserId);
                    cart.User = user;
                    _context.SaveChanges();
                }

                return new ResultDTO<CartDto>()
                {
                    Data = new CartDto()
                    {
                        ProductCount = cart.CartItems.Count(),
                        SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
                        CartId = cart.ID,
                        CartItems = cart.CartItems.Select(p => new CartItemDto
                        {
                            Count = p.Count,
                            Price = p.Price,
                            Product = p.Product.Name,
                            Id = p.ID,
                            Images = p.Product?.ProductImages?.FirstOrDefault()?.Src ?? "",
                        }).ToList(),
                    },
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public ResultDTO LowOff(long CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);

            if (cartItem.Count <= 1)
            {
                return new ResultDTO()
                {
                    IsSuccess = false,
                };
            }
            cartItem.Count--;
            _context.SaveChanges();
            return new ResultDTO()
            {
                IsSuccess = true,
            };
        }

        public ResultDTO RemoveFromCart(long ProductId, Guid BrowserId)
        {
            var cartitem = _context.CartItems.Where(p => p.Cart.BrowserId == BrowserId).FirstOrDefault();
            if (cartitem != null)
            {
                cartitem.IsDeleted = true;
                cartitem.DeletedDate = DateTime.Now;
                _context.SaveChanges();
                return new ResultDTO
                {
                    IsSuccess = true,
                    Message = "محصول از سبد خرید شما حذف شد"
                };

            }
            else
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };
            }
        }

    }

    public class CartDto
    {
        public long CartId { get; set; }
        public int ProductCount { get; set; }
        public int SumAmount { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }
    public class CartItemDto
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public string Images { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
