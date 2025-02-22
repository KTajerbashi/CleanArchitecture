using CleanArchitecture.Infra.SqlServer.Library.Data.Constants;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Seed;

public class InitializerSeedData
{
    private readonly ILogger<InitializerSeedData> _logger;
    private readonly DatabaseContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private readonly RoleManager<RoleEntity> _roleManager;
    public InitializerSeedData(
      ILogger<InitializerSeedData> logger,
      DatabaseContext context,
      UserManager<UserEntity> userManager,
      RoleManager<RoleEntity> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task RunAsync()
    {
        await InitialiseAsync();
        await SeedAsync();
    }
    private async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }


    private async Task SeedAsync()
    {
        try
        {
            await SeedRolesAsync();
            await SeedUsersAsync();
            await SeedDefaultDataAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task SeedRolesAsync()
    {
        var administratorRole = new RoleEntity(Roles.Administrator);

        if (await _roleManager.Roles.AllAsync(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }
    }
    private async Task SeedUsersAsync()
    {
        await createUser(new UserCreateParameters("tajerbashi","@Tajer123","tajer@mail.com","Kamran","Tajerbashi","Tajerbashi","1234561111","111-10"));
        await createUser(new UserCreateParameters("alex", "@Alex123", "tajeralexmail.com", "Alex","Mahoon", "Mahoon", "1234562222","222-10"));
        await createUser(new UserCreateParameters("trump", "@Trump123", "trump@mail.com", "Trump","Tio", "Tio", "1234562222","333-10"));
        await createUser(new UserCreateParameters("jourge", "@Jourge123", "jourge@mail.com", "Jourge","Minda", "Minda", "1234563333", "444-10"));
    }
    private async Task createUser(UserCreateParameters parameter)
    {
        var administrator = new UserEntity(parameter);

        // Check if the username or email already exists
        if (!await _userManager.Users.AnyAsync(u => u.UserName == administrator.UserName && u.Email == administrator.Email))
        {
            var createResult = await _userManager.CreateAsync(administrator, parameter.Password);
            if (createResult.Succeeded)
            {
                // Manually create a UserRoleEntity
                var role = _context.Set<RoleEntity>().Single(item => item.Name == Roles.Administrator);
                var userRoleEntity = new UserRoleEntity(administrator.Id,role.Id);
                // Add the user role entity to your context
                _context.UserRoles.Add(userRoleEntity);
                await _context.SaveChangesAsync();  // Save changes to commit the role assignment

                _logger.LogInformation($"User {administrator.UserName} assigned to Administrator role.");
            }
            else
            {
                _logger.LogError($"Failed to create {parameter.Username} user. Errors: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            _logger.LogWarning($"User with username '{parameter.Username}' or email '{administrator.Email}' already exists.");
        }
    }


    private async Task SeedDefaultDataAsync()
    {
        if (!await _context.Users.AnyAsync())
        {


            await _context.SaveChangesAsync();
        }
    }
}
