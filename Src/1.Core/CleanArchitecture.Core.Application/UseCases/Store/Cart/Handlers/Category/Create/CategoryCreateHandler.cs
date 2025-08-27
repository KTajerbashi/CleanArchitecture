using CleanArchitecture.Core.Application.Common.Handlers;
using CleanArchitecture.Core.Application.Providers;
using CleanArchitecture.Core.Application.UseCases.Store.Cart.Repositories;
using CleanArchitecture.Core.Domain.UseCases.Store.Entities;

namespace CleanArchitecture.Core.Application.UseCases.Store.Cart.Handlers.Category.Create;

public class CategoryCreateHandler : Handler<CategoryCreateRequest, CategoryCreateResponse>
{
    private readonly ICategoryRepository _repository;
    public CategoryCreateHandler(ProviderServices providerServices, ICategoryRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<CategoryCreateResponse> Handle(CategoryCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            CategoryEntity entity = CategoryEntity.CreateInstance(request.Title);
            entity = await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangeAsync(cancellationToken);
            return new(entity.EntityId.Value);
        }
        catch (Exception ex)
        {
            throw new AppException(ex.Message);
        }
    }
}
