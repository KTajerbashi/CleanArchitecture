using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Core.Application.Library.Utilities.Extensions;

public static class TypeExtentsions
{
    public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
    {
        while (toCheck != null && toCheck != typeof(object))
        {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur)
            {
                return true;
            }
            toCheck = toCheck.BaseType;
        }
        return false;
    }

    public static string GetAttribute(this Type type)
    {
        var tableAtt = type.GetCustomAttributes(typeof(TableAttribute), false)
                                 .Cast<TableAttribute>()
                                 .FirstOrDefault();
        //var descAtt = type.GetCustomAttributes(typeof(DescriptionAttribute), false)
        //                               .Cast<DescriptionAttribute>()
        //                               .FirstOrDefault();
        //if(descAtt is null)
        //    descAtt = type.GetCustomAttributes(typeof(CommentAttribute), false)
        //                               .Cast<CommentAttribute>()
        //                               .FirstOrDefault();
        return $"[{tableAtt.Schema}].[{tableAtt.Name}]";
    }
}
