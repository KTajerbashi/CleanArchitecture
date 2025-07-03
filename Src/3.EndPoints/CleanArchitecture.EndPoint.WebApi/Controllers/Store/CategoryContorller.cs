using CleanArchitecture.Core.Application.Library.UseCases.Store.Cart.Handlers.Category.Create;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Store;

public class CategoryContorller : AuthorizationController
{
    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateRequest request)
    {
        return await RequestAsync<CategoryCreateRequest, CategoryCreateResponse>(request);
    }
}
