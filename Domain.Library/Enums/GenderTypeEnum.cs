using System.ComponentModel;

namespace Domain.Library.Enums
{
    public enum GenderTypeEnum : byte
    {
        [Description("مرد")]
        Male = 0,

        [Description("زن")]
        Female = 1,
    }
    public enum LogTypeEnum
    {
        [Description("ثبت")]
        Added = 0,

        [Description("ویرایش")]
        Modified = 1,

        [Description("حذف")]
        Deleted = 2
    }
    public enum FactorTypeEnum
    {
        [Description("فعال")]
        Active = 0,

        [Description("بسته")]
        Closed = 1,

        [Description("برگشت")]
        Cancel = 2
    }
    public enum FileTypeEnum
    {
        [Description("عکس")]
        Picture = 0,

        [Description("صدا")]
        Sound = 1,

        [Description("پادکست")]
        Padcast = 2
    }
}
