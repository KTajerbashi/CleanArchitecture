using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Models.Views;
using Application.Library.Repositories.BUS.ProductRepositories.Queries;
using AutoMapper;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Library.Services.BUS.ProductServices.Queries
{
    public class ProductGetBySearchService : IProductGetBySearchRepository
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public ProductGetBySearchService(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
