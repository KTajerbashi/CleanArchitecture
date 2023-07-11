using Application.Library.Interfaces;
using Common.Library;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Service
{
    public interface IGetProductForSiteService
    {
        ResultDTO<ResultProductForSiteDto> Execute(int Page);
    }


    public class GetProductForSiteService : IGetProductForSiteService
    {

        private readonly IDatabaseContext _context;
        public GetProductForSiteService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ResultProductForSiteDto> Execute(int Page)
        {
            int totalRow = 0;
            var poducts = _context.Products
                .Include(p=> p.ProductImages)
                .ToPaged(Page, 5, out totalRow);

            Random rd = new Random();
            return new ResultDTO<ResultProductForSiteDto>
            {
                Data = new ResultProductForSiteDto
                {
                    TotalRow = totalRow,
                    Products = poducts.Select(p => new ProductForSiteDto
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
        }
    }

    public class ResultProductForSiteDto
    {

        public List<ProductForSiteDto> Products { get; set; }
        public int TotalRow { get; set; }
    }

    public class ProductForSiteDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public int Star { get; set; }
        public int Price { get; set; }
    }

}
