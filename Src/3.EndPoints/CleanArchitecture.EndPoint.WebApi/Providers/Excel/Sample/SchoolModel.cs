using CleanArchitecture.EndPoint.WebApi.Providers.Excel.Attributes;
using static CleanArchitecture.EndPoint.WebApi.Providers.Excel.Attributes.ExcelPropertyAttribute;

namespace CleanArchitecture.EndPoint.WebApi.Providers.Excel.Sample;

[ExcelProperty("Students", "Student Report", ExcelProperty.Sheet)]
public class SchoolModel
{
    [ExcelProperty("Teachers", "گزارش اطلاعات مدرسین ", ExcelProperty.Table)]
    public List<TeacherModel> Teachers { get; set; }
    [ExcelProperty("Students", "گزارش اطلاعات دانشجویان", ExcelProperty.Table)]
    public List<StudentModel> Students { get; set; }
}

[ExcelProperty("Teachers", "Teacher Report", ExcelProperty.Table)]
public class TeacherModel
{
    [ExcelProperty("DisplayName", "نام نمایشی", ExcelProperty.Column)]
    public string DisplayName { get; set; }
    [ExcelProperty("PhoneNumber", "شماره تماس", ExcelProperty.Column)]
    public string PhoneNumber { get; set; }
    [ExcelProperty("PersonalCode", "شناسه", ExcelProperty.Column)]
    public string PersonalCode { get; set; }
    [ExcelProperty("Degree", "درجه تحصیلی", ExcelProperty.Column)]
    public string Degree { get; set; }
    [ExcelProperty("Age", "سن", ExcelProperty.Column)]
    public int Age { get; set; }
}
[ExcelProperty("Students", "Student Report", ExcelProperty.Table)]
public class StudentModel
{
    [ExcelProperty("DisplayName", "نام نمایشی", ExcelProperty.Column)]
    public string DisplayName { get; set; }
    [ExcelProperty("PhoneNumber", "شماره تماس", ExcelProperty.Column)]
    public string PhoneNumber { get; set; }
    [ExcelProperty("PersonalCode", "شناسه", ExcelProperty.Column)]
    public string PersonalCode { get; set; }
    [ExcelProperty("Degree", "درجه تحصیلی", ExcelProperty.Column)]
    public string Degree { get; set; }
    [ExcelProperty("UnitPassed", "واحد های پاس شده", ExcelProperty.Column)]
    public int UnitPassed { get; set; }
    [ExcelProperty("UnitFaild", "واحد های پاس نشده", ExcelProperty.Column)]
    public int UnitFaild { get; set; }
    public DateTime EntryDate { get; set; }
    [ExcelProperty("EntryDatePersion", "تاریخ ورود", ExcelProperty.Column)]
    public string EntryDatePersian { get => EntryDate.ToString("G"); }
    public DateTime BirthDate { get; set; }
    [ExcelProperty("BirthDate", "تاریخ تولد", ExcelProperty.Column)]
    public string BirthDatePersian { get => BirthDate.ToString("G"); }
    [ExcelProperty("Age", "سن", ExcelProperty.Column)]
    public int Age { get; set; }
}
