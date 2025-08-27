using CleanArchitecture.Core.Application.Utilities.Extensions;
using System.Globalization;

namespace CleanArchitecture.Core.Application.Utilities.DateTimes;
/// <summary>
/// Represents PersianDateTime utils.
/// </summary>
public static class PersianDateTimeUtils
{
    /// <summary>
    /// تعیین اعتبار تاریخ شمسی
    /// </summary>
    /// <param name="persianYear">سال شمسی</param>
    /// <param name="persianMonth">ماه شمسی</param>
    /// <param name="persianDay">روز شمسی</param>
    public static bool IsValidPersianDate(int persianYear, int persianMonth, int persianDay)
    {
        if (persianDay > 31 || persianDay <= 0)
        {
            return false;
        }

        if (persianMonth > 12 || persianMonth <= 0)
        {
            return false;
        }

        if (persianMonth <= 6 && persianDay > 31)
        {
            return false;
        }

        if (persianMonth >= 7 && persianDay > 30)
        {
            return false;
        }

        if (persianMonth == 12)
        {
            var persianCalendar = new PersianCalendar();
            var isLeapYear = persianCalendar.IsLeapYear(persianYear);

            if (isLeapYear && persianDay > 30)
            {
                return false;
            }

            if (!isLeapYear && persianDay > 29)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// تعیین اعتبار تاریخ و زمان رشته‌ای شمسی
    /// با قالب‌های پشتیبانی شده‌ی ۹۰/۸/۱۴ , 1395/11/3 17:30 , ۱۳۹۰/۸/۱۴ , ۹۰-۸-۱۴ , ۱۳۹۰-۸-۱۴
    /// </summary>
    /// <param name="persianDateTime">تاریخ و زمان شمسی</param>
    public static bool IsValidPersianDateTime(this string persianDateTime)
    {
        try
        {
            var dt = persianDateTime.ToGregorianDateTime();
            return dt.HasValue;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// تبدیل تاریخ و زمان رشته‌ای شمسی به میلادی
    /// با قالب‌های پشتیبانی شده‌ی ۹۰/۸/۱۴ , 1395/11/3 17:30 , ۱۳۹۰/۸/۱۴ , ۹۰-۸-۱۴ , ۱۳۹۰-۸-۱۴
    /// در اینجا اگر رشته‌ی مدنظر قابل تبدیل نباشد، مقدار نال را دریافت خواهید کرد
    /// </summary>
    /// <param name="persianDateTime">تاریخ و زمان شمسی</param>
    /// <returns>تاریخ و زمان میلادی</returns>
    public static DateTime? ToGregorianDateTime(this string persianDateTime)
    {
        if (string.IsNullOrWhiteSpace(persianDateTime))
        {
            return null;
        }

        persianDateTime = persianDateTime.Trim().ToEnglishNumbers();
        var splitedDateTime = persianDateTime.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var rawTime = splitedDateTime.FirstOrDefault(s => s.Contains(':'));
        var rawDate = splitedDateTime.FirstOrDefault(s => !s.Contains(':'));

        var splitedDate = rawDate?.Split('/', ',', '؍', '.', '-');
        if (splitedDate?.Length != 3)
        {
            return null;
        }

        var day = getDay(splitedDate[2]);
        if (!day.HasValue)
        {
            return null;
        }

        var month = getMonth(splitedDate[1]);
        if (!month.HasValue)
        {
            return null;
        }

        var year = getYear(splitedDate[0]);
        if (!year.HasValue)
        {
            return null;
        }

        if (!IsValidPersianDate(year.Value, month.Value, day.Value))
        {
            return null;
        }

        var hour = 0;
        var minute = 0;
        var second = 0;

        if (!string.IsNullOrWhiteSpace(rawTime))
        {
            var splitedTime = rawTime.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            hour = int.Parse(splitedTime[0]);
            minute = int.Parse(splitedTime[1]);
            if (splitedTime.Length > 2)
            {
                var lastPart = splitedTime[2].Trim();
                var formatInfo = PersianCulture.Instance.DateTimeFormat;
                if (lastPart.Equals(formatInfo.PMDesignator, StringComparison.OrdinalIgnoreCase))
                {
                    if (hour < 12)
                    {
                        hour += 12;
                    }
                }
                else
                {
                    int.TryParse(lastPart, out second);
                }
            }
        }

        var persianCalendar = new PersianCalendar();
        return persianCalendar.ToDateTime(year.Value, month.Value, day.Value, hour, minute, second, 0);
    }

    /// <summary>
    /// تبدیل تاریخ و زمان رشته‌ای شمسی به میلادی
    /// با قالب‌های پشتیبانی شده‌ی ۹۰/۸/۱۴ , 1395/11/3 17:30 , ۱۳۹۰/۸/۱۴ , ۹۰-۸-۱۴ , ۱۳۹۰-۸-۱۴
    /// در اینجا اگر رشته‌ی مدنظر قابل تبدیل نباشد، مقدار نال را دریافت خواهید کرد
    /// </summary>
    /// <param name="persianDateTime">تاریخ و زمان شمسی</param>
    /// <returns>تاریخ و زمان میلادی</returns>
    public static DateTimeOffset? ToGregorianDateTimeOffset(this string persianDateTime)
    {
        var dateTime = persianDateTime.ToGregorianDateTime();
        if (dateTime == null)
        {
            return null;
        }

        return new DateTimeOffset(dateTime.Value, DateTimeUtils.IranStandardTime.BaseUtcOffset);
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 21 دی 1395
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    public static string ToLongPersianDateString(this DateTime dt)
    {
        return dt.ToPersianDateTimeString(PersianCulture.Instance.DateTimeFormat.LongDatePattern);
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 21 دی 1395
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    public static string ToLongPersianDateString(this DateTime? dt)
    {
        return dt == null ? string.Empty : dt.Value.ToLongPersianDateString();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 21 دی 1395
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    /// <param name="dt">تاریخ و زمان</param>
    /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
    public static string ToLongPersianDateString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
    {
        return dt == null ? string.Empty : dt.Value.GetDateTimeOffsetPart(dateTimeOffsetPart).ToLongPersianDateString();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 21 دی 1395
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    /// <param name="dt">تاریخ و زمان</param>
    /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
    public static string ToLongPersianDateString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
    {
        return dt.GetDateTimeOffsetPart(dateTimeOffsetPart).ToLongPersianDateString();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    public static string ToLongPersianDateTimeString(this DateTime dt)
    {
        return dt.ToPersianDateTimeString(
            $"{PersianCulture.Instance.DateTimeFormat.LongDatePattern}، {PersianCulture.Instance.DateTimeFormat.LongTimePattern}");
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    public static string ToLongPersianDateTimeString(this DateTime? dt)
    {
        return dt == null ? string.Empty : dt.Value.ToLongPersianDateTimeString();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    /// <param name="dt">تاریخ و زمان</param>
    /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
    public static string ToLongPersianDateTimeString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
    {
        return dt == null ? string.Empty : dt.Value.GetDateTimeOffsetPart(dateTimeOffsetPart).ToLongPersianDateTimeString();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    /// <param name="dt">تاریخ و زمان</param>
    /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
    public static string ToLongPersianDateTimeString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
    {
        return dt.GetDateTimeOffsetPart(dateTimeOffsetPart).ToLongPersianDateTimeString();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    public static string ToPersianDateTimeString(this DateTime dateTime, string format)
    {
        if (dateTime.Year == 0001) return "";
        return dateTime.ToString(format, PersianCulture.Instance);
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌
    /// </summary>
    /// <param name="gregorianDate">تاریخ و زمان</param>
    /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
    public static PersianDay ToPersianYearMonthDay(this DateTimeOffset? gregorianDate, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
    {
        return gregorianDate == null ? throw new ArgumentNullException(nameof(gregorianDate)) : gregorianDate.Value.GetDateTimeOffsetPart(dateTimeOffsetPart).ToPersianYearMonthDay();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌
    /// </summary>
    public static PersianDay ToPersianYearMonthDay(this DateTime? gregorianDate)
    {
        return gregorianDate == null ? throw new ArgumentNullException(nameof(gregorianDate)) : gregorianDate.Value.ToPersianYearMonthDay();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌
    /// </summary>
    /// <param name="gregorianDate">تاریخ و زمان</param>
    /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
    public static PersianDay ToPersianYearMonthDay(this DateTimeOffset gregorianDate, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
    {
        return gregorianDate.GetDateTimeOffsetPart(dateTimeOffsetPart).ToPersianYearMonthDay();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌
    /// </summary>
    public static PersianDay ToPersianYearMonthDay(this DateTime gregorianDate)
    {
        var persianCalendar = new PersianCalendar();
        var persianYear = persianCalendar.GetYear(gregorianDate);
        var persianMonth = persianCalendar.GetMonth(gregorianDate);
        var persianDay = persianCalendar.GetDayOfMonth(gregorianDate);
        return new PersianDay { Year = persianYear, Month = persianMonth, Day = persianDay };
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 1395/10/21
    /// </summary>
    /// <param name="dt">تاریخ و زمان</param>
    /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
    /// <returns>تاریخ شمسی</returns>
    public static string ToShortPersianDateString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
    {
        return dt == null ? string.Empty : dt.Value.GetDateTimeOffsetPart(dateTimeOffsetPart).ToShortPersianDateString();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 1395/10/21
    /// </summary>
    /// <param name="dt">تاریخ و زمان</param>
    /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
    /// <returns>تاریخ شمسی</returns>
    public static string ToShortPersianDateString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
    {
        return dt.GetDateTimeOffsetPart(dateTimeOffsetPart).ToShortPersianDateString();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 1395/10/21
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    public static string ToShortPersianDateString(this DateTime dt)
    {
        return dt.ToPersianDateTimeString(PersianCulture.Instance.DateTimeFormat.ShortDatePattern);
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 1395/10/21
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    public static string ToShortPersianDateString(this DateTime? dt)
    {
        return dt == null ? string.Empty : dt.Value.ToShortPersianDateString();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 1395/10/21 10:20
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    public static string ToShortPersianDateTimeString(this DateTime dt)
    {
        return dt.ToPersianDateTimeString(
            $"{PersianCulture.Instance.DateTimeFormat.ShortDatePattern} {PersianCulture.Instance.DateTimeFormat.ShortTimePattern}");
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 1395/10/21 10:20
    /// </summary>
    /// <returns>تاریخ شمسی</returns>
    public static string ToShortPersianDateTimeString(this DateTime? dt)
    {
        return dt == null ? string.Empty : dt.Value.ToShortPersianDateTimeString();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 1395/10/21 10:20
    /// </summary>
    /// <param name="dt">تاریخ و زمان</param>
    /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
    /// <returns>تاریخ شمسی</returns>
    public static string ToShortPersianDateTimeString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
    {
        return dt == null ? string.Empty : dt.Value.GetDateTimeOffsetPart(dateTimeOffsetPart).ToShortPersianDateTimeString();
    }

    /// <summary>
    /// تبدیل تاریخ میلادی به شمسی
    /// با قالبی مانند 1395/10/21 10:20
    /// </summary>
    /// <param name="dt">تاریخ و زمان</param>
    /// <param name="dateTimeOffsetPart">کدام جزء این وهله مورد استفاده قرار گیرد؟</param>
    /// <returns>تاریخ شمسی</returns>
    public static string ToShortPersianDateTimeString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
    {
        return dt.GetDateTimeOffsetPart(dateTimeOffsetPart).ToShortPersianDateTimeString();
    }

    private static int? getDay(string part)
    {
        var day = part.toNumber();
        if (!day.Item1) return null;
        var pDay = day.Item2;
        if (pDay == 0 || pDay > 31) return null;
        return pDay;
    }

    private static int? getMonth(string part)
    {
        var month = part.toNumber();
        if (!month.Item1) return null;
        var pMonth = month.Item2;
        if (pMonth == 0 || pMonth > 12) return null;
        return pMonth;
    }

    private static int? getYear(string part)
    {
        var year = part.toNumber();
        if (!year.Item1) return null;
        var pYear = year.Item2;
        if (part.Length == 2) pYear += 1300;
        return pYear;
    }

    private static Tuple<bool, int> toNumber(this string data)
    {
        int number;
        bool result = int.TryParse(data, out number);
        return new Tuple<bool, int>(result, number);
    }

    /// <summary>
    /// رشته شامل تاریخ شمسی به صورت سال/ماه/روز را به روز/ماه/سال تبدیل می‌کند
    /// </summary>
    /// <param name="reverseDate">رشته تاریخ شمسی معکوس</param>
    /// <returns></returns>
    public static string CorrectReverseDate(string reverseDate)
    {
        reverseDate = reverseDate.Trim();
        var dateParts = reverseDate.Split('/', ',', '؍', '.', '-', '\\');
        if (dateParts.Length == 3 && dateParts[2].Length == 4)
        {
            return $"{dateParts[2]}/{dateParts[1]}/{dateParts[0]}";
        }
        else
            return reverseDate;
    }

    public enum PersianDaysOfWeek : int
    {
        None = 0,
        شنبه = 1 << 0,
        یکشنبه = 1 << 1,
        دوشنبه = 1 << 2,
        سهشنبه = 1 << 3,
        چهارشنبه = 1 << 4,
        پنجشنبه = 1 << 5,
        جمعه = 1 << 6,
    }

    public enum PersianMonthsOfyear : int
    {
        None = 0,
        فروردین = 1 << 0,
        اردیبهشت = 1 << 1,
        خرداد = 1 << 2,
        تیر = 1 << 3,
        مرداد = 1 << 4,
        شهریور = 1 << 5,
        مهر = 1 << 6,
        آبان = 1 << 7,
        آذر = 1 << 8,
        دی = 1 << 9,
        بهمن = 1 << 10,
        اسفند = 1 << 11,
    }

    public static PersianDaysOfWeek ToPersianDaysOfWeek(this DayOfWeek days)
    {
        switch (days)
        {
            case DayOfWeek.Friday:
                return PersianDaysOfWeek.جمعه;
            case DayOfWeek.Monday:
                return PersianDaysOfWeek.دوشنبه;
            case DayOfWeek.Saturday:
                return PersianDaysOfWeek.شنبه;
            case DayOfWeek.Sunday:
                return PersianDaysOfWeek.یکشنبه;
            case DayOfWeek.Thursday:
                return PersianDaysOfWeek.پنجشنبه;
            case DayOfWeek.Tuesday:
                return PersianDaysOfWeek.سهشنبه;
            case DayOfWeek.Wednesday:
                return PersianDaysOfWeek.چهارشنبه;
            default:
                return PersianDaysOfWeek.None;
        }
    }

    /// <summary>
    /// To the persian date.
    /// </summary>
    /// <param name="EnDate">The en date.</param>
    /// <param name="Format">The format.
    /// Full Format "{0}/{1}/{2} {3}:{4}:{5}.{6}"
    ///             "Year/Month/Day Hour:Minute:Second.Milliseconds"
    /// </param>
    /// <returns></returns>
    public static string ToPersianDateString(this DateTime? EnDate, string Format = "{0}/{1}/{2} {3}:{4}:{5}")
    {
        return EnDate.HasValue ? EnDate.Value.ToPersianDateString(Format) : null;
    }

    /// <summary>
    /// To the persian date.
    /// </summary>
    /// <param name="EnDate">The en date.</param>
    /// <param name="Format">The format.
    /// Full Format "{0}/{1}/{2} {3}:{4}:{5}.{6}"
    ///             "Year/Month/Day Hour:Minute:Second.Milliseconds"
    /// </param>
    /// <returns></returns>
    public static string ToPersianDateString(this DateTime EnDate, string Format = "{0}/{1}/{2} {3}:{4}:{5}")
    {
        try
        {
            PersianCalendar pc = new PersianCalendar();

            string[] monthNames = new string[12];

            monthNames[0] = "فروردین";
            monthNames[1] = "اردیبهشت";
            monthNames[2] = "خرداد";
            monthNames[3] = "تیر";
            monthNames[4] = "مرداد";
            monthNames[5] = "شهریور";
            monthNames[6] = "مهر";
            monthNames[7] = "آبان";
            monthNames[8] = "آذر";
            monthNames[9] = "دی";
            monthNames[10] = "بهمن";
            monthNames[11] = "اسفند";

            if (Format == "DateString")
            {
                var month = monthNames[pc.GetMonth(EnDate) - 1];
                var day = "";

                switch (pc.GetDayOfWeek(EnDate))
                {
                    case DayOfWeek.Sunday:
                        day = "یکشنبه";
                        break;
                    case DayOfWeek.Monday:
                        day = "دوشنبه";
                        break;
                    case DayOfWeek.Tuesday:
                        day = "سه شنبه";
                        break;
                    case DayOfWeek.Wednesday:
                        day = "چهارشنبه";
                        break;
                    case DayOfWeek.Thursday:
                        day = "پنجشنبه";
                        break;
                    case DayOfWeek.Friday:
                        day = "جمعه";
                        break;
                    case DayOfWeek.Saturday:
                        day = "شنبه";
                        break;
                    default:
                        break;
                }

                var result = $"{day} {pc.GetDayOfMonth(EnDate).ToString("00")} {month} {pc.GetYear(EnDate).ToString("0000")}";

                return result;
            }
            else
                return string.Format(Format,
                                     pc.GetYear(EnDate).ToString("0000"),
                                     pc.GetMonth(EnDate).ToString("00"),
                                     pc.GetDayOfMonth(EnDate).ToString("00"),
                                     pc.GetHour(EnDate).ToString("00"),
                                     pc.GetMinute(EnDate).ToString("00"),
                                     pc.GetSecond(EnDate).ToString("00"),
                                     pc.GetMilliseconds(EnDate).ToString("0000")
                                    );
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// Converts the en date.
    /// </summary>
    /// <param name="PersianDate">The persian date.</param>
    /// <returns></returns>
    public static DateTime ToDateTime(this string PersianDate)
    {
        var value = ToNullableDateTime(PersianDate);

        return value.HasValue ? value.Value : DateTime.MinValue;
    }

    /// <summary>
    /// Converts the en date.
    /// </summary>
    /// <param name="PersianDate">The persian date.</param>
    /// <returns></returns>
    internal static DateTime? ToNullableDateTime(this string PersianDate)
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

    public static DateTime ShamsiToMiladi(this string date)
    {
        PersianCalendar pc = new PersianCalendar();
        DateTime dt = new DateTime(Convert.ToInt32(date.Substring(0, 4)), Convert.ToInt32(date.Substring(5, 2)), Convert.ToInt32(date.Substring(8, 2)), 0, 0, 0, pc);
        return dt;
    }

    public static int GetCurrentPersianYear(this DateTime miladiDate)
    {
        return GetYearOfPersianDate(miladiDate.ToPersianDateString()).Value;
    }

    public static int? GetYearOfPersianDate(string persianDate)
    {
        if (persianDate.IsEmpty() || persianDate.Length != 10 && persianDate.Length != 19)
            return null;

        return int.Parse(persianDate.Substring(0, 4));
    }

    public static bool IsLeapYear(this string persianDate)
    {
        var persianYear = GetYearOfPersianDate(persianDate);
        var persianDateStart = $"{persianYear}/01/01";
        var miladiDate = persianDateStart.ShamsiToMiladi();

        return DateTime.IsLeapYear(miladiDate.Year);
    }

    public static bool IsLeapYear(int persianYear)
    {
        var persianDateStart = $"{persianYear}/01/01";
        return persianDateStart.IsLeapYear();
    }

    /// <summary>
    /// Gets the int.
    /// </summary>
    /// <param name="Date">The date.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    private static int GetInt(this int[] Date, int index)
    {
        return index < Date.Length ? Date[index] : 0;
    }

    public static string FixPersianChars(this string Value)
    {
        return Value.Replace("ﮎ", "ک")
                        .Replace("ﮏ", "ک")
                        .Replace("ﮐ", "ک")
                        .Replace("ﮑ", "ک")
                        .Replace("ك", "ک")
                        .Replace("ي", "ی")
                        .Replace(" ", " ")
                        .Replace("‌", " ")
                        .Replace("ھ", "ه");//.Replace("ئ", "ی");
    }

    public static string FixInvalidChars(this string Value)
    {
        return Value
            .Replace("<", "")
            .Replace(">", "")
            .Replace("&", "")
            .Replace(";", "")
            .Replace("\'", "");
    }

    public static string ToEnglishNumber(this string Value)
    {
        return Value
                .Replace('۱', '1')
                .Replace('۲', '2')
                .Replace('۳', '3')
                .Replace('۴', '4')
                .Replace('۵', '5')
                .Replace('۶', '6')
                .Replace('۷', '7')
                .Replace('۸', '8')
                .Replace('۹', '9')
                .Replace('۰', '0')

                //iphone numeric
                .Replace('١', '1')
                .Replace('٢', '2')
                .Replace('٣', '3')
                .Replace('٤', '4')
                .Replace('٥', '5')
                .Replace('٦', '6')
                .Replace('٧', '7')
                .Replace('٨', '8')
                .Replace('٩', '9')
                .Replace('٠', '0');
    }

    public static string ToPersianNumber(this string Value)
    {
        if (Value == null)
            return Value;

        return Value
                .FixPersianChars()

                .Replace('1', '۱')
                .Replace('2', '۲')
                .Replace('3', '۳')
                .Replace('4', '۴')
                .Replace('5', '۵')
                .Replace('6', '۶')
                .Replace('7', '۷')
                .Replace('8', '۸')
                .Replace('9', '۹')
                .Replace('0', '۰');
    }

    public static string CleanString(this string str)
    {
        return str.Trim().FixPersianChars().ToEnglishNumber().NullIfEmpty();
    }

    /// <summary>
    /// Validate IR National Code
    /// </summary>
    /// <param name="nationalcode">National Code</param>
    /// <returns></returns>
    public static bool IsValidNationalCode(this string nationalcode)
    {
        int last;
        return nationalcode.IsValidNationalCode(out last);
    }

    public static string FixNationalCode(this string nationalCode)
    {
        if (nationalCode.IsEmpty())
            return nationalCode;

        nationalCode = nationalCode.ToEnglishNumber();

        if (nationalCode.Length == 10)
            return nationalCode;

        nationalCode = nationalCode.PadLeft(10, '0');

        return nationalCode;
    }

    /// <summary>
    /// Validate IR National Code
    /// </summary>
    /// <param name="nationalcode">National Code</param>
    /// <param name="lastNumber">Last Number Of National Code</param>
    /// <returns></returns>
    public static bool IsValidNationalCode(this string nationalcode, out int lastNumber)
    {
        if (nationalcode.IsEmpty())
        {
            lastNumber = 0;
            return false;
        }

        lastNumber = -1;
        if (!nationalcode.IsItNumber()) return false;
        var invalid = new[]
                                    {
                                        "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555",
                                        "6666666666", "7777777777", "8888888888", "9999999999"
                                    };
        if (invalid.Contains(nationalcode)) return false;
        var array = nationalcode.ToCharArray();
        if (array.Length != 10) return false;
        var j = 10;
        var sum = 0;
        for (var i = 0; i < array.Length - 1; i++)
        {
            sum += int.Parse(array[i].ToString(CultureInfo.InvariantCulture)) * j;
            j--;
        }

        var diff = sum % 11;

        if (diff < 2)
        {
            lastNumber = diff;
            return diff == int.Parse(array[9].ToString(CultureInfo.InvariantCulture));
        }
        var temp = Math.Abs(diff - 11);
        lastNumber = temp;
        return temp == int.Parse(array[9].ToString(CultureInfo.InvariantCulture));
    }

}
