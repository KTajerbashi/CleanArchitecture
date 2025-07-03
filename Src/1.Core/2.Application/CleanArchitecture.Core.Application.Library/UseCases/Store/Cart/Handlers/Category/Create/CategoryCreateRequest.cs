namespace CleanArchitecture.Core.Application.Library.UseCases.Store.Cart.Handlers.Category.Create;
public class CategoryCreateRequest : RequestModel<CategoryCreateResponse>
{
    public string Title { get; set; }
}
