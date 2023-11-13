using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Commands;
using Application.Library.Repositories.BUS.ProductRepositories.Models.DTOs;
using AutoMapper;
using Domain.Library.Entities.BUS;
using Infrastructure.Library.DatabaseContextApplication.EF;

namespace Infrastructure.Library.Services.BUS.ProductServices.Commands
{
    public class ProductUpdateService : IProductUpdateRepository
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public ProductUpdateService(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<ProductDTO>> Execute(ProductDTO user, Guid guid)
        {
            var model = _context.Products.Where(x => x.Guid.Equals(guid)).Single();
            model = _mapper.Map<Product>(user);
            _context.Products.Update(model);
            await _context.SaveChangesAsync();
            return new Result<ProductDTO>
            {
                Data = user,
                Status = true,
                Message = "محصول با موفقیت ویرایش شد"
            };
        }
    }
}
