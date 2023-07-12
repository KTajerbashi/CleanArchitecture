using Application.Library.Interfaces;
using Common.Library;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Service
{
    public class GetProductForSiteService : IGetProductForSiteService
    {

        private readonly IDatabaseContext _context;
        public GetProductForSiteService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ResultProductForSiteDto> Execute(Ordering ordering, string SearchKey, int Page, int pageSize, long? CatId)
        {
            int totalRow = 0;
            var productQuery = _context.Products
                .Include(p => p.ProductImages).AsQueryable();

            if (CatId != null)
            {
                productQuery = productQuery.Where(p => p.CategoryId == CatId || p.Category.ParentCategoryId == CatId).AsQueryable();
            }
            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                productQuery = productQuery.Where(p => p.Name.Contains(SearchKey) || p.Brand.Contains(SearchKey)).AsQueryable();
            }

            switch (ordering)
            {
                case Ordering.NotOrder:
                    productQuery = productQuery.OrderByDescending(p => p.ID).AsQueryable();
                    break;
                case Ordering.MostVisited:
                    productQuery = productQuery.OrderByDescending(p => p.ViewCount).AsQueryable();
                    break;
                case Ordering.Bestselling:
                    break;
                case Ordering.MostPopular:
                    break;
                case Ordering.theNewest:
                    productQuery = productQuery.OrderByDescending(p => p.ID).AsQueryable();
                    break;
                case Ordering.Cheapest:
                    productQuery = productQuery.OrderBy(p => p.Price).AsQueryable();
                    break;
                case Ordering.theMostExpensive:
                    productQuery = productQuery.OrderByDescending(p => p.Price).AsQueryable();
                    break;
                default:
                    break;
            }

            var product=productQuery.ToPaged(Page,  pageSize, out totalRow);

            Random rd = new Random();
            var item = new ResultDTO<ResultProductForSiteDto>

            {
                Data = new ResultProductForSiteDto
                {
                    TotalRow = totalRow,
                    Products = product.Select(p => new ProductForSiteDTO
                    {
                        ID = p.ID,
                        Star = rd.Next(1, 5),
                        Title = p.Name,
                        ImageSrc = p.ProductImages.FirstOrDefault().Src,
                        Price = p.Price
                    }).ToList(),
                },
                IsSuccess = true,
            };
            return item;
        }
    }

}
