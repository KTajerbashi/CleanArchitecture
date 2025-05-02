using CleanArchitecture.Core.Application.Library.Interfaces;
using CleanArchitecture.Core.Application.Library.UseCases.Security.Role.Repositories;
using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;
using CleanArchitecture.Core.Domain.Library.UseCases.Security;
using CleanArchitecture.Core.Domain.Library.UseCases.Security.Parameters;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUser.Create;


public record UserCreateResponse(string Message);

public class UserCreateRequest : RequestModel<UserCreateResponse>
{
    public string Name { get; set; }
    public string RoleName { get; set; }
    public string Family { get; set; }
    public string PersonalCode { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}

public class UserCreateHandler : Handler<UserCreateRequest, UserCreateResponse>
{
    private readonly IUserRepository _repository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IIdentityFactory _identityFactory;
    public UserCreateHandler(
        ProviderServices providerServices,
        IUserRepository repository,
        IRoleRepository roleRepository,
        IUserRoleRepository userRoleRepository,
        IIdentityFactory identityFactory) : base(providerServices)
    {
        _repository = repository;
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
        _identityFactory = identityFactory;
    }

    public override async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.BeginTransactionAsync();
            //  Create User
            AppUserCreateParameters parameters = ProviderServices.Mapper.Map<UserCreateRequest,AppUserCreateParameters>(request);
            AppUserEntity userEntity = new AppUserEntity(parameters);
            string passwordHash = _identityFactory.PasswordHash(userEntity,request.Password);
            string concurrencyStamp = _identityFactory.ConcurrencyStamp(request.Password);
            string securityStamp = _identityFactory.SecurityStamp(request.Password);
            userEntity.SetPassword(securityStamp, passwordHash, concurrencyStamp);
            userEntity = await _repository.AddAsync(userEntity, cancellationToken);
            await _repository.SaveChangeAsync();
            //  Find Role
            AppRoleEntity roleEntity = await _roleRepository.FindByNameAsync(request.RoleName,cancellationToken);
            //  Is Exist Create User Role
            if (roleEntity != null)
            {
                AppUserRoleEntity appUserRoleEntity = new(userEntity.Id,roleEntity.Id);
                userEntity.AddUserRole(appUserRoleEntity);
                await _repository.SaveChangeAsync();
            }
            //  Is Not Exist Add Role
            else
            {
                AppRoleEntity appRoleEntity = new(request.RoleName.ToUpper(),request.RoleName);
                appRoleEntity = await _roleRepository.AddAsync(appRoleEntity, cancellationToken);
                await _roleRepository.SaveChangeAsync();
                //  Then Create User Role
                AppUserRoleEntity appUserRoleEntity = new(userEntity.Id,appRoleEntity.Id);
                userEntity.AddUserRole(appUserRoleEntity);
                await _repository.SaveChangeAsync();
            }

            await _repository.CommitTransactionAsync();
            return new UserCreateResponse("Success");
        }
        catch (Exception ex)
        {
            await _repository.RollbackTransactionAsync();
            // Log error if needed
            throw new ApplicationException(ex.Message, ex);
        }
    }
}

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateRequest, AppUserCreateParameters>().ReverseMap();
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

        //RuleFor(x => x.Age)
        //    .GreaterThanOrEqualTo(18).WithMessage("User must be at least 18 years old");
    }
}
