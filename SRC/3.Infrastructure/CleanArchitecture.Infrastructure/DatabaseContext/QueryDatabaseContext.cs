using CleanArchitecture.Infrastructure.BaseInfrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DatabaseContext;

public class QueryDatabaseContext : BaseQueryDatabaseContext
{

    public QueryDatabaseContext(DbContextOptions<QueryDatabaseContext> options) : base(options)
    {

    }
}