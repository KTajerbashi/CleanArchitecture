using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;

namespace Application.Library.Service
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDatabaseContext _context;
        public AddNewCategoryService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDTO Execute(RequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return new ResultDTO()
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد کنید "
                };
            }

            Category category= new Category()
            {
                Name = request.Name,
                ParentCategory= GetParent(request.ParentId)
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            
            return new ResultDTO()
            {
                IsSuccess = true,
                Message = "دسته یندی با موفقیت اضافه شد"
            };

        }
        public Category GetParent(long? parentId)
        {
            return _context.Categories.Find(parentId);

        }
    }
}
