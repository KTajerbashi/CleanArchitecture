using CleanArchitecture.Core.Application.Common.Handlers;
using CleanArchitecture.Core.Application.Common.Models.Requests;
using CleanArchitecture.Core.Application.Providers;
using CleanArchitecture.Core.Application.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUserToken.GetAll;

public record UserTokenGetResponse(string Message);

public class UserTokenGetRequest : RequestModel<List<UserTokenGetResponse>>
{

}

public class UserTokenGetHandler : Handler<UserTokenGetRequest, List<UserTokenGetResponse>>
{
    private readonly IUserTokenRepository _repository;
    public UserTokenGetHandler(ProviderServices providerServices, IUserTokenRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<List<UserTokenGetResponse>> Handle(UserTokenGetRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Add your business logic here
            // Example:
            // var user = new User { Email = request.Email };
            // await _repository.CreateAsync(user);

            return new();
        }
        catch (Exception ex)
        {
            // Log error if needed
            throw new ApplicationException("", ex);
        }
    }
}

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserTokenGetRequest, UserTokenGetRequest>().ReverseMap();
        // Add other mappings as needed
    }
}

// Validator for UserTokenGetRequest
public class UserTokenGetRequestValidator : AbstractValidator<UserTokenGetRequest>
{
    public UserTokenGetRequestValidator()
    {
    }
}
