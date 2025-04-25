using CleanArchitecture.Core.Domain.Library.Exceptions;

namespace CleanArchitecture.Core.Domain.Library.Common;

public class EntityId : BaseValueObject<EntityId>
{
    public static EntityId FromString(string value) => new(value);
    public static EntityId FromGuid(Guid value) => new() { Value = value };

    public EntityId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException("ValidationErrorIsRequire", nameof(EntityId));
        }
        if (Guid.TryParse(value, out Guid tempValue))
        {
            Value = tempValue;
        }
        else
        {
            throw new DomainException("ValidationErrorInvalidValue", nameof(EntityId));
        }
    }
    private EntityId()
    {

    }

    public Guid Value { get; private set; }

    public override string ToString()
    {
        return Value.ToString();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static explicit operator string(EntityId title) => title.Value.ToString();
    public static implicit operator EntityId(string value) => new(value);


    public static explicit operator Guid(EntityId title) => title.Value;
    public static implicit operator EntityId(Guid value) => new() { Value = value };


}