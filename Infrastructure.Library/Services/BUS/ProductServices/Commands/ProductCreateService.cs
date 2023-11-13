using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Commands;
using Application.Library.Repositories.BUS.ProductRepositories.Models.DTOs;
using AutoMapper;
using Domain.Library.Entities.BUS;
using Infrastructure.Library.DatabaseContextApplication.EF;

namespace Infrastructure.Library.Services.BUS.ProductServices.Commands
{
    public class ProductCreateService : IProducCreatetRepository
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public ProductCreateService(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ProductDTO>> Execute(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return new Result<ProductDTO>
            {
                Data = product,
                Message = "",
                Status = true
            };
        }
    }
}
