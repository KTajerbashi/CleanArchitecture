namespace CleanArchitecture.Core.Application.Library.UseCases.Store.Cart.Handlers.Product.Create;

public class ProductCreateRequest : RequestModel<ProductCreateResponse>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public List<ProductDetailCreateParameter> ProductDetails { get; set; }
}
