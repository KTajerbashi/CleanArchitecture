using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Core.Domain.Library.BaseCoreDomain;

/// <summary>
/// Base interface for all entities in the domain.
/// </summary>
/// <typeparam name="TId">Type of the entity identifier.</typeparam>
public interface IEntity<TId>
    where TId : notnull
{
    TId Id { get; }
}

/// <summary>
/// Base class for all entities, providing common properties and methods.
/// </summary>
/// <typeparam name="TId">Type of the entity identifier.</typeparam>
public abstract class Entity<TId> : IEntity<TId>
    where TId : notnull
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TId Id { get; protected set; }

    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;

    /// <summary>
    /// Marks the entity as deleted.
    /// </summary>
    public void Delete()
    {
        IsDeleted = true;
        IsActive = false;
    }

    /// <summary>
    /// Reactivates the entity.
    /// </summary>
    public void Activate()
    {
        IsDeleted = false;
        IsActive = true;
    }
}

/// <summary>
/// Default implementation of an entity with an integer identifier.
/// </summary>
public abstract class Entity : Entity<int>
{
}

/// <summary>
/// Interface for auditable entities.
/// </summary>
/// <typeparam name="TId">Type of the entity identifier.</typeparam>
public interface IAuditableEntity<TId> : IEntity<TId>
    where TId : notnull
{
    TId CreatedBy { get; }
    DateTime CreatedAt { get; }
    TId? UpdatedBy { get; }
    DateTime? UpdatedAt { get; }
}

/// <summary>
/// Base class for auditable entities.
/// </summary>
/// <typeparam name="TId">Type of the entity identifier.</typeparam>
public abstract class AuditableEntity<TId> : Entity<TId>, IAuditableEntity<TId>
    where TId : notnull
{
    public TId CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public TId? UpdatedBy { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    /// <summary>
    /// Updates audit information.
    /// </summary>
    /// <param name="updatedBy">ID of the user updating the entity.</param>
    public void Update(TId updatedBy)
    {
        UpdatedBy = updatedBy;
        UpdatedAt = DateTime.UtcNow;
    }
}

/// <summary>
/// Default implementation of an auditable entity with an integer identifier.
/// </summary>
public abstract class AuditableEntity : AuditableEntity<int>
{
    
}
