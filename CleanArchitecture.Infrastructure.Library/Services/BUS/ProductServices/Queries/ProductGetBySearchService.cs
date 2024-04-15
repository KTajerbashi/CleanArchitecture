using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Models.Views;
using Application.Library.Repositories.BUS.ProductRepositories.Queries;
using AutoMapper;
using CleanArchitecture.Infrastructure.Library.BaseServices;
using CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.EF;
using CleanArchitecture.Infrastructure.Library.ORM.Dapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace CleanArchitecture.Infrastructure.Library.Services.BUS.ProductServices.Queries
{
    public class ProductGetBySearchService : BaseService, IProductGetBySearchRepository
    {
        public ProductGetBySearchService(DBContextApplication context, IMapper mapper, IDapperRepository dapper) : base(context, mapper, dapper)
        {
        }
        public async Task<Result<List<ProductView>>> Execute(string search)
        {
            var result = await _context.Products.Where(p => p.Name.Contains(search) || p.Title.Contains(search)).ToListAsync();
            return new Result<List<ProductView>>
            {
                Data = _mapper.Map<List<ProductView>>(result),
                Message = "محصول مورد نظر یافت شد",
                Status = true
            };
        }
    }
}
