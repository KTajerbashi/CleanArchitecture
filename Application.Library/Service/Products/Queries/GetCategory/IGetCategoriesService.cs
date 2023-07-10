using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Id = p.ID,
                    Name = p.Name,
                    Parent= p.ParentCategoryId != null ?
                    new ParentCategoryDTO
                    {
                        Id= p.ParentCategory.ID,
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
        public long Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDTO Parent { get; set; }
    }

    public class ParentCategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
