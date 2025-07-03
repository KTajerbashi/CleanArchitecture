using CleanArchitecture.Core.Application.Library.UseCases.Store.Cart.Repositories;
using CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Store.Cart.Category;

public class CategoryRepository : Repository<CategoryEntity, long>, ICategoryRepository
{
    public CategoryRepository(DatabaseContext context) : base(context)
    {
    }
}
