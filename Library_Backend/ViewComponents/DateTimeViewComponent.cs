using Common.Library.Utilities;

namespace EndPoint_WebApi.ViewComponents
{
    public class DateTimeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string perfixAds)
        {
            var Ads = ConvertDate.GetPersionDate(DateTime.Now);
            return View(Ads);
        }
    }
}
