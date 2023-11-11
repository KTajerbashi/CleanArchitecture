using Application.Library.BaseModel.BaseDTO;
using Application.Library.Patterns.UnitOfWork;
using Application.Library.Repositories.BUS.ProductRepositories.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers.BUS
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet(Name = "GetProducts")]
        public Result<List<ProductView>> GetProduct()
        {
            var result = _unitOfWork.ProductFacad.GetAllProductRepository.Execute();
            return new Result<List<ProductView>>
            {
                Data = result.Data,
                Message = "",
                Status = true
            };
        }
    }
}
