using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Models.Views;
using Application.Library.Repositories.BUS.ProductRepositories.Queries;
using AutoMapper;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Library.Services.BUS.ProductServices.Queries
{
    public class ProductGetAllService : IProductGetAllRepository
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public ProductGetAllService(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<List<ProductView>>> Execute()
        {
            return new Result<List<ProductView>>
            {
                Data= _mapper.Map<List<ProductView>>(await _context.Products.ToListAsync()),
                Message ="تمام محصولات با موفقبت واکشی شدند",
                Status = true
            };
        }
    }
}
