using Application.Library.Interfaces;
using Application.Library.Interfaces.Patterns;

namespace Application.Library.Service.Products
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDatabaseContext _context;
        public ProductFacad(IDatabaseContext context) { _context = context; }

        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }
        private IGetCategoriesService _getCategoriesService;
        public IGetCategoriesService GetCategoriesService
        {
            get
            {
                return _getCategoriesService = _getCategoriesService ?? new GetCategoriesService(_context);
            }
        }

    }
}
