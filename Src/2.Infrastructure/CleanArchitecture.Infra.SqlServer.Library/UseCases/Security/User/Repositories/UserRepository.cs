using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Security.User.Repositories;

public class UserRepository : Repository<AppUserEntity, long>, IUserRepository
{
    private readonly UserManager<UserEntity> _userManager;
    public string Password { get; private set; }

    public UserRepository(DatabaseContext context, UserManager<UserEntity> userManager) : base(context)
    {
        _userManager = userManager;
    }

    public override async Task<AppUserEntity> AddAsync(AppUserEntity entity, CancellationToken cancellationToken)
    {
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            UserCreateParameters parameter = new UserCreateParameters(
            entity.UserName,
            entity.UserName,//  Password
            entity.Email,
            entity.Name,
            entity.Family,
            entity.DisplayName,
            entity.PhoneNumber,
            entity.PersonalCode
            );
            UserEntity userEntity = new UserEntity(parameter);

            var result = await _userManager.CreateAsync(userEntity,Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException($"User Not Create {string.Join('|', result.Errors)}");
            }
            entity.SetId(userEntity.Id);
            return entity;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SetPassword(string password)
    {
        Password = password;
    }

    public async Task<AppUserEntity> GetByEmailAsync(string email)
    {
        var test1 = await Entity.Where(item => item.Email.ToLower().Equals(email.ToLower())).SingleOrDefaultAsync()!;
        var test2 = await _userManager.FindByEmailAsync(email);
        
        return test1;
    }

    public async Task<AppUserEntity> GetByUsernameAsync(string username)
    {
        var test1 = await _userManager.FindByNameAsync(username);
        var test2 = await Entity.Where(item => item.UserName == username).SingleOrDefaultAsync()!;
        
        return test2;
    }
}
