using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Commands;
using Application.Library.Repositories.BUS.ProductRepositories.Models.DTOs;
using AutoMapper;
using Domain.Library.Entities.BUS;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Infrastructure.Library.ORM.Dapper;

namespace Infrastructure.Library.Services.BUS.ProductServices.Commands
{
    public class ProductUpdateService : IProductUpdateRepository
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        private readonly IDapperRepository _dapper;
        public ProductUpdateService(DBContextApplication context, IMapper mapper,IDapperRepository dapper)
        {
            _context = context;
            _mapper = mapper;
            _dapper = dapper;
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
