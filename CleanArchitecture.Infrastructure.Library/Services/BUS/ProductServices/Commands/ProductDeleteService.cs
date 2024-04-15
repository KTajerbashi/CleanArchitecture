using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Commands;
using Application.Library.Repositories.BUS.ProductRepositories.Models.DTOs;
using AutoMapper;
using CleanArchitecture.Infrastructure.Library.BaseServices;
using CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.EF;
using CleanArchitecture.Infrastructure.Library.ORM.Dapper;

namespace CleanArchitecture.Infrastructure.Library.Services.BUS.ProductServices.Commands
{
    public class ProductDeleteService : BaseService, IProductDeleteRepository
    {
        public ProductDeleteService(DBContextApplication context, IMapper mapper, IDapperRepository dapper) : base(context, mapper, dapper)
        {
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
