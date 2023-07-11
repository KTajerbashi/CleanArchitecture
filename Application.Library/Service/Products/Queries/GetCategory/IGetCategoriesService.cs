using Application.Library.Interfaces;
using Common.Library;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Service
{
    public interface IGetCategoriesService
    {
        ResultDTO<List<CategoryDTO>> Execute(RequestDTO request);
    }
    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly IDatabaseContext _context;
        public GetCategoriesService
            (
            IDatabaseContext context
            )
        {
            _context = context;
        }

        public ResultDTO<List<CategoryDTO>> Execute(RequestDTO request)
        {
            var categories = _context.Categories
                .Include( x => x.ParentCategory )
                .Include( x => x.SubCategories )
                .Where(p => p.ParentCategoryId == request.ParentId)
                .ToList()
                .Select(p => new CategoryDTO
                {
                    ID = p.ID,
                    Name = p.Name,
                    Parent= p.ParentCategoryId != null ?
                    new ParentCategoryDTO
                    {
                        ID= p.ParentCategory.ID,
                        Name = p.ParentCategory.Name,
                    }
                    :null,
                    HasChild = p.SubCategories.Count() > 0 ? true: false,
                }).ToList();

            return new ResultDTO<List<CategoryDTO>>()
            {
                Data = categories,
                IsSuccess = true,
                Message = "لیست با موفقیت واکشی شد",

            };
        }
    }
    public class CategoryDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDTO Parent { get; set; }
    }

    public class ParentCategoryDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }
}
