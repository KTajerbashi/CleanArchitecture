using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUser.GetAll;


public class UserGetAllResponse : BaseDTO
{

}

public class UserGetAllRequest : RequestModel<List<UserGetAllResponse>>
{
    public string Email { get; set; }
    // Add other request properties here
}

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
            // Add your business logic here
            // Example:
            // var user = new User { Email = request.Email };
            // await _repository.CreateAsync(user);
            return new List<UserGetAllResponse>();
        }
        catch (Exception ex)
        {
            // Log error if needed
            return new List<UserGetAllResponse>();
            //return new UserGetAllResponse(Result.Failure(ex.Message));
        }
    }
}

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserGetAllRequest, UserGetAllRequest>().ReverseMap();
        // Add other mappings as needed
    }
}

public class UserGetAllValidator : AbstractValidator<UserGetAllRequest>
{
    public UserGetAllValidator()
    {
        RuleFor(item => item.Email).EmailAddress().WithMessage("Email Is Not Correct Format ...");
        // Add other validation rules as needed
    }
}