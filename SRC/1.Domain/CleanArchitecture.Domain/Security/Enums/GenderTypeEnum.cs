using System.ComponentModel;

namespace CleanArchitecture.Domain.Security.Enums;

public enum GenderTypeEnum : byte
{
    [Description("مرد")]
    Male = 0,

    [Description("زن")]
    Female = 1,
}