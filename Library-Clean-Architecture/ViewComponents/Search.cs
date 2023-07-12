using Application.Library.Service;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly IGetCategoryService _getCategoryService;
        public Search(IGetCategoryService getCategoryService)
        {
            _getCategoryService = getCategoryService;
        }


        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search", _getCategoryService.Execute().Data);
        }
    }
}
