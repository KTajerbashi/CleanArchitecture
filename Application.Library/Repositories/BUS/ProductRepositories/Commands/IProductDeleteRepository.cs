using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Models.DTOs;

namespace Application.Library.Repositories.BUS.ProductRepositories.Commands
{
    public interface IProductDeleteRepository
    {
        Task<Result<ProductDTO>> Execute(Guid guid);
    }
}
