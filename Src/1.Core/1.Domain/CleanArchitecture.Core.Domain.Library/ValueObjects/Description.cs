

namespace CleanArchitecture.Core.Domain.Library.ValueObjects;

public class Description : BaseValueObject<Description>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static Description FromString(string value) => new Description(value);
    private Description(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainValueObjectException("ValidationErrorIsRequire {0}", nameof(Description));
        }
        if (value.Length < 2 || value.Length > 250)
        {
            throw new DomainValueObjectException("ValidationErrorStringLength {0} {1} {2}", nameof(Title), "2", "250");
        }
        Value = value;
    }
    private Description()
    {

    }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(Description description) => description.Value;
    public static implicit operator Description(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion
}
