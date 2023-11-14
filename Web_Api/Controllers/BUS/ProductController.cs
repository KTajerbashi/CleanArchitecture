using Application.Library.BaseModel.BaseDTO;
using Application.Library.Patterns.UnitOfWork;
using Application.Library.Repositories.BUS.ProductRepositories.Models.Views;
using Infrastructure.Library.Patterns.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers.BUS
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitOfWorkFactory _factory;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //[HttpGet(Name = "GetProducts")]
        [HttpGet(Name = "GetProducts"), Authorize]
        public async Task<Result<List<ProductView>>> GetProduct()
        {
            await Task.Delay(0);

            using (var unitOfWork = _factory.BeginTransAction())
            {
                unitOfWork.Commit();
            }

            var result = _unitOfWork.ProductFacad.GetAllProductRepository.Execute();
            return new Result<List<ProductView>>
            {
                //#TODO
                //Data = result.Data,
                Data = null,
                Message = "",
                Status = true
            };
        }
    }
}
