using CleanArchitecture.Core.Application.Common.Models.Requests;

namespace CleanArchitecture.Core.Application.UseCases.Store.Cart.Handlers.Category.Create;
public class CategoryCreateRequest : RequestModel<CategoryCreateResponse>
{
    public string Title { get; set; }
}
