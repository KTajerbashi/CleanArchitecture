using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Utilities
{
    public static class ConvertDate
    {
        public static string GetPersionDate(DateTime date)
        {
            var pe = new PersianCalendar();
            return ($"{pe.GetYear(date)}/{pe.GetMonth(date)}/{pe.GetDayOfMonth(date)} {pe.GetHour(date)}:{pe.GetMinute(date)}:{pe.GetSecond(date)}");

        }
        public static string GetTime(DateTime date)
        {
            var pe = new PersianCalendar();
            return ($"{pe.GetHour(date)}:{pe.GetMinute(date)}:{pe.GetSecond(date)}");

        }
        public static string GetShortDate(DateTime date)
        {
            var pe = new PersianCalendar();
            return ($"{pe.GetYear(date)}/{pe.GetMonth(date)}/{pe.GetDayOfMonth(date)}");

        }
        public static DateTime GetGregorianDate(string date)
        {
            DateTime dt = DateTime.Parse(date, new CultureInfo("fa-IR"));
            return dt.ToUniversalTime();
        }
        public static string GetGregorianTime(string date)
        {
            DateTime dt = DateTime.Parse(date, new CultureInfo("fa-IR"));
            return dt.ToLongTimeString();
        }
    }
}
