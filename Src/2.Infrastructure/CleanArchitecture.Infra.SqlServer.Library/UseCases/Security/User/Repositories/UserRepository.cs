using CleanArchitecture.Core.Application.Library.Providers.ObjectMapper;
using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;
using CleanArchitecture.Core.Domain.Library.Common;
using CleanArchitecture.Infra.SqlServer.Library.Exceptions;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Security.User.Repositories;

public class UserRepository : Repository<AppUserEntity, long>, IUserRepository
{
    private readonly UserManager<UserEntity> _userManager;
    public string Password { get; private set; }
    private readonly IObjectMapper _mapper;
    public UserRepository(DatabaseContext context, UserManager<UserEntity> userManager, IObjectMapper mapper) : base(context)
    {
        _userManager = userManager;
        _mapper = mapper;
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
                throw new IdentityException(result.Errors);
            }
            entity.SetId(userEntity.Id);
            return entity;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public override IEnumerable<AppUserEntity> Get(CancellationToken cancellationToken)
        => _mapper.Map<UserEntity, AppUserEntity>(_userManager.Users);

    public override async Task<AppUserEntity> GetAsync(long id, CancellationToken cancellationToken)
    {
        var entity = await _userManager.Users.SingleOrDefaultAsync(item => item.Id == id);
        return _mapper.Map<UserEntity, AppUserEntity>(entity);
    }

    public override AppUserEntity Get(long id, CancellationToken cancellationToken)
    {
        var entity = _userManager.Users.SingleOrDefault(item => item.Id == id);
        return _mapper.Map<UserEntity, AppUserEntity>(entity);
    }

    public override async Task<AppUserEntity> GetAsync(Guid entityId, CancellationToken cancellationToken)
    {
        var entity = await _userManager.Users.SingleOrDefaultAsync(item => item.EntityId.Equals(entityId));
        return _mapper.Map<UserEntity, AppUserEntity>(entity);
    }
    public override AppUserEntity Get(Guid entityId, CancellationToken cancellationToken)
        => _mapper.Map<UserEntity, AppUserEntity>(_userManager.Users.SingleOrDefault(item => item.EntityId.Equals(entityId)));
    public override async Task<IEnumerable<AppUserEntity>> GetAsync(CancellationToken cancellationToken)
        => _mapper.Map<UserEntity, AppUserEntity>((await _userManager.Users.ToListAsync()));
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


    public override bool Remove(AppUserEntity entity, CancellationToken cancellationToken)
    {
        var item = Context.UserEntities.Single(item => item.EntityId.Equals(entity.EntityId));
        item.Delete();
        Context.SaveChanges();
        return true;
    }
    public override bool Remove(Guid entityId, CancellationToken cancellationToken)
    {
        var entity =  Context.UserEntities.Single(item => item.EntityId.Equals(entityId));
        entity.Delete();
        Context.SaveChanges();
        return true;
    }
    public override bool Remove(long id, CancellationToken cancellationToken)
    {
        var entity =  Context.UserEntities.Single(item => item.Id == id);
        entity.Delete();
        Context.SaveChanges();
        return true;
    }
    public override async Task<bool> RemoveAsync(AppUserEntity entity, CancellationToken cancellationToken)
    {
        var item = await  Context.UserEntities.SingleAsync(item => item.EntityId.Equals(entity.EntityId));
        item.Delete();
        Context.SaveChanges();
        return true;
    }
    public override async Task<bool> RemoveAsync(Guid entityId, CancellationToken cancellationToken)
    {
        var entity = await Context.UserEntities.SingleAsync(item => item.EntityId.Equals(entityId));
        entity.Delete();
        Context.SaveChanges();
        return true;
    }
    public override async Task<bool> RemoveAsync(long id, CancellationToken cancellationToken)
    {
        var entity =  await Context.UserEntities.SingleAsync(item => item.Id == id);
        entity.Delete();
        Context.SaveChanges();
        return true;
    }


}
