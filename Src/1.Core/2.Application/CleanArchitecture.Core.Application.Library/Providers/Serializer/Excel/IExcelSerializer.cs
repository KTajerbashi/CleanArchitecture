using System.Data;

namespace CleanArchitecture.Core.Application.Library.Providers.Serializer.Excel;

public interface IExcelSerializer
{
    byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result");

    DataTable ExcelToDataTable(byte[] bytes);

    List<T> ExcelToList<T>(byte[] bytes);
}
