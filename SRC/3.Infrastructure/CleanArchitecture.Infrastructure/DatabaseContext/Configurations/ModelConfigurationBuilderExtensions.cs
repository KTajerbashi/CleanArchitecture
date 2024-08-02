using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DatabaseContext.Configurations;

public static class ModelConfigurationBuilderExtensions
{
    public static ModelConfigurationBuilder AddModelConfigurationBuilder(this ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder.AddConversion();


    private static ModelConfigurationBuilder AddConversion(this ModelConfigurationBuilder configurationBuilder)
    {
        //configurationBuilder.Properties<Guid>(cfg => cfg.HaveConversion<GuidConversion>());
        return configurationBuilder;
    }


}
