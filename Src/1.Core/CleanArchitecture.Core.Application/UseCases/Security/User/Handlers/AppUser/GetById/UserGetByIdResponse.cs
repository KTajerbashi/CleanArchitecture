using CleanArchitecture.Core.Application.Common.Handlers;
using CleanArchitecture.Core.Application.Common.Models.DTOs;
using CleanArchitecture.Core.Application.Common.Models.Requests;
using CleanArchitecture.Core.Application.Providers;
using CleanArchitecture.Core.Application.UseCases.Security.User.Repositories;
using CleanArchitecture.Core.Domain.UseCases.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUser.GetById;



public class UserGetByIdResponse : BaseDTO
{
    public string Email { get; set; }
    public string DisplayName { get; set; }
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

            var entity = await _repository.GetAsync(request.EntityId,cancellationToken);

            return ProviderServices.Mapper.Map<AppUserEntity,UserGetByIdResponse>(entity);
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
        // Add other mappings as needed
        CreateMap<AppUserEntity, UserGetByIdResponse>().ReverseMap();
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

