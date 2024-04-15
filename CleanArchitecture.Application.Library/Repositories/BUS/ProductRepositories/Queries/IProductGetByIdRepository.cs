using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.BUS.ProductRepositories.Models.Views;

namespace CleanArchitecture.Application.Library.Repositories.BUS.ProductRepositories.Queries
{
    public interface IProductGetByIdRepository
    {
        Task<Result<ProductView>> Execute(Guid guid);
    }

}
