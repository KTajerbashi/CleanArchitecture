using CleanArchitecture.Core.Application.Library.UseCases.Store.Card.Repositories;
using CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

namespace CleanArchitecture.Core.Application.Library.UseCases.Store.Card.Handlers.Product.Create;

public class ProductCreateHandler : Handler<ProductCreateRequest, ProductCreateResponse>
{
    private readonly IProductRepository _repository;
    private readonly ICategoryRepository _categoryRepository;
    public ProductCreateHandler(ProviderServices providerServices, IProductRepository repository, ICategoryRepository categoryRepository) : base(providerServices)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
    }

    public override async Task<ProductCreateResponse> Handle(ProductCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.BeginTransactionAsync();
            ProductEntity entity = ProductEntity.CreateInstance(request.Title,request.Description);
            foreach (var item in request.ProductDetails)
            {
                ProductDetailEntity detailEntity = ProductDetailEntity.CreateInstance(item.Title,item.Value);
                entity.AddDetail(detailEntity);
            }
            CategoryEntity categoryEntity = await _categoryRepository.GetAsync(request.CategoryId,cancellationToken);
            categoryEntity.AddProduct(entity);
            entity = await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangeAsync(cancellationToken);
            await _repository.CommitTransactionAsync();
            return new(entity.EntityId.Value);
        }
        catch (Exception ex)
        {
            await _repository.RollbackTransactionAsync();
            throw new AppException(ex.Message);
        }
    }
}
