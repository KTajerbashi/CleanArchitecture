using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUserRole.GetAll;



public record UserRoleGetResponse(string Message);

public class UserRoleGetRequest : RequestModel<List<UserRoleGetResponse>>
{

}

public class UserRoleGetHandler : Handler<UserRoleGetRequest, List<UserRoleGetResponse>>
{
    private readonly IUserRoleRepository _repository;
    public UserRoleGetHandler(ProviderServices providerServices, IUserRoleRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<List<UserRoleGetResponse>> Handle(UserRoleGetRequest request, CancellationToken cancellationToken)
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
        CreateMap<UserRoleGetRequest, UserRoleGetRequest>().ReverseMap();
        // Add other mappings as needed
    }
}

// Validator for UserRoleGetRequest
public class UserRoleGetRequestValidator : AbstractValidator<UserRoleGetRequest>
{
    public UserRoleGetRequestValidator()
    {
    }
}