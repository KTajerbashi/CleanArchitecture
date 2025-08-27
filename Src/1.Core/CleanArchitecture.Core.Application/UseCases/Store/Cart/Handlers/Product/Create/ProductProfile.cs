using CleanArchitecture.Core.Domain.UseCases.Store.Entities;

namespace CleanArchitecture.Core.Application.UseCases.Store.Cart.Handlers.Product.Create;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductCreateRequest>().ReverseMap();
    }
}