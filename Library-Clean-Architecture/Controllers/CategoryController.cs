using Application.Library.Interfaces.Patterns;
using Application.Library.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library_Clean_Architecture.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductFacad _productFacad;
        public CategoryController(
            IProductFacad productFacad
            )
        {
            _productFacad = productFacad;
        }
        public ActionResult Index(long? parentId)
        {
            return View(_productFacad.GetCategoriesService.Execute(new RequestDTO
            {
                ParentId = parentId,
            }).Data);
        }
        [HttpGet]
        public ActionResult AddNewCategory(long? parentId)
        {
            ViewBag.ParentId = parentId;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewCategory(RequestDTO request)
        {
            var result = _productFacad.AddNewCategoryService.Execute(request);
            //return Json(result);
            return RedirectToAction("Index","Home");
        }
    }
}
