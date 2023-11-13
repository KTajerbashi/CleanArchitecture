using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Commands;
using Application.Library.Repositories.BUS.ProductRepositories.Models.DTOs;
using AutoMapper;
using Domain.Library.Entities.BUS;
using Infrastructure.Library.DatabaseContextApplication.EF;

namespace Infrastructure.Library.Services.BUS.ProductServices.Commands
{
    public class ProductDeleteService : IProductDeleteRepository
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public ProductDeleteService(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<ProductDTO>> Execute(Guid guid)
        {
            var model = _context.Products.Single(x => x.Guid.Equals(guid));
            model.IsDeleted = true;
            _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
             await _context.SaveChangesAsync();
            return new Result<ProductDTO>
            {
                Data = null,
                Message = "محصول مورد نظر حذف شد",
                Status = true
            };
        }
    }
}
