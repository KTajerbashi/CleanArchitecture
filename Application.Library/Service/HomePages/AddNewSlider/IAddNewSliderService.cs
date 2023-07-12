using Application.Library.Interfaces;
using Common.Library;
using Common.Library.Configuration;
using Domain.Library.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Library.Service
{
    public interface IAddNewSliderService
    {
        ResultDTO Execute(IFormFile file, string Link);
    }

    public class AddNewSliderService : IAddNewSliderService
    {

        private readonly IHostingEnvironment _environment;
        private readonly IDatabaseContext _context;

        public AddNewSliderService(IHostingEnvironment environment, IDatabaseContext context)
        {
            _environment = environment;
            _context = context;
        }
        public ResultDTO Execute(IFormFile file, string Link)
        {
            var resultUpload = UploadFile(file);


            Slider slider = new Slider()
            {
                link = Link,
                Src = resultUpload.FileNameAddress,
            };
            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return new ResultDTO()
            {
                IsSuccess = true
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



}
