using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseDatabaseContexts;
using CleanArchitecture.Infrastructure.DatabaseContext.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DatabaseContext;


/// <summary>
/// Business Database
/// </summary>
public class CleanArchitectureDb : BaseDatabaseContext
{
    public CleanArchitectureDb(DbContextOptions<CleanArchitectureDb> options) : base(options)
    {

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.AddModelConfigurationBuilder();
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.AddModelBuilder();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
