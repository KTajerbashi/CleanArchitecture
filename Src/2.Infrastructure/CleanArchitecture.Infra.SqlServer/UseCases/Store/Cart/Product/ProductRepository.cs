using CleanArchitecture.Core.Application.UseCases.Store.Cart.Repositories;
using CleanArchitecture.Core.Domain.UseCases.Store.Entities;
using CleanArchitecture.Infra.SqlServer.Common.Repository;
using CleanArchitecture.Infra.SqlServer.Data;

namespace CleanArchitecture.Infra.SqlServer.UseCases.Store.Cart.Product;

public class ProductRepository : Repository<ProductEntity, long>, IProductRepository
{
    public ProductRepository(DatabaseContext context) : base(context)
    {
    }
}
