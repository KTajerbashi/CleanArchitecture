using Application.Library.Repositories.BUS.ProductRepositories.Commands;
using Application.Library.Repositories.BUS.ProductRepositories.Queries;

namespace Application.Library.Patterns.Facad.BUS
{
    public interface IProductFacad
    {
        IProducCreatetRepository CreateProductRepository { get; }
        IProductUpdateRepository UpdateProductRepository { get; }
        IProductDeleteRepository DeleteProductRepository { get; }
        IProductGetAllRepository GetAllProductRepository { get; }
        IProductGetByIdRepository GetProductByIdRepository { get; }
        IProductGetBySearchRepository GetProductBySearchRepository { get; }
    }

}
