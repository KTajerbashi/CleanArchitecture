﻿using CleanArchitecture.Domain.BasesDomain.ValueObjects.BusinessId;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseDatabaseContext;
using CleanArchitecture.Infrastructure.Extensions;
using CleanArchitecture.Infrastructure.ValueConversions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DatabaseContext;

/// <summary>
/// Business Database
/// </summary>
public class CleanArchitectureQueryDb : BaseQueryDatabaseContext
{

    public CleanArchitectureQueryDb(DbContextOptions<CleanArchitectureQueryDb> options) : base(options)
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
}