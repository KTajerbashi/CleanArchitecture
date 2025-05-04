using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;
using CleanArchitecture.Core.Domain.Library.UseCases.Security;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUser.GetAll;


public class UserGetAllResponse : BaseDTO
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string Username { get; set; }
    public string DisplayName { get; set; }
    public string Email { get; set; }
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
            var data = await _repository.GetAsync(cancellationToken);
            var result = ProviderServices.Mapper.Map<AppUserEntity,UserGetAllResponse>(data);
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

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<AppUserEntity, UserGetAllResponse>().ReverseMap();
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