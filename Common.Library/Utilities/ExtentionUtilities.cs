using System.ComponentModel;

namespace Common.Library.Utilities
{
    public static class ExtentionUtilities
    {
        public static string GetDescription(Type type)
        {
            var descriptions = (DescriptionAttribute[])
            type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptions.Length == 0)
            {
                return null;
            }
            return descriptions[0].Description;
        }
    }
}
