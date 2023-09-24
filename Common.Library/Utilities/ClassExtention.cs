using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Utilities
{
    public static class ClassExtention
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
