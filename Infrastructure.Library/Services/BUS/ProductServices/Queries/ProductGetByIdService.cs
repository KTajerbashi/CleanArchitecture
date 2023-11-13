using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Models.Views;
using Application.Library.Repositories.BUS.ProductRepositories.Queries;
using AutoMapper;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Library.Services.BUS.ProductServices.Queries
{
    public class ProductGetByIdService : IProductGetByIdRepository
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public ProductGetByIdService(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<ProductView>> Execute(Guid guid)
        {
            return new Result<ProductView>
            {
                Data = _mapper.Map<ProductView>( await _context.Products.Where(x => x.Guid.Equals(guid)).FirstOrDefaultAsync()),
                Message = "محصول مورد نظر یافت شد",
                Status = true
            };
        }
    }
}
