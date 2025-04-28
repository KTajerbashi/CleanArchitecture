using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUser.Delete;



public class UserDeleteResponse : BaseDTO
{

}

public class UserDeleteRequest : RequestModel<UserDeleteResponse>
{
    public Guid EntityId { get; set; }

    public UserDeleteRequest(Guid entityId)
    {
        EntityId = entityId;
    }
}

public class UserDeleteHandler : Handler<UserDeleteRequest, UserDeleteResponse>
{
    private readonly IUserRepository _repository;
    public UserDeleteHandler(ProviderServices providerServices, IUserRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<UserDeleteResponse> Handle(UserDeleteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Add your business logic here
            // Example:
            // var user = new User { Email = request.Email };
            // await _repository.CreateAsync(user);

            return new UserDeleteResponse();
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
        CreateMap<UserDeleteRequest, UserDeleteRequest>().ReverseMap();
        // Add other mappings as needed
    }
}

public class UserDeleteValidator : AbstractValidator<UserDeleteRequest>
{
    public UserDeleteValidator()
    {
        //RuleFor(item => item.Email).EmailAddress().WithMessage("Email Is Not Correct Format ...");
        // Add other validation rules as needed
    }
}