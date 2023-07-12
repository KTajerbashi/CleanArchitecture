using Application.Library.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library_Clean_Architecture.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly IGetMenuItemService _getMenuItemService;
        public GetMenu(IGetMenuItemService getMenuItemService)
        {
            _getMenuItemService = getMenuItemService;
        }


        public IViewComponentResult Invoke()
        {
            var menuItem = _getMenuItemService.Execute();
            return View(viewName: "GetMenu", menuItem.Data);
        }

    }
}
