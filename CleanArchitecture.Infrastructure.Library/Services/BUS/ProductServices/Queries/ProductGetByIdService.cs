using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Models.Views;
using Application.Library.Repositories.BUS.ProductRepositories.Queries;
using AutoMapper;
using CleanArchitecture.Infrastructure.Library.BaseServices;
using CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.EF;
using CleanArchitecture.Infrastructure.Library.ORM.Dapper;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Library.Services.BUS.ProductServices.Queries
{
    public class ProductGetByIdService : BaseService, IProductGetByIdRepository
    {
        public ProductGetByIdService(DBContextApplication context, IMapper mapper, IDapperRepository dapper) : base(context, mapper, dapper)
        {
        }

        public async Task<Result<ProductView>> Execute(Guid guid)
        {
            return new Result<ProductView>
            {
                Data = _mapper.Map<ProductView>(await _context.Products.Where(x => x.Guid.Equals(guid)).FirstOrDefaultAsync()),
                Message = "محصول مورد نظر یافت شد",
                Status = true
            };
        }
    }
}
