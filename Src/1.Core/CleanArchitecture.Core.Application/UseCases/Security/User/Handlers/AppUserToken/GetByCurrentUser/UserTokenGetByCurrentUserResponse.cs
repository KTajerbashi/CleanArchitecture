using CleanArchitecture.Core.Application.Common.Handlers;
using CleanArchitecture.Core.Application.Common.Models.Requests;
using CleanArchitecture.Core.Application.Providers;
using CleanArchitecture.Core.Application.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUserToken.GetByCurrentUser;

public record UserTokenGetByCurrentUserResponse(string Message);

public class UserTokenGetByCurrentUserRequest : RequestModel<UserTokenGetByCurrentUserResponse>
{

}

public class UserTokenGetByCurrentUserHandler : Handler<UserTokenGetByCurrentUserRequest, UserTokenGetByCurrentUserResponse>
{
    private readonly IUserTokenRepository _repository;
    public UserTokenGetByCurrentUserHandler(ProviderServices providerServices, IUserTokenRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<UserTokenGetByCurrentUserResponse> Handle(UserTokenGetByCurrentUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Add your business logic here
            // Example:
            // var user = new User { Email = request.Email };
            // await _repository.CreateAsync(user);

            return new UserTokenGetByCurrentUserResponse("Success");
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
        CreateMap<UserTokenGetByCurrentUserRequest, UserTokenGetByCurrentUserRequest>().ReverseMap();
        // Add other mappings as needed
    }
}

// Validator for UserTokenGetByCurrentUserRequest
public class UserTokenGetByCurrentUserRequestValidator : AbstractValidator<UserTokenGetByCurrentUserRequest>
{
    public UserTokenGetByCurrentUserRequestValidator()
    {
    }
}
