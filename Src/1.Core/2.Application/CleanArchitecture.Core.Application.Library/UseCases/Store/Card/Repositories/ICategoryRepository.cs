using CleanArchitecture.Core.Application.Library.Common.Repository;
using CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

namespace CleanArchitecture.Core.Application.Library.UseCases.Store.Card.Repositories;

public interface ICategoryRepository : IRepository<CategoryEntity, long>
{
}
