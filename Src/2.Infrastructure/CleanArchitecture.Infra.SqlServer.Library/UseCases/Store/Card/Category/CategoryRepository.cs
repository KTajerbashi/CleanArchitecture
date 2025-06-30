using CleanArchitecture.Core.Application.Library.UseCases.Store.Card.Repositories;
using CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Store.Card.Category;

public class CategoryRepository : Repository<CategoryEntity, long>, ICategoryRepository
{
    public CategoryRepository(DatabaseContext context) : base(context)
    {
    }
}
