using Application.Library.Patterns.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Library.Patterns.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
