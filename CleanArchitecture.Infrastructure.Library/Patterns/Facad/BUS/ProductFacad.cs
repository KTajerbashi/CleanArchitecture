using Application.Library.Repositories.BUS.ProductRepositories.Commands;
using Application.Library.Repositories.BUS.ProductRepositories.Queries;
using AutoMapper;
using Application.Library.Patterns.Facad.BUS;
using CleanArchitecture.Infrastructure.Library.Services.BUS.ProductServices.Queries;
using CleanArchitecture.Infrastructure.Library.Services.BUS.ProductServices.Commands;
using CleanArchitecture.Infrastructure.Library.ORM.Dapper;
using CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.EF;

namespace CleanArchitecture.Infrastructure.Library.Patterns.Facad.BUS
{
    public class ProductFacad : IProductFacad
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        private readonly IDapperRepository _dapper;
        public ProductFacad(DBContextApplication context, IMapper mapper, IDapperRepository dapper)
        {
            _context = context;
            _mapper = mapper;
            _dapper = dapper;
        }
        private ProductCreateService _productCreateService;
        public IProducCreatetRepository CreateProductRepository { get => _productCreateService = _productCreateService ?? new ProductCreateService(_context, _mapper, _dapper); }

        private ProductUpdateService _productUpdateService;
        public IProductUpdateRepository UpdateProductRepository { get => _productUpdateService = _productUpdateService ?? new ProductUpdateService(_context, _mapper, _dapper); }

        private ProductDeleteService _productDeleteService;
        public IProductDeleteRepository DeleteProductRepository { get => _productDeleteService = _productDeleteService ?? new ProductDeleteService(_context, _mapper, _dapper); }

        private ProductGetAllService _getAllProductService;
        public IProductGetAllRepository GetAllProductRepository { get => _getAllProductService = _getAllProductService ?? new ProductGetAllService(_context, _mapper, _dapper); }

        private ProductGetByIdService _getProductByIdService;
        public IProductGetByIdRepository GetProductByIdRepository { get => _getProductByIdService = _getProductByIdService ?? new ProductGetByIdService(_context, _mapper, _dapper); }

        private ProductGetBySearchService _getProductBySearchService;
        public IProductGetBySearchRepository GetProductBySearchRepository { get => _getProductBySearchService = _getProductBySearchService ?? new ProductGetBySearchService(_context, _mapper, _dapper); }
    }
}
