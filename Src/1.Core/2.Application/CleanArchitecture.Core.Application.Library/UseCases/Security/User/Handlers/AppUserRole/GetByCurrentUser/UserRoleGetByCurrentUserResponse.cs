using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUserRole.GetByCurrentUser;

public record UserRoleGetByCurrentUserResponse(string Message);

public class UserRoleGetByCurrentUserRequest : RequestModel<UserRoleGetByCurrentUserResponse>
{

}

public class UserRoleGetByCurrentUserHandler : Handler<UserRoleGetByCurrentUserRequest, UserRoleGetByCurrentUserResponse>
{
    private readonly IUserRoleRepository _repository;
    public UserRoleGetByCurrentUserHandler(ProviderServices providerServices, IUserRoleRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<UserRoleGetByCurrentUserResponse> Handle(UserRoleGetByCurrentUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Add your business logic here
            // Example:
            // var user = new User { Email = request.Email };
            // await _repository.CreateAsync(user);

            return new UserRoleGetByCurrentUserResponse("Success");
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
        CreateMap<UserRoleGetByCurrentUserRequest, UserRoleGetByCurrentUserRequest>().ReverseMap();
        // Add other mappings as needed
    }
}

// Validator for UserRoleGetByCurrentUserRequest
public class UserRoleGetByCurrentUserRequestValidator : AbstractValidator<UserRoleGetByCurrentUserRequest>
{
    public UserRoleGetByCurrentUserRequestValidator()
    {
    }
}