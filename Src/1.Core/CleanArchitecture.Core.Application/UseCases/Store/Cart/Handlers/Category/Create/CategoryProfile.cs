using CleanArchitecture.Core.Domain.UseCases.Store.Entities;

namespace CleanArchitecture.Core.Application.UseCases.Store.Cart.Handlers.Category.Create;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryEntity, CategoryCreateRequest>().ReverseMap();
    }
}