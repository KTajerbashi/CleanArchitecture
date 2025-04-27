using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.Create;


public record UserCreateResponse(string Message);

public class UserCreateRequest : RequestModel<UserCreateResponse>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}

public class UserCreateHandler : Handler<UserCreateRequest, UserCreateResponse>
{
    private readonly IUserRepository _repository;
    public UserCreateHandler(ProviderServices providerServices, IUserRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Add your business logic here
            // Example:
            // var user = new User { Email = request.Email };
            // await _repository.CreateAsync(user);

            return new UserCreateResponse("Success");
        }
        catch (Exception ex)
        {
            // Log error if needed
            throw new ApplicationException("",ex);
        }
    }
}

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateRequest, UserCreateRequest>().ReverseMap();
        // Add other mappings as needed
    }
}

// Validator for UserCreateRequest
public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
{
    public UserCreateRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");

        RuleFor(x => x.Age)
            .GreaterThanOrEqualTo(18).WithMessage("User must be at least 18 years old");
    }
}
