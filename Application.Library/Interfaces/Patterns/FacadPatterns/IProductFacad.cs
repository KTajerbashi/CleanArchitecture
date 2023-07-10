using Application.Library.Service;

namespace Application.Library.Interfaces.Patterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
    }
}
