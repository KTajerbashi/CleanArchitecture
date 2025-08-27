using CleanArchitecture.Core.Application.Common.Repository;
using CleanArchitecture.Core.Domain.UseCases.Store.Entities;

namespace CleanArchitecture.Core.Application.UseCases.Store.Cart.Repositories;

public interface ICategoryRepository : IRepository<CategoryEntity, long>
{
}
