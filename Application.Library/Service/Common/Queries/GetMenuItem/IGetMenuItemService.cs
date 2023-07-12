using Application.Library.Interfaces;
using Common.Library;
using Microsoft.EntityFrameworkCore;

namespace Application.Library.Service
{
    public interface IGetMenuItemService
    {
        ResultDTO<List<MenuItemDto>> Execute();
    }

    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDatabaseContext _context;
        public GetMenuItemService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDTO<List<MenuItemDto>> Execute()
        {
            var category = _context.Categories
                .Include(p => p.SubCategories)
                .Where(p=> p.ParentCategoryId == null)
                .ToList()
                .Select(p => new MenuItemDto
                {
                    CatId = p.ID,
                    Name = p.Name,
                    Child = p.SubCategories.ToList().Select(child => new MenuItemDto
                    {
                        CatId = child.ID,
                        Name = child.Name,
                    }).ToList(),
                }).ToList();

            return new ResultDTO<List<MenuItemDto>>()
            {
                Data = category,
                IsSuccess = true,
            };
        }
    }

    public class MenuItemDto
    {
        public long CatId { get; set; }
        public string Name { get; set; }
        public List<MenuItemDto> Child { get; set; }
    }
}
