using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUserLogin.GetByCurrentUser;


public record UserLoginGetResponse(string Message);

public class UserLoginGetRequest : RequestModel<List<UserLoginGetResponse>>
{

}

public class UserLoginGetHandler : Handler<UserLoginGetRequest, List<UserLoginGetResponse>>
{
    private readonly IUserLoginRepository _repository;
    public UserLoginGetHandler(ProviderServices providerServices, IUserLoginRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<List<UserLoginGetResponse>> Handle(UserLoginGetRequest request, CancellationToken cancellationToken)
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
        CreateMap<UserLoginGetRequest, UserLoginGetRequest>().ReverseMap();
        // Add other mappings as needed
    }
}

// Validator for UserLoginGetRequest
public class UserLoginGetRequestValidator : AbstractValidator<UserLoginGetRequest>
{
    public UserLoginGetRequestValidator()
    {
    }
}