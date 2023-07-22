using Application.Library.Interfaces;
using Common.Library;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistance.Library.DbContexts
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}
