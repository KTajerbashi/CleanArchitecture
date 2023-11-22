using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Models.Views;
using Application.Library.Repositories.BUS.ProductRepositories.Queries;
using AutoMapper;
using Infrastructure.Library.BaseServices;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Infrastructure.Library.ORM.Dapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Library.Services.BUS.ProductServices.Queries
{
    public class ProductGetAllService : BaseService, IProductGetAllRepository
    {
        public ProductGetAllService(DBContextApplication context, IMapper mapper, IDapperRepository dapper) : base(context, mapper, dapper)
        {
        }

        public async Task<Result<List<ProductView>>> Execute()
        {
            var res = _dapper.ExecuteDapper<ProductView>("",new Dapper.DynamicParameters
            {

            });
            return new Result<List<ProductView>>
            {
                Data = _mapper.Map<List<ProductView>>(await _context.Products.ToListAsync()),
                Message = "تمام محصولات با موفقبت واکشی شدند",
                Status = true
            };
        }
    }
}
