namespace CleanArchitecture.Core.Domain.Library.BaseCoreDomain;

public interface IEntity
{
}

public abstract class Entity : IEntity
{

}

public interface IAuditableEntity : IEntity
{
}


public abstract class AuditableEntity : Entity, IAuditableEntity
{

}