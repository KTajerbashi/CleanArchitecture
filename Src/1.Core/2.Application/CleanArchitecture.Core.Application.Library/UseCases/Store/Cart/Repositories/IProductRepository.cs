using CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

namespace CleanArchitecture.Core.Application.Library.UseCases.Store.Cart.Repositories;

public interface IProductRepository : IRepository<ProductEntity, long>
{
}
