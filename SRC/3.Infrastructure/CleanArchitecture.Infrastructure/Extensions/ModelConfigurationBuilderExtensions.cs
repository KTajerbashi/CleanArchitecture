using CleanArchitecture.Domain.BasesDomain.ValueObjects.BusinessId;
using CleanArchitecture.Infrastructure.ValueConversions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Extensions;

public static class ModelConfigurationBuilderExtensions
{
    public static ModelConfigurationBuilder AddModelConfigurationBuilder(this ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder
                            .AddConversion();


    private static ModelConfigurationBuilder AddConversion(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<BusinessId>(cfg => cfg.HaveConversion<BusinessIdConversion>());
        return configurationBuilder;
    }


}
