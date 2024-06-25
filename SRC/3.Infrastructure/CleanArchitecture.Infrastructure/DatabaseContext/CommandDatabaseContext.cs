using CleanArchitecture.Domain.BasesDomain.ValueObjects.BusinessId;
using CleanArchitecture.Infrastructure.BaseInfrastructure.DatabaseContext;
using CleanArchitecture.Infrastructure.ValueConversions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DatabaseContext;

public class CommandDatabaseContext : BaseCommandDatabaseContext
{
    public CommandDatabaseContext(DbContextOptions<CommandDatabaseContext> options):base(options)
    {
        
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<BusinessId>(cfg => cfg.HaveConversion<BusinessIdConversion>());
    }
}
