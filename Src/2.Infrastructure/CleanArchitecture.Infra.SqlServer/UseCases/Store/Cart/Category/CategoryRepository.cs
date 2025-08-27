using CleanArchitecture.Core.Application.UseCases.Store.Cart.Repositories;
using CleanArchitecture.Core.Domain.UseCases.Store.Entities;
using CleanArchitecture.Infra.SqlServer.Common.Repository;
using CleanArchitecture.Infra.SqlServer.Data;

namespace CleanArchitecture.Infra.SqlServer.UseCases.Store.Cart.Category;

public class CategoryRepository : Repository<CategoryEntity, long>, ICategoryRepository
{
    public CategoryRepository(DatabaseContext context) : base(context)
    {
    }
}
