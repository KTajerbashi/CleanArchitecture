using Application.Library.Patterns.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Library.Patterns.UnitOfWork
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        // Implement repository methods...
    }
}