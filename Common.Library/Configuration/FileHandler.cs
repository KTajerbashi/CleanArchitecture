using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Common.Library.Configuration
{
    public class FileHandler
    {
        private readonly IHostingEnvironment _environment;

        public FileHandler(IHostingEnvironment hostingEnvironment)
        {
            _environment = hostingEnvironment;
        }
        public UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";

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
    public class UploadDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }

}
