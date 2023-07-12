using Application.Library.Interfaces;
using Common.Library;

namespace Application.Library.Service
{
    public interface IGetCategoryService
    {
        ResultDTO<List<CategoryDto>> Execute();
    }

    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDatabaseContext _context;
        public GetCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<CategoryDto>> Execute()
        {

            var category = _context.Categories.Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new CategoryDto
                {
                    CatId = p.ID,
                    CategoryName = p.Name,
                }).ToList();

            return new ResultDTO<List<CategoryDto>>()
            {
                Data = category,
                IsSuccess = true,
            };
        }
    }

    public class CategoryDto
    {
        public long CatId { get; set; }
        public string CategoryName { get; set; }
    }
}
