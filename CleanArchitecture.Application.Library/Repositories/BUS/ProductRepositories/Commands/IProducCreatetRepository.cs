using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.BUS.ProductRepositories.Models.DTOs;

namespace CleanArchitecture.Application.Library.Repositories.BUS.ProductRepositories.Commands
{
    public interface IProducCreatetRepository
    {
        Task<Result<ProductDTO>> Execute(ProductDTO product);
    }
}
