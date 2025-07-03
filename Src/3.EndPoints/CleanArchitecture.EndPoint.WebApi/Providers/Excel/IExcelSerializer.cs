using CleanArchitecture.EndPoint.WebApi.Providers.Excel.Attributes;
using System.Data;
using static CleanArchitecture.EndPoint.WebApi.Providers.Excel.Attributes.ExcelPropertyAttribute;

namespace CleanArchitecture.EndPoint.WebApi.Providers.Excel;

public interface IExcelSerializer
{
    byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result");

    DataTable ExcelToDataTable(byte[] bytes);

    List<T> ExcelToList<T>(byte[] bytes);

    string ExportExcelFile<T>(T model, ExcelGenerator excelGenerator = ExcelGenerator.CloseXML, string folderName = "Export\\Excel");
    string ExportExcelFile<T>(List<T> data, ExcelGenerator excelGenerator = ExcelGenerator.CloseXML, string folderName = "Export\\Excel");
}
