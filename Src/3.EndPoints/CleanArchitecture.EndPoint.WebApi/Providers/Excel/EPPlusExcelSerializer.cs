using CleanArchitecture.Core.Application.Library.Providers.Serializer.Excel.Extensions;
using CleanArchitecture.Core.Application.Library.Providers.Serializer.Objects.Extensions;
using CleanArchitecture.EndPoint.WebApi.Providers.Excel.Attributes;
using ClosedXML.Excel;
using OfficeOpenXml;
using System.Data;
using static CleanArchitecture.EndPoint.WebApi.Providers.Excel.Attributes.ExcelPropertyAttribute;

namespace CleanArchitecture.Core.Application.Library.Providers.Serializer.Excel;

public class EPPlusExcelSerializer : IExcelSerializer
{
    public EPPlusExcelSerializer()
    {
        // Set this once at application startup (Program.cs/Startup.cs)
        ExcelPackage.License.SetNonCommercialPersonal("NonCommercialPersonal");
    }
    public byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result") => list.ToExcelByteArray(sheetName);

    public DataTable ExcelToDataTable(byte[] bytes) => bytes.ToDataTableFromExcel();

    public List<T> ExcelToList<T>(byte[] bytes) => bytes.ToDataTableFromExcel().ToList<T>();

    public string ExportExcelFile<T>(T model, ExcelGenerator excelGenerator = ExcelGenerator.CloseXML, string folderName = "Export\\Excel")
    {
        Directory.CreateDirectory(folderName);
        string fileName = $"{typeof(T).Name}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
        string filePath = Path.Combine(folderName, fileName);

        switch (excelGenerator)
        {
            case ExcelGenerator.EPPlus:
                ExportWithEPPlus(model, filePath);
                break;
            case ExcelGenerator.CloseXML:
            default:
                ExportWithClosedXML(model, filePath);
                break;
        }

        return filePath;
    }

    public string ExportExcelFile<T>(List<T> data, ExcelGenerator excelGenerator = ExcelGenerator.CloseXML, string folderName = "Export\\Excel")
    {
        if (data == null || !data.Any())
            throw new ArgumentException("Data list cannot be null or empty");

        Directory.CreateDirectory(folderName);
        string fileName = $"{typeof(T).Name}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
        string filePath = Path.Combine(folderName, fileName);

        switch (excelGenerator)
        {
            case ExcelGenerator.EPPlus:
                ExportListWithEPPlus(data, filePath);
                break;
            case ExcelGenerator.CloseXML:
            default:
                ExportListWithClosedXML(data, filePath);
                break;
        }

        return filePath;
    }

    #region ClosedXML Implementation
    private void ExportWithClosedXML<T>(T model, string filePath)
    {
        using (var workbook = new XLWorkbook())
        {
            ProcessModelWithClosedXML(workbook, model);
            workbook.SaveAs(filePath);
        }
    }

    private void ExportListWithClosedXML<T>(List<T> data, string filePath)
    {
        using (var workbook = new XLWorkbook())
        {
            ProcessListWithClosedXML(workbook, data);
            workbook.SaveAs(filePath);
        }
    }

    private void ProcessModelWithClosedXML<T>(XLWorkbook workbook, T model)
    {
        var type = typeof(T);
        var sheetAttributes = type.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                                .OfType<ExcelPropertyAttribute>()
                                .Where(a => a.Type == ExcelProperty.Sheet)
                                .ToList();

        if (sheetAttributes.Any())
        {
            foreach (var sheetAttr in sheetAttributes)
            {
                var worksheet = workbook.Worksheets.Add(sheetAttr.Title);
                worksheet.RightToLeft = true;

                foreach (var prop in type.GetProperties())
                {
                    var tableAttributes = prop.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                                           .OfType<ExcelPropertyAttribute>()
                                           .Where(a => a.Type == ExcelProperty.Table)
                                           .ToList();

                    foreach (var tableAttr in tableAttributes)
                    {
                        ProcessTableWithClosedXML(worksheet, prop.GetValue(model), tableAttr);
                    }
                }
            }
        }
        else
        {
            var worksheet = workbook.Worksheets.Add(type.Name);
            worksheet.RightToLeft = true;
            ProcessTableWithClosedXML(worksheet, model, null);
        }
    }

    private void ProcessListWithClosedXML<T>(XLWorkbook workbook, List<T> data)
    {
        var type = typeof(T);
        var sheetAttributes = type.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                                .OfType<ExcelPropertyAttribute>()
                                .Where(a => a.Type == ExcelProperty.Sheet)
                                .ToList();

        string sheetName = sheetAttributes.FirstOrDefault()?.Title ?? type.Name;
        var worksheet = workbook.Worksheets.Add(sheetName);
        worksheet.RightToLeft = true;

        var columnProperties = GetColumnProperties(type);

        // Write headers
        int col = 1;
        foreach (var prop in columnProperties)
        {
            worksheet.Cell(1, col).Value = prop.Attribute.Title;
            worksheet.Cell(1, col).Style.Font.Bold = true;
            worksheet.Cell(1, col).Style.Fill.BackgroundColor = XLColor.LightGray;
            col++;
        }

        // Write data
        int row = 2;
        foreach (var item in data)
        {
            col = 1;
            foreach (var prop in columnProperties)
            {
                worksheet.Cell(row, col).Value = prop.Property.GetValue(item)?.ToString() ?? string.Empty;
                col++;
            }
            row++;
        }

        worksheet.Columns().AdjustToContents();
    }
    #endregion

    #region EPPlus Implementation
    private void ExportWithEPPlus<T>(T model, string filePath)
    {
        // Set license context first (must be done before any EPPlus operations)
        using (var package = new ExcelPackage())
        {
            ProcessModelWithEPPlus(package, model);
            package.SaveAs(new FileInfo(filePath));
        }
    }

    private void ExportListWithEPPlus<T>(List<T> data, string filePath)
    {
        // Set license context first (must be done before any EPPlus operations)
        //ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // or LicenseContext.Commercial

        using (var package = new ExcelPackage())
        {
            ProcessListWithEPPlus(package, data);
            package.SaveAs(new FileInfo(filePath));
        }
    }

    private void ProcessModelWithEPPlus<T>(ExcelPackage package, T model)
    {
        var type = typeof(T);
        var sheetAttributes = type.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                                .OfType<ExcelPropertyAttribute>()
                                .Where(a => a.Type == ExcelProperty.Sheet)
                                .ToList();

        if (sheetAttributes.Any())
        {
            foreach (var sheetAttr in sheetAttributes)
            {
                var worksheet = package.Workbook.Worksheets.Add(sheetAttr.Title);
                worksheet.View.RightToLeft = true;

                foreach (var prop in type.GetProperties())
                {
                    var tableAttributes = prop.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                                           .OfType<ExcelPropertyAttribute>()
                                           .Where(a => a.Type == ExcelProperty.Table)
                                           .ToList();

                    foreach (var tableAttr in tableAttributes)
                    {
                        ProcessTableWithEPPlus(worksheet, prop.GetValue(model), tableAttr);
                    }
                }
            }
        }
        else
        {
            var worksheet = package.Workbook.Worksheets.Add(type.Name);
            worksheet.View.RightToLeft = true;
            ProcessTableWithEPPlus(worksheet, model, null);
        }
    }

    private void ProcessListWithEPPlus<T>(ExcelPackage package, List<T> data)
    {
        var type = typeof(T);
        var sheetAttributes = type.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                                .OfType<ExcelPropertyAttribute>()
                                .Where(a => a.Type == ExcelProperty.Sheet)
                                .ToList();

        string sheetName = sheetAttributes.FirstOrDefault()?.Title ?? type.Name;
        var worksheet = package.Workbook.Worksheets.Add(sheetName);
        worksheet.View.RightToLeft = true;

        var columnProperties = GetColumnProperties(type);

        // Write headers
        int col = 1;
        foreach (var prop in columnProperties)
        {
            worksheet.Cells[1, col].Value = prop.Attribute.Title;
            worksheet.Cells[1, col].Style.Font.Bold = true;
            worksheet.Cells[1, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[1, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
            col++;
        }

        // Write data
        int row = 2;
        foreach (var item in data)
        {
            col = 1;
            foreach (var prop in columnProperties)
            {
                worksheet.Cells[row, col].Value = prop.Property.GetValue(item);
                col++;
            }
            row++;
        }

        worksheet.Cells.AutoFitColumns();
    }
    #endregion

    #region Common Helpers
    private IEnumerable<dynamic> GetColumnProperties(Type type)
    {
        return type.GetProperties()
            .Select(p => new
            {
                Property = p,
                Attribute = p.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                           .OfType<ExcelPropertyAttribute>()
                           .FirstOrDefault(a => a.Type == ExcelProperty.Column)
            })
            .Where(x => x.Attribute != null)
            .OrderBy(x => x.Attribute.Order);
    }

    private void ProcessTableWithClosedXML(IXLWorksheet worksheet, object data, ExcelPropertyAttribute tableAttr)
    {
        if (data == null) return;

        var dataType = data.GetType();
        if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() == typeof(List<>))
        {
            var list = (System.Collections.IList)data;
            if (list.Count == 0) return;
            ProcessListInternalWithClosedXML(worksheet, list, list[0].GetType(), tableAttr?.Title);
        }
        else
        {
            ProcessObjectWithClosedXML(worksheet, data, tableAttr?.Title);
        }
    }

    private void ProcessTableWithEPPlus(ExcelWorksheet worksheet, object data, ExcelPropertyAttribute tableAttr)
    {
        if (data == null) return;

        var dataType = data.GetType();
        if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() == typeof(List<>))
        {
            var list = (System.Collections.IList)data;
            if (list.Count == 0) return;
            ProcessListInternalWithEPPlus(worksheet, list, list[0].GetType(), tableAttr?.Title);
        }
        else
        {
            ProcessObjectWithEPPlus(worksheet, data, tableAttr?.Title);
        }
    }

    private void ProcessListInternalWithClosedXML(IXLWorksheet worksheet, System.Collections.IList list, Type itemType, string tableTitle)
    {
        int startRow = worksheet.LastRowUsed()?.RowNumber() + 2 ?? 1;

        if (!string.IsNullOrEmpty(tableTitle))
        {
            var titleCell = worksheet.Cell(startRow, 1);
            titleCell.Value = tableTitle;

            var columnCount = itemType.GetProperties()
                .Count(p => p.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                           .OfType<ExcelPropertyAttribute>()
                           .Any(a => a.Type == ExcelProperty.Column));

            if (columnCount > 1)
            {
                worksheet.Range(startRow, 1, startRow, columnCount).Merge();
            }

            titleCell.Style.Font.Bold = true;
            titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            titleCell.Style.Fill.BackgroundColor = XLColor.LightGray;
            startRow++;
        }

        var columnProperties = GetColumnProperties(itemType);

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
                worksheet.Cell(row, col).Value = prop.Property.GetValue(item)?.ToString() ?? string.Empty;
                col++;
            }
            row++;
        }

        worksheet.Columns().AdjustToContents();

        if (list.Count > 0)
        {
            var dataRange = worksheet.Range(startRow, 1, startRow + list.Count, columnProperties.Count());
            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        }
    }

    private void ProcessListInternalWithEPPlus(ExcelWorksheet worksheet, System.Collections.IList list, Type itemType, string tableTitle)
    {
        int startRow = worksheet.Dimension?.End.Row + 2 ?? 1;

        if (!string.IsNullOrEmpty(tableTitle))
        {
            worksheet.Cells[startRow, 1].Value = tableTitle;

            var columnCount = itemType.GetProperties()
                .Count(p => p.GetCustomAttributes(typeof(ExcelPropertyAttribute), false)
                           .OfType<ExcelPropertyAttribute>()
                           .Any(a => a.Type == ExcelProperty.Column));

            if (columnCount > 1)
            {
                worksheet.Cells[startRow, 1, startRow, columnCount].Merge = true;
            }

            var titleCell = worksheet.Cells[startRow, 1];
            titleCell.Style.Font.Bold = true;
            titleCell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            titleCell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            titleCell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
            startRow++;
        }

        var columnProperties = GetColumnProperties(itemType);

        // Write headers
        int col = 1;
        foreach (var prop in columnProperties)
        {
            var headerCell = worksheet.Cells[startRow, col];
            headerCell.Value = prop.Attribute.Title;
            headerCell.Style.Font.Bold = true;
            headerCell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            headerCell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
            col++;
        }

        // Write data
        int row = startRow + 1;
        foreach (var item in list)
        {
            col = 1;
            foreach (var prop in columnProperties)
            {
                worksheet.Cells[row, col].Value = prop.Property.GetValue(item);
                col++;
            }
            row++;
        }

        worksheet.Cells.AutoFitColumns();

        if (list.Count > 0)
        {
            var dataRange = worksheet.Cells[startRow, 1, startRow + list.Count, columnProperties.Count()];
            dataRange.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            dataRange.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            dataRange.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            dataRange.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            //dataRange.Style.Border.InsideHorizontal.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            //dataRange.Style.Border.InsideVertical.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        }
    }

    private void ProcessObjectWithClosedXML(IXLWorksheet worksheet, object data, string tableTitle)
    {
        if (data == null) return;

        int startRow = worksheet.LastRowUsed()?.RowNumber() + 2 ?? 1;

        // Add table title if exists
        if (!string.IsNullOrEmpty(tableTitle))
        {
            worksheet.Cell(startRow, 1).Value = tableTitle;
            worksheet.Cell(startRow, 1).Style.Font.Bold = true;
            worksheet.Cell(startRow, 1).Style.Fill.BackgroundColor = XLColor.LightGray;
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
            // Property name
            worksheet.Cell(row, 1).Value = prop.Attribute.Title;
            worksheet.Cell(row, 1).Style.Font.Bold = true;
            worksheet.Cell(row, 1).Style.Fill.BackgroundColor = XLColor.LightGray;

            // Property value
            var value = prop.Property.GetValue(data);
            worksheet.Cell(row, 2).Value = value?.ToString() ?? string.Empty;

            row++;
        }

        // Add borders
        if (properties.Count > 0)
        {
            var dataRange = worksheet.Range(startRow, 1, startRow + properties.Count - 1, 2);
            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        }

        worksheet.Columns().AdjustToContents();
    }

    private void ProcessObjectWithEPPlus(ExcelWorksheet worksheet, object data, string tableTitle)
    {
        if (data == null) return;

        int startRow = worksheet.Dimension?.End.Row + 2 ?? 1;

        // Add table title if exists
        if (!string.IsNullOrEmpty(tableTitle))
        {
            worksheet.Cells[startRow, 1].Value = tableTitle;
            worksheet.Cells[startRow, 1].Style.Font.Bold = true;
            worksheet.Cells[startRow, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[startRow, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
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
            // Property name
            worksheet.Cells[row, 1].Value = prop.Attribute.Title;
            worksheet.Cells[row, 1].Style.Font.Bold = true;
            worksheet.Cells[row, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[row, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

            // Property value
            var value = prop.Property.GetValue(data);
            worksheet.Cells[row, 2].Value = value?.ToString() ?? string.Empty;

            row++;
        }

        // Add borders
        if (properties.Count > 0)
        {
            var dataRange = worksheet.Cells[startRow, 1, startRow + properties.Count - 1, 2];
            dataRange.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            dataRange.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            dataRange.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            dataRange.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        }

        worksheet.Cells.AutoFitColumns();
    }
    #endregion
}



