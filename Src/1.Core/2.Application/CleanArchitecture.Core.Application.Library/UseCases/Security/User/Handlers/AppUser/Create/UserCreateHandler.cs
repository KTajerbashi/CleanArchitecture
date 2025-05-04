namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUser.Create;

public class UserCreateHandler : Handler<UserCreateRequest, UserCreateResponse>
{
    public UserCreateHandler(ProviderServices providerServices) : base(providerServices)
    {
    }

    public override Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    //private readonly IUserRepository _repository;
    //private readonly IRoleRepository _roleRepository;
    //private readonly IUserRoleRepository _userRoleRepository;
    //private readonly IIdentityFactory _identityFactory;
    //public UserCreateHandler(
    //    ProviderServices providerServices,
    //    IUserRepository repository,
    //    IRoleRepository roleRepository,
    //    IUserRoleRepository userRoleRepository,
    //    IIdentityFactory identityFactory) : base(providerServices)
    //{
    //    _repository = repository;
    //    _roleRepository = roleRepository;
    //    _userRoleRepository = userRoleRepository;
    //    _identityFactory = identityFactory;
    //}

    //public override async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
    //{
    //    await _repository.BeginTransactionAsync();
    //    try
    //    {
    //        // Check if user already exists
    //        var existingUser = await _repository.GetByEmailAsync(request.Email)
    //                      ?? await _repository.GetByUsernameAsync(request.UserName);

    //        if (existingUser is not null)
    //        {
    //            return new UserCreateResponse("User Exists");

    //            // User already exists - return error response
    //            throw new ApplicationException("User with this email or username already exists");
    //        }

    //        // Create new user
    //        var parameters = ProviderServices.Mapper.Map<UserCreateRequest, AppUserCreateParameters>(request);
    //        var userEntity = new AppUserEntity(parameters);

    //        // Set security properties
    //        //string passwordHash = _identityFactory.PasswordHash(userEntity, request.Password);
    //        //string concurrencyStamp = _identityFactory.ConcurrencyStamp(request.Password);
    //        //string securityStamp = _identityFactory.SecurityStamp(request.Password);

    //        //userEntity.SetPassword(securityStamp, passwordHash, concurrencyStamp);
    //        _repository.SetPassword(request.Password);

    //        // Add user to database
    //        userEntity = await _repository.AddAsync(userEntity, cancellationToken);

    //        // Handle role assignment
    //        var roleEntity = await _roleRepository.FindByNameAsync(request.RoleName, cancellationToken);

    //        if (roleEntity is null)
    //        {
    //            // Create new role if it doesn't exist
    //            roleEntity = new AppRoleEntity(request.RoleName.ToUpper(), request.RoleName);
    //            roleEntity = await _roleRepository.AddAsync(roleEntity, cancellationToken);
    //            //await _roleRepository.SaveChangeAsync();
    //        }

    //        //// Create user-role relationship
    //        var appUserRoleEntity = new AppUserRoleEntity(userEntity.Id, roleEntity.Id);
    //        await _userRoleRepository.AddAsync(appUserRoleEntity, cancellationToken);

    //        // Save all changes
    //        await _repository.SaveChangeAsync(cancellationToken);
    //        await _repository.CommitTransactionAsync();

    //        return new UserCreateResponse("User created successfully");
    //    }
    //    catch (Exception ex)
    //    {
    //        await _repository.RollbackTransactionAsync();
    //        // Log error if needed
    //        throw new ApplicationException("Failed to create user", ex);
    //    }
    //}
}
