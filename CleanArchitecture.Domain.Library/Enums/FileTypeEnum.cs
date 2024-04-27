using System.ComponentModel;

namespace CleanArchitecture.Domain.Library.Enums
{
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
