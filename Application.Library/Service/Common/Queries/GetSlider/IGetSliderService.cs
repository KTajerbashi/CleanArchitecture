using Application.Library.Interfaces;
using Common.Library;

namespace Application.Library.Service
{
    public interface IGetSliderService
    {
        ResultDTO<List<SliderDto>> Execute();
    }

    public class GetSliderService : IGetSliderService
    {
        private readonly IDatabaseContext _context;
        public GetSliderService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<SliderDto>> Execute()
        {
            var sliders = _context.Sliders.OrderByDescending(p => p.ID).ToList().Select(
                p => new SliderDto
                {
                    Link=p.link,
                    Src=p.Src,
                }).ToList();

            return new ResultDTO<List<SliderDto>>()
            {
                Data = sliders,
                IsSuccess = true,
            };
        }
    }

    public class SliderDto
    {
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
