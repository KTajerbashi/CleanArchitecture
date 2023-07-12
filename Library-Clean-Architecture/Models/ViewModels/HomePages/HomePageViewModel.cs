using Application.Library.Service;

namespace Library_Clean_Architecture.HomePages
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<HomePageImagesDto> PageImages { get; set; }
        public List<ProductForSiteDTO> Camera { get; set; }
        public List<ProductForSiteDTO> Mobile { get; set; }
        public List<ProductForSiteDTO> Laptop { get; set; }
    }
}
