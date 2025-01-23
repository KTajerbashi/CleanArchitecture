using CleanArchitecture.Core.Application.Library.Utilities.Extensions;
using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace CleanArchitecture.Core.Application.Library.Utilities.Extensions;

public static class ObjectExtensions
{
    public static string ToQueryString(this object obj)
    {
        if (obj is null) throw new ArgumentNullException("Object");

        var properties = obj.GetType().GetProperties()
            .Where(x => x.CanWrite)
            .Where(x => x.GetValue(obj, null) is not null)
            .Select(x => KeyValuePair.Create(x.Name, x.GetValue(obj, null))).ToList();

        var propertyNames = properties
            .Where(x => x.Value is not string && x.Value is IEnumerable)
            .Select(x => x.Key)
            .ToList();

        foreach (var key in propertyNames)
        {
            var valueType = properties.FirstOrDefault(x => x.Key == key).Value.GetType();

            var valueElemType = valueType.IsGenericType
                ? valueType.GetGenericArguments()[0]
                : valueType.GetElementType();

            if (valueElemType.IsPrimitive || valueElemType == typeof(string) || valueElemType == typeof(Guid))
            {
                var enumerable = properties.FirstOrDefault(c => c.Key == key).Value as IEnumerable;

                properties.RemoveAll(x => x.Key == key);

                foreach (var item in enumerable)
                {
                    properties.Add(KeyValuePair.Create(key, item));
                }
            }
        }

        return string.Join("&", properties.Where(x => x.Value is not null)
            .Select(x => string.Concat(
                Uri.EscapeDataString(x.Key), "=",
                Uri.EscapeDataString(x.Value.ToString()))));
    }
    public static string ToDetailString(this Exception ex)
    {
        return ex.Message + " " + ex.StackTrace + " " + (ex.InnerException == null ? "" : ex.InnerException.Message + " " + ex.InnerException.StackTrace);
    }

    public static PropertyInfo GetObjectProperty(object obj, string propName)
    {
        var prop = obj.GetType().GetProperty(propName);
        if (prop == null)
        {
            throw new Exception(string.Format("Property '{0}' does not found in object type '{1}'.", propName, obj.GetType().Name));
        }
        return prop;

    }
    public static IEnumerable<PropertyInfo> GetObjectProperties(this object obj, Func<PropertyInfo, bool> filter = null)
    {
        if (obj == null) return null;

        if (filter == null)
            filter = x => true;

        return obj.GetType().GetProperties().Where(filter);
    }
    public static Dictionary<string, object> ConvertToDictionary(this object obj, Func<PropertyInfo, bool> filter = null)
    {
        //If the object is a 'ExpandoObject' then convert it to the original one
        if (obj as IDictionary<string, object> != null)
        {
            return new Dictionary<string, object>(obj as IDictionary<string, object>);
        }

        var properties = obj.GetObjectProperties(filter);
        var result = new Dictionary<string, object>();

        //If object is null or it dosen't have any property returns an empty dictionary
        if (properties == null)
        {
            return result;
        }

        foreach (var item in properties)
        {
            result.Add(item.Name, item.GetValue(obj));
        }

        return result;
    }
    public static T GetAttribute<T>(this object obj, bool inherit = true)
        where T : Attribute
    {
        return obj.GetType().GetCustomAttribute<T>(inherit);
    }

    public static string GetAttribute(this Type obj, string attributName)
    {
        return obj.UnderlyingSystemType.CustomAttributes.FirstOrDefault(attr => attr.AttributeType.FullName == attributName).ConstructorArguments[0].Value.ToString();
    }

    public static IEnumerable<T> GetAttributes<T>(this object obj, bool inherit = true)
       where T : Attribute
    {
        return obj.GetType().GetCustomAttributes<T>(inherit);
    }

    public static T Clone<T>(this object source)
    {
        var serialized = JsonConvert.SerializeObject(source);
        return JsonConvert.DeserializeObject<T>(serialized);
    }

    public static void ThrowIfNull(this object obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));
    }

    public static string ToYesNoString(this bool boolValue)
    {
        return boolValue ? "بلی" : "خیر";
    }

    public static string ToYesNoString(this bool? boolValue, bool throwExceptionIfNull = false)
    {
        if (boolValue == null && throwExceptionIfNull)
            throw new NullReferenceException();

        return boolValue == null ? ""
            : boolValue.Value ? "بلی" : "خیر";
    }


}