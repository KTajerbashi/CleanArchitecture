namespace CleanArchitecture.EndPoint.WebApi.Providers.Excel.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
public class ExcelPropertyAttribute : Attribute
{
    public string Name { get; }
    public string Title { get; }
    public ExcelProperty Type { get; }
    public int Order { get; set; }

    public ExcelPropertyAttribute(string name, string title, ExcelProperty type)
    {
        Name = name;
        Title = title;
        Type = type;
    }

    public enum ExcelProperty : byte
    {
        Column = 1,
        Table = 2,
        Sheet = 3,
    }
    public enum ExcelGenerator : byte
    {
        EPPlus = 1,
        CloseXML = 2,
    }
}