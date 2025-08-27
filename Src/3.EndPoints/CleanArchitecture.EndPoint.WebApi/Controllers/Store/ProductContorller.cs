using CleanArchitecture.Core.Application.UseCases.Store.Cart.Handlers.Product.Create;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Store;

public class ProductContorller : AuthorizationController
{
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateRequest request)
    {
        return await RequestAsync<ProductCreateRequest, ProductCreateResponse>(request);
    }
}
