using Application.Library.Interfaces;
using Common.Library;
using Common.Library.Configuration;
using Domain.Library.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Service.Products.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {
        ResultDTO Execute(RequestAddNewProductDTO request);
    }


    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewProductService(
            IDatabaseContext context,
            IHostingEnvironment hostingEnvironment
            )
        {
            _context = context;
            _environment = hostingEnvironment;
        }
        public ResultDTO Execute(RequestAddNewProductDTO request)
        {
            FileHandler FileHandler = new FileHandler(_environment);
            try
            {
                var category = _context.Categories.Find(request.CategoryId);
                Product product = new Product()
                {
                    Brand = request.Brand,
                    Description = request.Description,
                    Name = request.Name,
                    Price = request.Price,
                    Inventory = request.Inventory,
                    Category = category,
                    Displayed = request.Displayed,
                };
                _context.Products.Add(product);

                List<ProductImages> productImages= new List<ProductImages>();
                foreach (var item in request.Images)
                {
                    var uploadResult = FileHandler.UploadFile(item);
                    productImages.Add(new ProductImages
                    {
                        Product = product,
                        Src = uploadResult.FileNameAddress,
                    });
                }
                _context.ProductImages.AddRange(productImages);

                List<ProductFeatures> productFeatures = new List<ProductFeatures>();
                foreach (var item in request.Features)
                {
                    productFeatures.Add(new ProductFeatures
                    {
                        DisplayName = item.DisplayName,
                        Value = item.Value,
                        Product = product,
                    });
                }
                _context.ProductFeatures.AddRange(productFeatures);

                _context.SaveChanges();

                return new ResultDTO
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد",
                };
            }
            catch
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد ",
                };
            }

        }
    }

    public class RequestAddNewProductDTO
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; } // موجودی در انبار
        public long CategoryId { get; set; }
        public bool Displayed { get; set; }

        public List<IFormFile> Images { get; set; }
        public List<AddNewProduct_Features> Features { get; set; }
    }

    public class AddNewProduct_Features
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }

}
