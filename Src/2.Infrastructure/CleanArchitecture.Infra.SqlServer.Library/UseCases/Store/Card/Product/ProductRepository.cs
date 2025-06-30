using CleanArchitecture.Core.Application.Library.UseCases.Store.Card.Repositories;
using CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Store.Card.Product;

public class ProductRepository : Repository<ProductEntity, long>, IProductRepository
{
    public ProductRepository(DatabaseContext context) : base(context)
    {
    }
}
