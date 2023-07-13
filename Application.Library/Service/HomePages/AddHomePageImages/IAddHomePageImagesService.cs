using Application.Library.Interfaces;
using Common.Library;
using Common.Library.Configuration;
using Domain.Library.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Library.Service
{
    public interface IAddHomePageImagesService
    {
        ResultDTO Execute(requestAddHomePageImagesDto request);
    }


    public class AddHomePageImagesService : IAddHomePageImagesService
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;

        public AddHomePageImagesService(IDatabaseContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _environment = hosting;
        }
        public ResultDTO Execute(requestAddHomePageImagesDto request)
        {
            if (string.IsNullOrEmpty(request.Link))
            {
                request.Link = "+";
            }
            var resultUpload = UploadFile(request.file);
            HomePageImages homePageImages = new HomePageImages()
            {
                link = request.Link,
                Src = resultUpload.FileNameAddress,
                ImageLocation = request.ImageLocation,
            };
            _context.HomePageImages.Add(homePageImages);
            _context.SaveChanges();
            return new ResultDTO()
            {
                IsSuccess = true,
            };
        }




        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\Slider\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }

    public class requestAddHomePageImagesDto
    {
        public IFormFile file { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
