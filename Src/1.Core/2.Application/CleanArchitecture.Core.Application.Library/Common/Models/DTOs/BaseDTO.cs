namespace CleanArchitecture.Core.Application.Library.Common.Models.DTOs;

public interface IBaseDTO{}

public abstract class BaseDTO<TId> : IBaseDTO
{
    public TId Id { get; set; }
    public Guid EntityId { get; }
}
public abstract class BaseDTO : BaseDTO<long>
{
}

