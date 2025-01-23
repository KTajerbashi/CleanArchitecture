using CleanArchitecture.Core.Application.Library.Utilities.Extensions;
using System.Globalization;

namespace CleanArchitecture.Core.Application.Library.Utilities.DateTimes;
/// <summary>
/// متدهای کمکی جهت کار با تاریخ میلادی
/// </summary>
public static class DateTimeUtils
{
    /// <summary>
    /// Iran Standard Time
    /// </summary>
    public static readonly TimeZoneInfo IranStandardTime;

    /// <summary>
    /// Epoch represented as DateTime
    /// </summary>
    public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    static DateTimeUtils()
    {
        IranStandardTime = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(timeZoneInfo =>
            timeZoneInfo.StandardName.Contains("Iran") ||
            timeZoneInfo.StandardName.Contains("Tehran") ||
            timeZoneInfo.Id.Contains("Iran") ||
            timeZoneInfo.Id.Contains("Tehran"));
        if (IranStandardTime == null)
        {
#if NET40 || NET45 || NET46
                throw new PlatformNotSupportedException($"This OS[{Environment.OSVersion.Platform}, {Environment.OSVersion.Version}] doesn't support IranStandardTime.");
#else
            throw new PlatformNotSupportedException($"This OS[{System.Runtime.InteropServices.RuntimeInformation.OSDescription}] doesn't support IranStandardTime.");
#endif
        }
    }

    public static DateTime ParseExact(this string dateString, string format = "yyyy/MM/dd HH:mm:ss")
    {
        var datetime = Convert.ToDateTime(dateString).ToString(format);
        return Convert.ToDateTime(datetime);
    }
    public static string ParseExactString(this string dateString, string format = "yyyy/MM/dd HH:mm:ss")
    {
        return Convert.ToDateTime(dateString).ToString(format);
    }

    public static DateTime? ToGregorianDate(this string persianDate, string format = "ddd, dd MMM yyyy HH:mm:ss 'GMT'")
    {
        string[] components = persianDate.Split('/');
        int year = int.Parse(components[0]);
        int month = int.Parse(components[1]);
        int day = int.Parse(components[2]);
        // Create a PersianCalendar instance
        PersianCalendar persianCalendar = new PersianCalendar();

        // Convert the Persian date to a DateTime object
        DateTime gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);

        // Convert the Persian date to Gregorian date time
        DateTime gregorianDateTime = Convert.ToDateTime(gregorianDate.ToString(format));
        return gregorianDateTime;

    }
    public static DateTime ToGregorianDate(this string persianDate)
    {
        string[] parts = persianDate.Split(new char[] { '/', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int persianYear = int.Parse(parts[0]);
        int persianMonth = int.Parse(parts[1]);
        int persianDay = int.Parse(parts[2]);
        int hour = int.Parse(parts[3].Split(':')[0]);
        int minute = int.Parse(parts[3].Split(':')[1]);
        PersianCalendar persianCalendar = new PersianCalendar();
        DateTime dateTime = persianCalendar.ToDateTime(persianYear, persianMonth, persianDay, hour, minute, 0, 0);
        GregorianCalendar gregorianCalendar = new GregorianCalendar();
        DateTime gregorianDateTime = gregorianCalendar.ToDateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
        return gregorianDateTime;
    }
    public static DateTime? ToNullableDateTime(this string PersianDate)
    {
        try
        {
            if (PersianDate.IsEmpty()) return null;
            PersianCalendar pc = new PersianCalendar();

            bool NightDay = PersianDate.Contains("ب.ظ") | PersianDate.Contains("PM");
            PersianDate = PersianDate.Replace("ق.ظ", "").Replace("ب.ظ", "").
                                      Replace("AM", "").Replace("PM", "").Trim();

            int[] Date = PersianDate.Split('/', ':', ' ').Select(s => Convert.ToInt32(s.Trim(' '))).ToArray();

            return pc.ToDateTime(Date.GetInt(0),// Year
                                 Date.GetInt(1),// Mounth
                                 Date.GetInt(2),// Day
                                 Date.GetInt(3) + (NightDay ? 12 : 0), // Hour
                                 Date.GetInt(4),// Minute
                                 Date.GetInt(5),// Seconde
                                 0);
        }
        catch (Exception)
        {
            return null;
        }
    }
    private static int GetInt(this int[] Date, int index)
    {
        return index < Date.Length ? Date[index] : 0;
    }
    //public static DateTime ShamsiToMiladi(this string date)
    //{
    //    PersianCalendar pc = new PersianCalendar();
    //    DateTime dt = new DateTime(Convert.ToInt32(date.Substring(0, 4)), Convert.ToInt32(date.Substring(5, 2)), Convert.ToInt32(date.Substring(8, 2)), 0, 0, 0, pc);
    //    return dt;
    //}
    /// <summary>
    /// محاسبه سن
    /// </summary>
    /// <param name="birthday">تاریخ تولد</param>
    /// <param name="comparisonBase">مبنای محاسبه مانند هم اکنون</param>
    /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
    /// <returns>سن</returns>
    public static int GetAge(this DateTimeOffset birthday, DateTime comparisonBase, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
    {
        return birthday.GetDateTimeOffsetPart(dateTimeOffsetPart).GetAge(comparisonBase);
    }

    /// <summary>
    /// محاسبه سن
    /// مبنای محاسبه هم اکنون
    /// </summary>
    /// <param name="birthday">تاریخ تولد</param>
    /// <returns>سن</returns>
    public static int GetAge(this DateTimeOffset birthday)
    {
        var birthdayDateTime = birthday.UtcDateTime;
        var now = DateTime.UtcNow;
        return birthdayDateTime.GetAge(now);
    }

    /// <summary>
    /// محاسبه سن
    /// </summary>
    /// <param name="birthday">تاریخ تولد</param>
    /// <param name="comparisonBase">مبنای محاسبه مانند هم اکنون</param>
    /// <returns>سن</returns>
    public static int GetAge(this DateTime birthday, DateTime comparisonBase)
    {
        var now = comparisonBase;
        var age = now.Year - birthday.Year;
        if (now < birthday.AddYears(age)) age--;

        return age;
    }

    /// <summary>
    /// محاسبه سن
    /// مبنای محاسبه هم اکنون
    /// </summary>
    /// <param name="birthday">تاریخ تولد</param>
    /// <returns>سن</returns>
    public static int GetAge(this DateTime birthday)
    {
        var now = birthday.Kind.GetNow();
        return birthday.GetAge(now);
    }

    /// <summary>
    /// دریافت جزء زمانی ویژه‌ی این وهله
    /// </summary>
    public static DateTime GetDateTimeOffsetPart(
        this DateTimeOffset dateTimeOffset,
        DateTimeOffsetPart dataDateTimeOffsetPart)
    {
        switch (dataDateTimeOffsetPart)
        {
            case DateTimeOffsetPart.DateTime:
                return dateTimeOffset.DateTime;

            case DateTimeOffsetPart.LocalDateTime:
                return dateTimeOffset.LocalDateTime;

            case DateTimeOffsetPart.UtcDateTime:
                return dateTimeOffset.UtcDateTime;

            case DateTimeOffsetPart.IranLocalDateTime:
                return dateTimeOffset.ToIranTimeZoneDateTimeOffset().DateTime;

            default:
                throw new ArgumentOutOfRangeException(nameof(dataDateTimeOffsetPart), dataDateTimeOffsetPart, null);
        }
    }

    /// <summary>
    /// بازگشت زمان جاری با توجه به نوع زمان
    /// </summary>
    /// <param name="dataDateTimeKind">نوع زمان ورودی</param>
    /// <returns>هم اکنون</returns>
    public static DateTime GetNow(this DateTimeKind dataDateTimeKind)
    {
        switch (dataDateTimeKind)
        {
            case DateTimeKind.Utc:
                return DateTime.UtcNow;
            default:
                return DateTime.Now;
        }
    }

    /// <summary>
    /// تبدیل منطقه زمانی این وهله به منطقه زمانی ایران
    /// </summary>
    public static DateTimeOffset ToIranTimeZoneDateTimeOffset(this DateTimeOffset dateTimeOffset)
    {
        return TimeZoneInfo.ConvertTime(dateTimeOffset, IranStandardTime);
    }

    /// <summary>
    /// تبدیل منطقه زمانی این وهله به منطقه زمانی ایران
    /// </summary>
    public static DateTime ToIranTimeZoneDateTime(this DateTime dateTime)
    {
        return dateTime;
        //return TimeZoneInfo.ConvertTime(dateTime, IranStandardTime);
    }

    /// <summary>
    /// Converts a given <see cref="DateTime"/> to milliseconds from Epoch.
    /// </summary>
    /// <param name="dateTime">A given <see cref="DateTime"/></param>
    /// <returns>Milliseconds since Epoch</returns>
    public static long ToEpochMilliseconds(this DateTime dateTime)
    {
        return (long)dateTime.ToUniversalTime().Subtract(Epoch).TotalMilliseconds;
    }

    /// <summary>
    /// Converts a given <see cref="DateTime"/> to seconds from Epoch.
    /// </summary>
    /// <param name="dateTime">A given <see cref="DateTime"/></param>
    /// <returns>The Unix time stamp</returns>
    public static long ToEpochSeconds(this DateTime dateTime)
    {
        return dateTime.ToEpochMilliseconds() / 1000;
    }

    /// <summary>
    /// Checks the given date is between the two provided dates
    /// </summary>
    public static bool IsBetween(this DateTime date, DateTime startDate, DateTime endDate, bool compareTime = false)
    {
        return compareTime ? date >= startDate && date <= endDate : date.Date >= startDate.Date && date.Date <= endDate.Date;
    }

    /// <summary>
    /// Returns whether the given date is the last day of the month
    /// </summary>
    public static bool IsLastDayOfTheMonth(this DateTime dateTime)
    {
        return dateTime == new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1);
    }

    /// <summary>
    /// Returns whether the given date falls in a weekend
    /// </summary>
    public static bool IsWeekend(this DateTime value)
    {
        return value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday;
    }

    /// <summary>
    /// Determines if a given year is a LeapYear or not.
    /// </summary>
    public static bool IsLeapYear(this DateTime value)
    {
        return DateTime.DaysInMonth(value.Year, 2) == 29;
    }

    /// <summary>
    /// Converts a DateTime to a DateTimeOffset
    /// </summary>
    /// <param name="dt">Source DateTime.</param>
    /// <param name="offset">Offset</param>
    public static DateTimeOffset ToDateTimeOffset(this DateTime dt, TimeSpan offset)
    {
        if (dt == DateTime.MinValue)
            return DateTimeOffset.MinValue;

        return new DateTimeOffset(dt.Ticks, offset);
    }

    /// <summary>
    /// Converts a DateTime to a DateTimeOffset
    /// </summary>
    /// <param name="dt">Source DateTime.</param>
    /// <param name="offsetInHours">Offset</param>
    public static DateTimeOffset ToDateTimeOffset(this DateTime dt, double offsetInHours = 0)
        => dt.ToDateTimeOffset(offsetInHours == 0 ? TimeSpan.Zero : TimeSpan.FromHours(offsetInHours));

    //MonthToDayCount(
}
