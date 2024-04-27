using System.ComponentModel;

namespace CleanArchitecture.Domain.Library.Enums
{
    public enum GenderTypeEnum : byte
    {
        [Description("مرد")]
        Male = 0,

        [Description("زن")]
        Female = 1,
    }
}
