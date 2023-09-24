using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Common.Library
{
    public static class EnumHelpers<T>
    {
        public static IList<T> GetValues(Enum value)
        {
            var enumValues = new List<T>();

            foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((T)Enum.Parse(value.GetType(), fi.Name, false));
            }
            return enumValues;
        }

        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static IList<string> GetNames(Enum value)
        {
            return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        public static IList<string> GetDisplayValues(Enum value)
        {
            return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }

        private static string lookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }

            return resourceKey; // Fallback with the key name
        }

        public static string GetDisplayValue(T value)
        {
            try
            {
                var fieldInfo = value.GetType().GetField(value.ToString());

                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) as DisplayAttribute[];

                if (descriptionAttributes[0].ResourceType != null)
                    return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

                if (descriptionAttributes == null) return string.Empty;
                return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
            }
            catch (Exception)
            {

                return "نا مشخص";
            }

        }
    }
    public enum StatusCode : int
    {
        [Description("با موفقیت انجام شد")]
        OK=200,
        [Description("درخواست نادرست است")]
        BadRequest=400,
        [Description("پیدا نشد")]
        NotFound=404,
        [Description("متد قابل دستری نیست")]
        MethodNotAllowed=405,
        [Description("نعداد درخواست ها بیشتر از حد مجاز شد")]
        TooManyRequests =409,
        [Description("سرویس در دست تعمیر است لطفا صبور باشد")]
        InternalServerError=500,

    }
}
