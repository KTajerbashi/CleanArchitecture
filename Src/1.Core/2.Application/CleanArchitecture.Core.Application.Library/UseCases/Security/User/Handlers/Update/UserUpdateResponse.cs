
using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.Update;


public class UserUpdateResponse : BaseDTO
{
}

public class UserUpdateRequest : RequestModel<UserUpdateResponse>
{
    public string Email { get; set; }
    // Add other request properties here
}

public class UserUpdateHandler : Handler<UserUpdateRequest, UserUpdateResponse>
{
    private readonly IUserRepository _repository;
    public UserUpdateHandler(ProviderServices providerServices, IUserRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<UserUpdateResponse> Handle(UserUpdateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Add your business logic here
            // Example:
            // var user = new User { Email = request.Email };
            // await _repository.CreateAsync(user);

            return new UserUpdateResponse();
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
        CreateMap<UserUpdateRequest, UserUpdateRequest>().ReverseMap();
        // Add other mappings as needed
    }
}

public class UserUpdateValidator : AbstractValidator<UserUpdateRequest>
{
    public UserUpdateValidator()
    {
        RuleFor(item => item.Email).EmailAddress().WithMessage("Email Is Not Correct Format ...");
        // Add other validation rules as needed
    }
}