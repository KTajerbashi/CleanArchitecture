using Application.Library.Interfaces;
using Common.Library;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Service
{
    public interface IGetProductDetailForSiteService
    {
        ResultDTO<ProductDetailForSiteDto> Execute(long Id);
    }

    public class GetProductDetailForSiteService : IGetProductDetailForSiteService
    {
        private readonly IDatabaseContext _context;
        public GetProductDetailForSiteService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ProductDetailForSiteDto> Execute(long Id)
        {
            var Product = _context.Products
                .Include(p=> p.Category)
                .ThenInclude(p=>p.ParentCategory)
                .Include(p=>p.ProductImages)
                .Include(p=> p.ProductFeatures)
                .Where(p=> p.ID==Id).FirstOrDefault();

            if (Product == null)
            {
                throw new Exception("Product Not Found.....");
            }

            return new ResultDTO<ProductDetailForSiteDto>()
            {
                Data = new ProductDetailForSiteDto
                {
                    Brand = Product.Brand,
                    Category = $"{Product.Category.ParentCategory.Name}  - {Product.Category.Name}",
                    Description = Product.Description,
                    Id = Product.ID,
                    Price = Product.Price,
                    Title = Product.Name,
                    Images = Product.ProductImages.Select(p => p.Src).ToList(),
                    Features = Product.ProductFeatures.Select(p => new ProductDetailForSite_FeaturesDto
                    {
                        DisplayName = p.DisplayName,
                        Value = p.Value,
                    }).ToList(),

                },
                IsSuccess = true,
            };

        }
    }

    public class ProductDetailForSiteDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<string> Images { get; set; }
        public List<ProductDetailForSite_FeaturesDto> Features { get; set; }
    }

    public class ProductDetailForSite_FeaturesDto
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }




}
