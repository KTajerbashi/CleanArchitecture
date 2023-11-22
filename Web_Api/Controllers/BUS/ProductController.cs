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
    [Route("[controller]")]
    public abstract class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitOfWorkFactory _factory;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //[HttpGet(Name = "GetProducts"), Authorize]
        [HttpPost]
        public async Task<Result<bool>> Create()
        {
            await Task.Delay(1);
            return new Result<bool> { };

        }
        [HttpDelete]
        public async Task<Result<bool>> Delete()
        {
            await Task.Delay(1);
            return new Result<bool> { };

        }
        [HttpPut]
        public async Task<Result<bool>> Replace()
        {
            await Task.Delay(1);
            return new Result<bool> { };

        }
        [HttpPatch]
        public async Task<Result<bool>> Update()
        {
            await Task.Delay(1);
            return new Result<bool> { };
        }
        [HttpGet]
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
