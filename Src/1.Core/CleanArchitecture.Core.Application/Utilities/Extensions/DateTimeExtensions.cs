using System.Globalization;

namespace CleanArchitecture.Core.Application.Utilities.Extensions;

public static class DateTimeExtensions
{
    public static long ToUnixTimeMillisecond(this DateTime dateTime, TimeZoneInfo timeZoneInfo)
        => TimeZoneInfo.ConvertTime(new DateTimeOffset(dateTime), timeZoneInfo).ToUnixTimeMilliseconds();

    public static long? ToUnixTimeMillisecond(this DateTime? dateTime, TimeZoneInfo timeZoneInfo)
        => dateTime is not null ? TimeZoneInfo.ConvertTime(new DateTimeOffset(dateTime.Value), timeZoneInfo).ToUnixTimeMilliseconds() : null;

    public static DateTime ToDateTime(this long unixTimeMilliseconds, TimeZoneInfo timeZoneInfo)
        => TimeZoneInfo.ConvertTime(DateTimeOffset.FromUnixTimeMilliseconds(unixTimeMilliseconds), timeZoneInfo).DateTime;

    public static DateTime? ToDateTime(this long? unixTimeMilliseconds, TimeZoneInfo timeZoneInfo)
        => unixTimeMilliseconds is not null ? TimeZoneInfo.ConvertTime(DateTimeOffset.FromUnixTimeMilliseconds(unixTimeMilliseconds.Value), timeZoneInfo).DateTime : null;

    public static long ToLocalUnixTimeMillisecond(this DateTime dateTime) => dateTime.ToUnixTimeMillisecond(TimeZoneInfo.Local);

    public static long? ToLocalUnixTimeMillisecond(this DateTime? dateTime) => dateTime.ToUnixTimeMillisecond(TimeZoneInfo.Local);

    public static DateTime ToLocalDateTime(this long unixTimeMilliseconds) => unixTimeMilliseconds.ToDateTime(TimeZoneInfo.Local);

    public static DateTime? ToLocalDateTime(this long? unixTimeMilliseconds) => unixTimeMilliseconds.ToDateTime(TimeZoneInfo.Local);

    public static long ToUtcUnixTimeMillisecond(this DateTime dateTime) => dateTime.ToUnixTimeMillisecond(TimeZoneInfo.Utc);

    public static long? ToUtcUnixTimeMillisecond(this DateTime? dateTime) => dateTime.ToUnixTimeMillisecond(TimeZoneInfo.Utc);

    public static DateTime ToUtcDateTime(this long unixTimeMilliseconds) => unixTimeMilliseconds.ToDateTime(TimeZoneInfo.Utc);

    public static DateTime? ToUtcDateTime(this long? unixTimeMilliseconds) => unixTimeMilliseconds.ToDateTime(TimeZoneInfo.Utc);

    public static DateTime StartPersianDateFromGregorianDate(this DateTime dateTime)
    {
        PersianCalendar PersianCalendar = new PersianCalendar();
        return PersianCalendar.ToDateTime(PersianCalendar.GetYear(dateTime), 1, 1, 0, 0, 0, 0);
    }
    public static DateTime EndPersianDateFromGregorianDate(this DateTime dateTime)
    {
        PersianCalendar PersianCalendar = new PersianCalendar();
        int lastMonth = 12;
        return PersianCalendar.ToDateTime(PersianCalendar.GetYear(dateTime), lastMonth, PersianCalendar.GetDaysInMonth(PersianCalendar.GetYear(dateTime), lastMonth), 0, 0, 0, 0);
    }

    public static DateTime ConvertToDateTime(this string value) => Convert.ToDateTime(value);//?? DateTime.Now;
}