namespace CleanArchitecture.Core.Application.Common.Models.DTOs;

public interface IBaseDTO{}

public abstract class BaseDTO<TId> : IBaseDTO
{
    public TId Id { get; set; } = default!;
    public Guid EntityId { get; set; }
}
public abstract class BaseDTO : BaseDTO<long>
{
}

