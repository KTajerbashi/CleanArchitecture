using CleanArchitecture.Core.Application.UseCases.Security.User.Repositories;
using CleanArchitecture.Core.Domain.UseCases.Security;

namespace CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUser.GetAll;

public class UserGetAllHandler : Handler<UserGetAllRequest, List<UserGetAllResponse>>
{
    private readonly IUserRepository _repository;
    public UserGetAllHandler(ProviderServices providerServices, IUserRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<List<UserGetAllResponse>> Handle(UserGetAllRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var data = await _repository.GetAsync(cancellationToken);
            var result = ProviderServices.Mapper.Map<AppUserEntity, UserGetAllResponse>(data);
            return result.ToList();
        }
        catch (Exception ex)
        {
            // Log error if needed
            return new List<UserGetAllResponse>();
            //return new UserGetAllResponse(Result.Failure(ex.Message));
        }
    }
}
