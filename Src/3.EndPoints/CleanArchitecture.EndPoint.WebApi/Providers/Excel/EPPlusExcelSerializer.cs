using CleanArchitecture.Core.Application.Library.Providers.Serializer.Excel.Extensions;
using CleanArchitecture.Core.Application.Library.Providers.Serializer.Objects.Extensions;
using CleanArchitecture.EndPoint.WebApi.Providers.Excel.Attributes;
using ClosedXML.Excel;
using System.Data;
using static CleanArchitecture.EndPoint.WebApi.Providers.Excel.Attributes.ExcelPropertyAttribute;

namespace CleanArchitecture.Core.Application.Library.Providers.Serializer.Excel;

public class EPPlusExcelSerializer : IExcelSerializer
{
    public byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result") => list.ToExcelByteArray(sheetName);

    public DataTable ExcelToDataTable(byte[] bytes) => bytes.ToDataTableFromExcel();

    public List<T> ExcelToList<T>(byte[] bytes) => bytes.ToDataTableFromExcel().ToList<T>();

    public string ExportExcelFile<T>(T model, ExcelGenerator excelGenerator = ExcelGenerator.CloseXML, string folderName = "Export\\Excel")
    {
        // Create directory if it doesn't exist
        Directory.CreateDirectory(folderName);

        // Generate file name
        string fileName = $"{typeof(T).Name}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
        string filePath = Path.Combine(folderName, fileName);

        using (var workbook = new XLWorkbook())
        {
            ProcessModel(workbook, model);
            workbook.SaveAs(filePath);
        }

        return filePath;
    }

    public string ExportExcelFile<T>(List<T> data, ExcelGenerator excelGenerator = ExcelGenerator.CloseXML, string folderName = "Export\\Excel")
    {

        if (data == null || !data.Any())
            throw new ArgumentException("Data list cannot be null or empty");

        // Create directory if it doesn't exist
        Directory.CreateDirectory(folderName);

        // Generate file name
        string fileName = $"{typeof(T).Name}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
        string filePath = Path.Combine(folderName, fileName);

        using (var workbook = new XLWorkbook())
        {
            ProcessList(workbook, data);
            workbook.SaveAs(filePath);
        }

        return filePath;
    }
    private void ProcessModel<T>(XLWorkbook workbook, T model)
    {
        var type = typeof(T);
        var sheetAttributes = type.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                                .OfType<ExcelPropertyAttribute>()
                                .Where(a => a.Type == ExcelProperty.Sheet)
                                .ToList();

        // Create worksheet for each sheet attribute or default one
        if (sheetAttributes.Any())
        {
            foreach (var sheetAttr in sheetAttributes)
            {
                var worksheet = workbook.Worksheets.Add(sheetAttr.Title);

                // Process properties with Table attribute
                foreach (var prop in type.GetProperties())
                {
                    var tableAttributes = prop.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                                           .OfType<ExcelPropertyAttribute>()
                                           .Where(a => a.Type == ExcelProperty.Table)
                                           .ToList();

                    foreach (var tableAttr in tableAttributes)
                    {
                        ProcessTable(worksheet, prop.GetValue(model), tableAttr);
                    }
                }
            }
        }
        else
        {
            // Default behavior if no sheet attribute
            var worksheet = workbook.Worksheets.Add(type.Name);
            ProcessTable(worksheet, model, null);
        }
    }

    private void ProcessList<T>(XLWorkbook workbook, List<T> data)
    {
        var type = typeof(T);
        var sheetAttributes = type.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                                .OfType<ExcelPropertyAttribute>()
                                .Where(a => a.Type == ExcelProperty.Sheet)
                                .ToList();

        string sheetName = sheetAttributes.FirstOrDefault()?.Title ?? type.Name;
        var worksheet = workbook.Worksheets.Add(sheetName);

        // Get all properties with Column attribute
        var columnProperties = type.GetProperties()
            .Select(p => new
            {
                Property = p,
                Attribute = p.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                           .OfType<ExcelPropertyAttribute>()
                           .FirstOrDefault(a => a.Type == ExcelProperty.Column)
            })
            .Where(x => x.Attribute != null)
            .OrderBy(x => x.Attribute.Order)
            .ToList();

        // Write headers
        int col = 1;
        foreach (var prop in columnProperties)
        {
            worksheet.Cell(1, col).Value = prop.Attribute.Title;
            col++;
        }

        // Write data
        int row = 2;
        foreach (var item in data)
        {
            col = 1;
            foreach (var prop in columnProperties)
            {
                var value = prop.Property.GetValue(item);
                worksheet.Cell(row, col).Value = value?.ToString() ?? string.Empty;
                col++;
            }
            row++;
        }

        // Auto-fit columns
        worksheet.Columns().AdjustToContents();
    }

    private void ProcessTable(IXLWorksheet worksheet, object data, ExcelPropertyAttribute tableAttr)
    {
        if (data == null) return;

        var dataType = data.GetType();
        if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() == typeof(List<>))
        {
            var list = (System.Collections.IList)data;
            if (list.Count == 0) return;

            var itemType = list[0].GetType();
            ProcessListInternal(worksheet, list, itemType, tableAttr?.Title);
        }
        else
        {
            ProcessObject(worksheet, data, tableAttr?.Title);
        }
    }


    private void ProcessListInternal(IXLWorksheet worksheet, System.Collections.IList list, Type itemType, string tableTitle)
    {
        worksheet.RightToLeft = true;
        // Find the first empty row
        int startRow = worksheet.LastRowUsed()?.RowNumber() + 2 ?? 1;

        // Add table title if exists
        if (!string.IsNullOrEmpty(tableTitle))
        {
            // Merge cells for the table title (span all columns)
            var titleCell = worksheet.Cell(startRow, 1);
            titleCell.Value = tableTitle;

            // Get all properties with Column attribute to determine column count
            var columnCount = itemType.GetProperties()
            .Count(p => p.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                       .OfType<ExcelPropertyAttribute>()
                       .Any(a => a.Type == ExcelPropertyAttribute.ExcelProperty.Column));

            if (columnCount > 1)
            {
                worksheet.Range(startRow, 1, startRow, columnCount).Merge();
            }

            // Style the header
            titleCell.Style.Font.Bold = true;
            titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            titleCell.Style.Fill.BackgroundColor = XLColor.LightGray;

            startRow++;
        }

        // Get all properties with Column attribute
        var columnProperties = itemType.GetProperties()
        .Select(p => new
        {
            Property = p,
            Attribute = p.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                       .OfType<ExcelPropertyAttribute>()
                       .FirstOrDefault(a => a.Type == ExcelProperty.Column)
        })
        .Where(x => x.Attribute != null)
        .OrderBy(x => x.Attribute.Order)
        .ToList();

        // Write headers
        int col = 1;
        foreach (var prop in columnProperties)
        {
            var headerCell = worksheet.Cell(startRow, col);
            headerCell.Value = prop.Attribute.Title;
            headerCell.Style.Font.Bold = true;
            headerCell.Style.Fill.BackgroundColor = XLColor.LightGray;
            col++;
        }

        // Write data
        int row = startRow + 1;
        foreach (var item in list)
        {
            col = 1;
            foreach (var prop in columnProperties)
            {
                var value = prop.Property.GetValue(item);
                worksheet.Cell(row, col).Value = value?.ToString() ?? string.Empty;
                col++;
            }
            row++;
        }

        // Auto-fit columns
        worksheet.Columns().AdjustToContents();

        // Add borders to the data range
        if (list.Count > 0)
        {
            var dataRange = worksheet.Range(startRow, 1, startRow + list.Count, columnProperties.Count);
            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        }
    }

    private void ProcessObject(IXLWorksheet worksheet, object data, string tableTitle)
    {
        // Find the first empty row
        int startRow = worksheet.LastRowUsed()?.RowNumber() + 2 ?? 1;

        // Add table title if exists
        if (!string.IsNullOrEmpty(tableTitle))
        {
            worksheet.Cell(startRow, 1).Value = tableTitle;
            startRow++;
        }

        var properties = data.GetType().GetProperties()
            .Select(p => new
            {
                Property = p,
                Attribute = p.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                           .OfType<ExcelPropertyAttribute>()
                           .FirstOrDefault(a => a.Type == ExcelProperty.Column)
            })
            .Where(x => x.Attribute != null)
            .OrderBy(x => x.Attribute.Order)
            .ToList();

        int row = startRow;
        foreach (var prop in properties)
        {
            worksheet.Cell(row, 1).Value = prop.Attribute.Title;
            var value = prop.Property.GetValue(data);
            worksheet.Cell(row, 2).Value = value?.ToString() ?? string.Empty;
            row++;
        }
    }
}
