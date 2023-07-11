using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Service
{
    public interface IGetProductDetailForAdminService
    {
        ResultDTO<ProductDetailForAdmindto> Execute(long Id);

    }

    public class GetProductDetailForAdminService : IGetProductDetailForAdminService
    {
        private readonly IDatabaseContext _context;

        public GetProductDetailForAdminService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDTO<ProductDetailForAdmindto> Execute(long Id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .Where(p => p.ID == Id)
                .FirstOrDefault();
            return new ResultDTO<ProductDetailForAdmindto>()
            {
                Data = new ProductDetailForAdmindto()
                {
                    Brand = product.Brand,
                    Category = GetCategory(product.Category),
                    Description = product.Description,
                    Displayed = product.Displayed,
                    Id = product.ID,
                    Inventory = product.Inventory,
                    Name = product.Name,
                    Price = product.Price,
                    Features = product.ProductFeatures.ToList().Select(p => new ProductDetailFeatureDto
                    {
                        Id = p.ID,
                        DisplayName = p.DisplayName,
                        Value = p.Value
                    }).ToList(),
                    Images = product.ProductImages.ToList().Select(p => new ProductDetailImagesDto
                    {
                        Id = p.ID,
                        Src = p.Src,
                    }).ToList(),
                },
                IsSuccess = true,
                Message = "",
            };
        }

        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : "";
            return result += category.Name;
        }
    }

    public class ProductDetailForAdmindto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public List<ProductDetailFeatureDto> Features { get; set; }
        public List<ProductDetailImagesDto> Images { get; set; }
    }


    public class ProductDetailImagesDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
    }

    public class ProductDetailFeatureDto
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
