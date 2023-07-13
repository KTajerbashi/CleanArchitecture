using Application.Library.Interfaces.Patterns;
using Application.Library.Service;
using Domain.Library.Entities;
using Library_Clean_Architecture.HomePages;
using Library_Clean_Architecture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library_Clean_Architecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderService _getSliderService;
        private readonly IGetHomePageImagesService _homePageImagesService;
        private readonly IProductFacad _productFacad;

        public HomeController(ILogger<HomeController> logger
            , IGetSliderService getSliderService
            , IGetHomePageImagesService homePageImagesService
            , IProductFacad productFacad)
        {
            _logger = logger;
            _getSliderService = getSliderService;
            _homePageImagesService = homePageImagesService;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {

            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _getSliderService.Execute().Data,
                PageImages = _homePageImagesService.Execute().Data,
                Camera=_productFacad.GetProductForSiteService.Execute( Ordering.theNewest
                ,null,1,6,25).Data.Products,
            };
            var item = homePage;
            var list = homePage.PageImages.Where(p=> p.ImageLocation == ImageLocation.L1)?.FirstOrDefault()?.Src?? null;
            return View(item);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
