namespace CleanArchitecture.Infra.SqlServer.Library.Common.Repository;

public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : BaseAuditableEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly DatabaseContext Context;
    protected readonly DbSet<TEntity> Entity;

    protected Repository(DatabaseContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        Entity = Context.Set<TEntity>();
    }

    public virtual TEntity Add(TEntity entity, CancellationToken cancellationToken)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return Entity.Add(entity).Entity;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return (await Entity.AddAsync(entity, cancellationToken)).Entity;
    }

    public void BeginTransaction() => Context.Database.BeginTransaction();

    public async Task BeginTransactionAsync() => await Context.Database.BeginTransactionAsync();

    public void CommitTransaction() => Context.Database.CommitTransaction();

    public async Task CommitTransactionAsync() => await Context.Database.CommitTransactionAsync();

    public virtual TEntity Get(TId id, CancellationToken cancellationToken)
        => Entity.Find(id) ?? throw new KeyNotFoundException($"Entity with ID {id} not found");

    public virtual TEntity Get(Guid entityId, CancellationToken cancellationToken)
        => Entity.FirstOrDefault(item => item.EntityId.Equals(entityId))
           ?? throw new KeyNotFoundException($"Entity with EntityId {entityId} not found");

    public virtual IEnumerable<TEntity> Get(CancellationToken cancellationToken)
        => Entity.ToList();

    public virtual TEntity GetAsNoTracking(TId id, CancellationToken cancellationToken)
        => Entity.AsNoTracking().FirstOrDefault(e => e.Id.Equals(id))
           ?? throw new KeyNotFoundException($"Entity with ID {id} not found");

    public virtual TEntity GetAsNoTracking(Guid entityId, CancellationToken cancellationToken)
        => Entity.AsNoTracking().FirstOrDefault(item => item.EntityId.Equals(entityId))
           ?? throw new KeyNotFoundException($"Entity with EntityId {entityId} not found");

    public virtual async Task<TEntity> GetAsNoTrackingAsync(TId id, CancellationToken cancellationToken)
        => await Entity.AsNoTracking().FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken)
           ?? throw new KeyNotFoundException($"Entity with ID {id} not found");

    public virtual async Task<TEntity> GetAsNoTrackingAsync(Guid entityId, CancellationToken cancellationToken)
        => await Entity.AsNoTracking().FirstOrDefaultAsync(item => item.EntityId.Equals(entityId), cancellationToken)
           ?? throw new KeyNotFoundException($"Entity with EntityId {entityId} not found");

    public virtual async Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken)
        => await Entity.FindAsync(new object[] { id }, cancellationToken)
           ?? throw new KeyNotFoundException($"Entity with ID {id} not found");

    public virtual async Task<TEntity> GetAsync(Guid entityId, CancellationToken cancellationToken)
    {
        return await Entity
            .FirstOrDefaultAsync(item => item.EntityId.Value.ToString() == entityId.ToString(), cancellationToken)
            ?? throw new KeyNotFoundException($"Entity with EntityId {entityId} not found");
    }
    public virtual async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken)
        => await Entity.ToListAsync(cancellationToken);

    public virtual bool Remove(TEntity entity, CancellationToken cancellationToken)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        Entity.Remove(entity);
        return SaveChange() > 0;
    }

    public virtual bool Remove(TId id, CancellationToken cancellationToken)
    {
        var entity = Get(id, cancellationToken);
        return Remove(entity, cancellationToken);
    }

    public virtual bool Remove(Guid entityId, CancellationToken cancellationToken)
    {
        var entity = Get(entityId, cancellationToken);
        return Remove(entity, cancellationToken);
    }

    public virtual async Task<bool> RemoveAsync(TEntity entity, CancellationToken cancellationToken)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        Entity.Remove(entity);
        return await SaveChangeAsync(cancellationToken) > 0;
    }

    public virtual async Task<bool> RemoveAsync(TId id, CancellationToken cancellationToken)
    {
        var entity = await GetAsync(id, cancellationToken);
        return await RemoveAsync(entity, cancellationToken);
    }

    public virtual async Task<bool> RemoveAsync(Guid entityId, CancellationToken cancellationToken)
    {
        var entity = await GetAsync(entityId, cancellationToken);
        return await RemoveAsync(entity, cancellationToken);
    }

    public void RollbackTransaction() => Context.Database.RollbackTransaction();

    public async Task RollbackTransactionAsync() => await Context.Database.RollbackTransactionAsync();

    public virtual int SaveChange()
    {
        try
        {
            return Context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new Exception("Concurrency violation occurred", ex);
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Database update failed", ex);
        }
    }

    // In your Repository class, enhance SaveChangeAsync:
    public virtual async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new Exception("Concurrency violation occurred", ex);
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Database update failed", ex);
        }
    }

    // Additional helpful methods
    public virtual IQueryable<TEntity> GetAll()
        => Entity.AsQueryable();

    public virtual IQueryable<TEntity> GetAllAsNoTracking()
        => Entity.AsNoTracking();

    public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        => Entity.Where(predicate).ToList();

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
        => await Entity.Where(predicate).ToListAsync(cancellationToken);

    public bool Exists(Expression<Func<TEntity, bool>> predicate)
        => Entity.Any(predicate);

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
        => await Entity.AnyAsync(predicate, cancellationToken);
}