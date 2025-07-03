using CleanArchitecture.Core.Application.Library.UseCases.Store.Cart.Repositories;
using CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Store.Cart.Product;

public class ProductRepository : Repository<ProductEntity, long>, IProductRepository
{
    public ProductRepository(DatabaseContext context) : base(context)
    {
    }
}
