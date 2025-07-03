using CleanArchitecture.EndPoint.WebApi.Providers.Excel;
using CleanArchitecture.EndPoint.WebApi.Providers.Excel.Sample;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Common;

public class ExcelExporterController : BaseController
{
    private readonly IExcelSerializer _excelSerializer;
    public ExcelExporterController(IExcelSerializer excelSerializer)
    {
        _excelSerializer = excelSerializer;
    }

    [HttpGet("ListToExcelByteArray")]
    public IActionResult ListToExcelByteArray()
    {
        var data = getData();
        var result = _excelSerializer.ListToExcelByteArray(data.Teachers);
        return Ok(result);
    }

    [HttpGet("ExcelToDataTable")]
    public IActionResult ExcelToDataTable()
    {
        var data = getData();
        var result = _excelSerializer.ListToExcelByteArray(data.Teachers);
        var models = _excelSerializer.ExcelToDataTable(result);
        return Ok(result);
    }

    [HttpGet("ExcelToList")]
    public IActionResult ExcelToList()
    {
        var data = getData();
        var result = _excelSerializer.ListToExcelByteArray(data.Teachers);
        var models = _excelSerializer.ExcelToList<TeacherModel>(result);
        return Ok(models);
    }

    [HttpGet("ExportExcelFile")]
    public IActionResult ExportExcelFile()
    {
        var data = getData();
        var models = _excelSerializer.ExportExcelFile(data);
        return Ok(models);
    }

    [HttpGet("ExportExcelFileList")]
    public IActionResult ExportEExportExcelFileListxcelFile()
    {
        var data = getData();
        var models = _excelSerializer.ExportExcelFile(data.Teachers,folderName:"Export\\Excel\\Teachers");
        return Ok(models);
    }

    [HttpGet("ExportExcelFilePath")]
    public IActionResult ExportExcelFilePath()
    {
        var data = getData();

        // Export single model (SchoolModel)
        var filePath1 = _excelSerializer.ExportExcelFile(data);

        // Export list of items (e.g., Teachers)
        var filePath2 = _excelSerializer.ExportExcelFile(data.Teachers);
        return Ok(new
        {
            SchoolPath = filePath1,
            TeachersPath = filePath2,
        });
    }



    [HttpGet("OpenCloseGenerator")]
    public IActionResult OpenCloseGenerator()
    {
        var data = getData();

        // Export single model (SchoolModel)
        var filePath1 = _excelSerializer.ExportExcelFile(data);

        // Export list of items (e.g., Teachers)
        var filePath2 = _excelSerializer.ExportExcelFile(data.Teachers);
        return Ok(new
        {
            SchoolPath = filePath1,
            TeachersPath = filePath2,
        });
    }

    [HttpGet("EPPlusGenerator")]
    public IActionResult EPPlusGenerator()
    {
        var data = getData();

        // Export single model (SchoolModel)
        var filePath1 = _excelSerializer.ExportExcelFile(data,Providers.Excel.Attributes.ExcelPropertyAttribute.ExcelGenerator.EPPlus);

        // Export list of items (e.g., Teachers)
        var filePath2 = _excelSerializer.ExportExcelFile(data.Teachers,Providers.Excel.Attributes.ExcelPropertyAttribute.ExcelGenerator.EPPlus);
        return Ok(new
        {
            SchoolPath = filePath1,
            TeachersPath = filePath2,
        });
    }

    private SchoolModel getData()
    {
        var result = new SchoolModel();
        result.Teachers = new List<TeacherModel>()
        {
            new TeacherModel(){Age = 20,Degree = "Master",DisplayName = "محمد کریم",PersonalCode ="43904",PhoneNumber="09101001000"},
            new TeacherModel(){Age = 30,Degree = "Master",DisplayName = "محمد کریم",PersonalCode ="43476",PhoneNumber="09101002000"},
            new TeacherModel(){Age = 23,Degree = "Master",DisplayName = "محمد کریم",PersonalCode ="34733",PhoneNumber="09101003000"},
            new TeacherModel(){Age = 12,Degree = "Master",DisplayName = "محمد کریم",PersonalCode ="44337",PhoneNumber="09101004000"},
            new TeacherModel(){Age = 34,Degree = "Master",DisplayName = "محمد کریم",PersonalCode ="45674",PhoneNumber="09101005000"},
            new TeacherModel(){Age = 36,Degree = "Master",DisplayName = "محمد کریم",PersonalCode ="85643",PhoneNumber="09101006000"},
        };
        result.Students = new List<StudentModel>() {
            new StudentModel(){Age = 20,Degree="Bachlor",DisplayName = "جواد اکبری",PhoneNumber = "09012031203",PersonalCode="94039",BirthDate = DateTime.Now.AddYears(20),EntryDate = DateTime.Now.AddYears(-4),UnitFaild = 10,UnitPassed=140},
            new StudentModel(){Age = 22,Degree="Bachlor",DisplayName = "جواد اکبری",PhoneNumber = "09012032203",PersonalCode="94039",BirthDate = DateTime.Now.AddYears(20),EntryDate = DateTime.Now.AddYears(-4),UnitFaild = 10,UnitPassed=140},
            new StudentModel(){Age = 24,Degree="Bachlor",DisplayName = "جواد اکبری",PhoneNumber = "09012033203",PersonalCode="94039",BirthDate = DateTime.Now.AddYears(20),EntryDate = DateTime.Now.AddYears(-4),UnitFaild = 10,UnitPassed=140},
            new StudentModel(){Age = 25,Degree="Bachlor",DisplayName = "جواد اکبری",PhoneNumber = "09012034203",PersonalCode="94039",BirthDate = DateTime.Now.AddYears(20),EntryDate = DateTime.Now.AddYears(-4),UnitFaild = 10,UnitPassed=140},
            new StudentModel(){Age = 26,Degree="Bachlor",DisplayName = "جواد اکبری",PhoneNumber = "09012035203",PersonalCode="94039",BirthDate = DateTime.Now.AddYears(20),EntryDate = DateTime.Now.AddYears(-4),UnitFaild = 10,UnitPassed=140},
            new StudentModel(){Age = 27,Degree="Bachlor",DisplayName = "جواد اکبری",PhoneNumber = "09012036203",PersonalCode="94039",BirthDate = DateTime.Now.AddYears(20),EntryDate = DateTime.Now.AddYears(-4),UnitFaild = 10,UnitPassed=140},
            new StudentModel(){Age = 28,Degree="Bachlor",DisplayName = "جواد اکبری",PhoneNumber = "09012037203",PersonalCode="94039",BirthDate = DateTime.Now.AddYears(20),EntryDate = DateTime.Now.AddYears(-4),UnitFaild = 10,UnitPassed=140},
            new StudentModel(){Age = 29,Degree="Bachlor",DisplayName = "جواد اکبری",PhoneNumber = "09012038203",PersonalCode="94039",BirthDate = DateTime.Now.AddYears(20),EntryDate = DateTime.Now.AddYears(-4),UnitFaild = 10,UnitPassed=140},
        };
        return result;
    }
}
