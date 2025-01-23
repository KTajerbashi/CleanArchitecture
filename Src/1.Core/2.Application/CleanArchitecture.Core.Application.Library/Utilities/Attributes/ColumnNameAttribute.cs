namespace CleanArchitecture.Core.Application.Library.Utilities.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ColumnNameAttribute : Attribute
{
    public string Name { get; }
    public ColumnNameAttribute(string name)
    {
        Name = name;
    }
}