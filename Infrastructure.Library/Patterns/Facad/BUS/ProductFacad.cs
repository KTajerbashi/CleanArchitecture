using Application.Library.Repositories.BUS.ProductRepositories.Commands;
using Application.Library.Repositories.BUS.ProductRepositories.Queries;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Infrastructure.Library.Services.BUS.ProductServices.Commands;
using Infrastructure.Library.Services.BUS.ProductServices.Queries;
using AutoMapper;
using Application.Library.Patterns.Facad.BUS;

namespace Infrastructure.Library.Patterns.Facad.BUS
{
    public class ProductFacad : IProductFacad
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public ProductFacad(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private ProductCreateService _productCreateService;
        public IProducCreatetRepository CreateProductRepository { get => _productCreateService = _productCreateService ?? new ProductCreateService(_context, _mapper); }

        private ProductUpdateService _productUpdateService;
        public IProductUpdateRepository UpdateProductRepository { get => _productUpdateService = _productUpdateService ?? new ProductUpdateService(_context, _mapper); }

        private ProductDeleteService _productDeleteService;
        public IProductDeleteRepository DeleteProductRepository { get => _productDeleteService = _productDeleteService ?? new ProductDeleteService(_context, _mapper); }

        private ProductGetAllService _getAllProductService;
        public IProductGetAllRepository GetAllProductRepository { get => _getAllProductService = _getAllProductService ?? new ProductGetAllService(_context, _mapper); }

        private ProductGetByIdService _getProductByIdService;
        public IProductGetByIdRepository GetProductByIdRepository { get => _getProductByIdService = _getProductByIdService ?? new ProductGetByIdService(_context, _mapper); }

        private ProductGetBySearchService _getProductBySearchService;
        public IProductGetBySearchRepository GetProductBySearchRepository { get => _getProductBySearchService = _getProductBySearchService ?? new ProductGetBySearchService(_context, _mapper); }
    }
}
