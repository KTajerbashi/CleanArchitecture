using CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

namespace CleanArchitecture.Core.Application.Library.UseCases.Store.Card.Handlers.Product.Create;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductCreateRequest>().ReverseMap();
    }
}