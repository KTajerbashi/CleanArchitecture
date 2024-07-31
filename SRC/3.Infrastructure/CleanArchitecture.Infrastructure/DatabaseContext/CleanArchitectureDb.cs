using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseDatabaseContext;
using CleanArchitecture.Infrastructure.Configurations.Interceptors;
using CleanArchitecture.Infrastructure.Extensions;
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
        builder.AddModelBuilder(this);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new ShadowPropertyInterceptor());
        base.OnConfiguring(optionsBuilder);
    }
}
