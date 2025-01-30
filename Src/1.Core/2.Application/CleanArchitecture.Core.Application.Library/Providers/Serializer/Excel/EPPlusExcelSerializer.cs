using CleanArchitecture.Core.Application.Library.Providers.Serializer.Excel.Extensions;
using CleanArchitecture.Core.Application.Library.Providers.Serializer.Objects.Extensions;
using System.Data;

namespace CleanArchitecture.Core.Application.Library.Providers.Serializer.Excel;

public class EPPlusExcelSerializer : IExcelSerializer
{


    public byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result") => list.ToExcelByteArray(sheetName);

    public DataTable ExcelToDataTable(byte[] bytes) => bytes.ToDataTableFromExcel();

    public List<T> ExcelToList<T>(byte[] bytes) => bytes.ToDataTableFromExcel().ToList<T>();
}
