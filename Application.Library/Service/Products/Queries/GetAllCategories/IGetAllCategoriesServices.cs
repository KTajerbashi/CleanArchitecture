using Application.Library.Interfaces;
using Common.Library;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Service
{
    public interface IGetAllCategoriesService
    {
        ResultDTO<List<AllCategoriesDto>> Execute();
    }


    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IDatabaseContext _context;

        public GetAllCategoriesService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDTO<List<AllCategoriesDto>> Execute()
        {
            var categories = _context
                .Categories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryId != null)
                .ToList()
                .Select(p => new AllCategoriesDto
                {
                    Id = p.ID,
                    Name = $"{p.ParentCategory.Name} - {p.Name}",
                }
            ).ToList();

            return new ResultDTO<List<AllCategoriesDto>>
            {
                Data = categories,
                IsSuccess = false,
                Message = "",
            };
        }
    }

    public class AllCategoriesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
