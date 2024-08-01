//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;

//namespace CleanArchitecture.Infrastructure.DatabaseContext;

//public class CleanArchitectureDbFactory : IDesignTimeDbContextFactory<CleanArchitectureDb>
//{
//    public CleanArchitectureDb CreateDbContext(string[] args)
//    {
//        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
//        var optionsBuilder = new DbContextOptionsBuilder<CleanArchitectureDb>();
//        if (!string.IsNullOrEmpty(environment))
//        {
//            var jsonFileName = string.IsNullOrEmpty(environment) ? "appsettings.json" : $"appsettings.{environment}.json";

//            // Set up configuration to read the appsettings.json file
//            IConfigurationRoot configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//            .AddJsonFile(jsonFileName, optional: true, reloadOnChange: true)
//            .Build();

//            var connectionString = configuration.GetConnectionString("CommandDb_ConnectionString");
//            optionsBuilder.UseSqlServer(connectionString);
//        }
//        return new CleanArchitectureDb(optionsBuilder.Options);
//    }
//}