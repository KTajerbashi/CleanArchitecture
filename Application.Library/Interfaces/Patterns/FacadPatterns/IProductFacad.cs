using Application.Library.Service;
using Application.Library.Service.Products.Commands.AddNewProduct;

namespace Application.Library.Interfaces.Patterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }


        AddNewProductService AddNewProductService { get; }



        /// <summary>
        /// دریافت لیست محصولات
        /// </summary>
        IGetCategoriesService GetCategoriesService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }

    }
}
