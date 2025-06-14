using CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;

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
        await ApplyMigrationsAsync();
        await SeedDataAsync();
    }

    private async Task ApplyMigrationsAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while applying database migrations.");
            throw;
        }
    }

    private async Task SeedDataAsync()
    {
        try
        {
            await SeedRolesAsync();
            await SeedUsersAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task SeedRolesAsync()
    {
        await CreateRoleIfNotExistsAsync(Roles.Administrator);
        await CreateRoleIfNotExistsAsync(Roles.User);
    }

    private async Task CreateRoleIfNotExistsAsync(string roleName)
    {
        if (!await _roleManager.RoleExistsAsync(roleName))
        {
            var role = new RoleEntity(roleName, roleName);
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                _logger.LogError($"Failed to create role '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }

    private async Task SeedUsersAsync()
    {
        var usersToSeed = new List<(UserCreateParameters Parameters, string Role)>
        {
            (new UserCreateParameters("tajerbashi", "@Tajer123", "tajer@mail.com", "Kamran", "Tajerbashi", "Tajerbashi", "1234561111", "111-10"), Roles.Administrator),
            (new UserCreateParameters("alex", "@Alex123", "alex@.com", "Alex", "Mahoon", "Mahoon", "1234562222", "222-10"), Roles.User),
            (new UserCreateParameters("trump", "@Trump123", "trump@mail.com", "Trump", "Tio", "Tio", "1234562222", "333-10"), Roles.User),
            (new UserCreateParameters("jourge", "@Jourge123", "jourge@mail.com", "Jourge", "Minda", "Minda", "1234563333", "444-10"), Roles.User)
        };

        foreach (var (parameters, role) in usersToSeed)
        {
            await CreateUserAsync(parameters, role);
        }
    }

    private async Task CreateUserAsync(UserCreateParameters parameters, string roleName)
    {
        var user = new UserEntity(parameters);

        bool userExists = await _userManager.Users
            .AnyAsync(u => u.UserName == user.UserName || u.Email == user.Email);

        if (userExists)
        {
            _logger.LogWarning($"User '{user.UserName}' or email '{user.Email}' already exists.");
            return;
        }

        var result = await _userManager.CreateAsync(user, parameters.Password);
        if (!result.Succeeded)
        {
            _logger.LogError($"Failed to create user '{user.UserName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
            return;
        }

        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
        {
            _logger.LogWarning($"Role '{roleName}' not found. User '{user.UserName}' was created without role assignment.");
            return;
        }

        _context.UserRoles.Add(new UserRoleEntity(user.Id, role.Id));
        await _context.SaveChangesAsync();

        _logger.LogInformation($"User '{user.UserName}' assigned to '{roleName}' role.");
    }
}
