using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;

namespace Application.Library.Service
{
    public interface IGetHomePageImagesService
    {
        ResultDTO<List<HomePageImagesDto>> Execute();
    }

    public class GetHomePageImagesService : IGetHomePageImagesService
    {
        private readonly IDatabaseContext _context;
        public GetHomePageImagesService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<HomePageImagesDto>> Execute()
        {
            var images = _context.HomePageImages.OrderByDescending(p => p.ID)
                .Select(p => new HomePageImagesDto
                {
                    Id = p.ID,
                    ImageLocation = p.ImageLocation,
                    Link = p.link,
                    Src = p.Src,
                }).ToList();
            return new ResultDTO<List<HomePageImagesDto>>()
            {
                Data = images,
                IsSuccess = true,
            };
        }
    }
    public class HomePageImagesDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
