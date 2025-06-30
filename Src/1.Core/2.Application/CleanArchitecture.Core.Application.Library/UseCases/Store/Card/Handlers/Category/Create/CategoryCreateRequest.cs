namespace CleanArchitecture.Core.Application.Library.UseCases.Store.Card.Handlers.Category.Create;
public class CategoryCreateRequest : RequestModel<CategoryCreateResponse>
{
    public string Title { get; set; }
}
