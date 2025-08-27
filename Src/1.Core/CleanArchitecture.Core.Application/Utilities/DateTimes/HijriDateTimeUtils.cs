using System.Globalization;

namespace CleanArchitecture.Core.Application.Utilities.DateTimes;

public static class HijriDateTimeUtils
{
    public static string ToHijriDateString(this DateTime EnDate, int hijriAdjustment, string Format = "{0}/{1}/{2} {3}:{4}:{5}")
    {
        try
        {
            HijriCalendar hc = new HijriCalendar();

            hc.HijriAdjustment = hijriAdjustment;

            string[] monthNames = new string[12];

            monthNames[0] = "محرم";
            monthNames[1] = "صفر";
            monthNames[2] = "ربیع‌الاول";
            monthNames[3] = "ربیع‌الثانی";
            monthNames[4] = "جمادی‌الاول";
            monthNames[5] = "جمادی‌الثانی";
            monthNames[6] = "رجب";
            monthNames[7] = "شعبان";
            monthNames[8] = "رمضان";
            monthNames[9] = "شوال";
            monthNames[10] = "ذیقعده";
            monthNames[11] = "ذیحجه";

            string monthName = monthNames[hc.GetMonth(EnDate) - 1];

            return string.Format(Format,
                                 hc.GetYear(EnDate).ToString("0000"),
                                 hc.GetMonth(EnDate).ToString("00"),
                                 (hc.GetDayOfMonth(EnDate) - 1).ToString("00"),
                                 hc.GetHour(EnDate).ToString("00"),
                                 hc.GetMinute(EnDate).ToString("00"),
                                 hc.GetSecond(EnDate).ToString("00"),
                                 hc.GetMilliseconds(EnDate).ToString("0000"),
                                 monthName
                                );
        }
        catch
        {
            return "";
        }
    }
}
