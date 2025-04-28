using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUser.GetById;



public class UserGetByIdResponse : BaseDTO
{
}

public class UserGetByIdRequest : RequestModel<UserGetByIdResponse>
{
    public UserGetByIdRequest(Guid entityId)
    {
        EntityId = entityId;
    }

    public string Email { get; set; }
    public Guid EntityId { get; set; }
    // Add other request properties here
}

public class UserGetByIdHandler : Handler<UserGetByIdRequest, UserGetByIdResponse>
{
    private readonly IUserRepository _repository;
    public UserGetByIdHandler(ProviderServices providerServices, IUserRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<UserGetByIdResponse> Handle(UserGetByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Add your business logic here
            // Example:
            // var user = new User { Email = request.Email };
            // await _repository.CreateAsync(user);

            return new UserGetByIdResponse();
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
        CreateMap<UserGetByIdRequest, UserGetByIdRequest>().ReverseMap();
        // Add other mappings as needed
    }
}

public class UserGetByIdValidator : AbstractValidator<UserGetByIdRequest>
{
    public UserGetByIdValidator()
    {
        RuleFor(item => item.Email).EmailAddress().WithMessage("Email Is Not Correct Format ...");
        // Add other validation rules as needed
    }
}

