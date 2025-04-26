using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Core.Application.Library.Utilities.Extensions;

public static class StringExtensions
{
    public const char ArabicYeChar = (char)1610;
    public const char PersianYeChar = (char)1740;

    public const char ArabicKeChar = (char)1603;
    public const char PersianKeChar = (char)1705;
    public static string ApplyCorrectYeKe(this object data) => data == null ? null : data.ToString().ApplyCorrectYeKe();
    public static string ApplyCorrectYeKe(this string data) => string.IsNullOrWhiteSpace(data) ? string.Empty : data.Replace(ArabicYeChar, PersianYeChar).Replace(ArabicKeChar, PersianKeChar).Trim();
    public static bool IsValidNationalCode(this string nationalCode) => !(nationalCode.Contains("\"") || nationalCode.Contains("@") || nationalCode.Contains("\'") || nationalCode.IsEmpty());

    public static long ToSafeLong(this string input, long replacement = long.MinValue) => long.TryParse(input, out long result) ? result : replacement;
    public static long? ToSafeNullableLong(this string input) => long.TryParse(input, out long result) ? result : null;


    public static int ToSafeInt(this string input, int replacement = int.MinValue) => int.TryParse(input, out int result) ? result : replacement;
    public static int? ToSafeNullableInt(this string input) => int.TryParse(input, out int result) ? result : null;


    public static string ToStringOrEmpty(this string? input) => input ?? string.Empty;

    public static string ToUnderscoreCase(this string input) => string.Concat(input.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
    public static byte[] ToByteArray(this string input) => Encoding.UTF8.GetBytes(input);
    public static string FromByteArray(this byte[] input) => Encoding.UTF8.GetString(input);
    public static bool IsEmpty(this string value) => string.IsNullOrWhiteSpace(value);

    public static bool IsNotEmpty(this string value)
    {
        return !value.IsEmpty();
    }


    /// <summary>
    /// Checks if the string can be parsed to a numeric type (int, double, decimal, etc.)
    /// </summary>
    /// <param name="input">The string to check</param>
    /// <returns>True if the string can be parsed to a number, otherwise false</returns>
    public static bool IsParsableToNumeric(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        return double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
    }

    public static string ComputeHash(this string inputString)
    {
        StringBuilder sb = new StringBuilder();

        foreach (byte b in GetHash(inputString))
            sb.Append(b.ToString("X2"));

        return sb.ToString();
    }

    public static byte[] GetHash(string inputString)
    {
        HashAlgorithm algorithm = SHA256.Create();

        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    public static string ToCamelCase(this string str)
    {
        if (!string.IsNullOrEmpty(str) && str.Length > 1)
        {
            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        return str;
    }

    public static int ToInt(this string str)
    {
        if (str.IsParsableToNumeric())
            return int.Parse(str);
        return 0;
    }

    public static decimal ToDecimal(this string code)
    {
        decimal.TryParse(code, out decimal res);
        return res;
    }

    public static decimal CastToDecimal(this string code)
    {
        var x = code.Replace("\\", "");
        decimal.TryParse(x, out decimal value);
        return value;
    }

    public static int? ToNInt(this string str)
    {
        if (int.TryParse(str, out int result))
            return result;
        else
            return null;
    }

    public static long ToLong(this string str)
    {
        if (str.IsParsableToNumeric())
            return long.Parse(str);
        return 0;
    }

    public static long? ToNLong(this string str)
    {
        if (long.TryParse(str, out long result))
            return result;
        else
            return null;
    }

    public static decimal? ToNDecimal(this string str)
    {
        if (decimal.TryParse(str, out decimal result))
            return result;
        else
            return null;
    }

    public static string ToEnglishNumber(this string value)
    {
        return value?
                .Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("v", "7")
                .Replace("۸", "8")
                .Replace("۹", "9");
    }

    public static string ToFarsiNumbers(this string value)
    {
        return value?
                .Replace('0', '۰')
                .Replace('1', '۱')
                .Replace('2', '۲')
                .Replace('3', '۳')
                .Replace('4', '۴')
                .Replace('5', '۵')
                .Replace('6', '۶')
                .Replace('7', '۷')
                .Replace('8', '۸')
                .Replace('9', '۹');
    }

    public static bool IsDigitsOnly(this string text)
    {
        if (text.IsEmpty())
            return false;

        foreach (var item in text)
        {
            if (item < '0' || item > '9')
                return false;
        }

        return true;
    }
    public static string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    /// <summary>
    /// If string is number return true
    /// </summary>
    /// <param name="s"></param>
    /// <returns>bool</returns>
    public static bool IsItNumber(this string s)
    {
        var isnumber = new Regex("[^0-9]");
        return !isnumber.IsMatch(s);
    }

    /// <summary>
    /// Returns the last few characters of the string with a length
    /// specified by the given parameter. If the string's length is less than the 
    /// given length the complete string is returned. If length is zero or 
    /// less an empty string is returned
    /// </summary>
    /// <param name="s">the string to process</param>
    /// <param name="length">Number of characters to return</param>
    /// <returns></returns>
    public static string Right(this string s, int length)
    {
        length = Math.Max(length, 0);
        return s.Length > length ? s.Substring(s.Length - length, length) : s;
    }

    public static string RightWithObfuscateRemained(this string s, int lengthOfNormalCharactersAtRight, char obfuscateCharacter = '*')
    {
        if (s.IsEmpty())
            return s;

        lengthOfNormalCharactersAtRight = Math.Max(lengthOfNormalCharactersAtRight, 0);
        if (s.Length > lengthOfNormalCharactersAtRight)
        {
            return s.Substring(s.Length - lengthOfNormalCharactersAtRight, lengthOfNormalCharactersAtRight).PadLeft(s.Length, obfuscateCharacter);
        }
        else
        {
            return s;
        }
    }

    /// <summary>
    /// Returns the first few characters of the string with a length
    /// specified by the given parameter. If the string's length is less than the 
    /// given length the complete string is returned. If length is zero or 
    /// less an empty string is returned
    /// </summary>
    /// <param name="s">the string to process</param>
    /// <param name="length">Number of characters to return</param>
    /// <returns></returns>
    public static string Left(this string s, int length)
    {
        length = Math.Max(length, 0);
        return s.Length > length ? s.Substring(0, length) : s;
    }

    public static string LeftWithObfuscateRemained(this string s, int lengthOfNormalCharactersAtLeft, char obfuscateCharacter = '*')
    {
        if (s.IsEmpty())
            return s;

        lengthOfNormalCharactersAtLeft = Math.Max(lengthOfNormalCharactersAtLeft, 0);
        if (s.Length > lengthOfNormalCharactersAtLeft)
        {
            return s.Substring(0, lengthOfNormalCharactersAtLeft).PadRight(s.Length, obfuscateCharacter);
        }
        else
        {
            return s;
        }
    }

    /// <summary>
    /// returns default value if string is null or empty or white spaces string
    /// </summary>
    /// <param name="str"></param>
    /// <param name="defaultValue"></param>
    /// <param name="considerWhiteSpaceIsEmpty"></param>
    /// <returns></returns>
    public static string DefaultIfEmpty(this string str, string defaultValue, bool considerWhiteSpaceIsEmpty = false)
        => (considerWhiteSpaceIsEmpty || string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str))
            ? defaultValue
            : str;



    public static string IsEmptyReplace(this string input, string replaceInput)
    {
        return input.IsEmpty() ? replaceInput : input;
    }



    /// <summary>
    /// Reverse a string
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string Reverse(this string s)
    {
        char[] c = s.ToCharArray();
        Array.Reverse(c);
        return new string(c);
    }

    /// <summary>
    /// Repeat the given char the specified number of times.
    /// </summary>
    /// <param name="input">The char to repeat.</param>
    /// <param name="count">The number of times to repeat the string.</param>
    /// <returns>The repeated char string.</returns>
    public static string Repeat(this char input, int count)
    {
        return new string(input, count);
    }

    /// <summary>
    /// Capitalize each word
    /// Exp: 
    ///     david jons => David Jons
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string ToCapitalWord(this string input)
    {
        return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
    }

    public static string Summery(this string txt, int Maxlen)
    {
        string[] words = txt.Split(' ');
        string ret = "";

        for (int i = 1; i <= words.Length; i++)
        {
            ret = string.Join(" ", words, 0, i);
            if (ret.Length > Maxlen) break;
        }
        if (txt.Length > ret.Length) ret += "...";
        return ret;
    }

    public static int? ToInt32(this string txt)
    {
        int value;
        if (int.TryParse(txt, out value)) return value;
        else return null;
    }

    public static float? ToFloat(this string txt)
    {
        float value;
        if (float.TryParse(txt, out value)) return value;
        else return null;
    }

    public static double? ToDouble(this string txt)
    {
        double value;
        if (double.TryParse(txt, out value)) return value;
        else return null;
    }

    public static string ReplaceArabicChars(this string input)
    {
        return input.Replace("ي", "ی")
            .Replace("ك", "ک");
    }

    public static string Fmt(this string input, params object[] args)
    {
        return string.Format(input, args);
    }


    public static string BuildString(this string Message, Dictionary<string, string> obj, string StartDelemiter = "[", string EndDelemiter = "]")
    {
        try
        {
            string MessagePad = string.Format(" {0} ", Message);
            int startindex = 0, lastindex = 0;
            string variable = "", ret = "", var;
            while (startindex != -1 && lastindex != -1)
            {
                startindex = MessagePad.IndexOf(StartDelemiter, startindex + (startindex == 0 ? 0 : 1));
                lastindex = MessagePad.IndexOf(EndDelemiter, startindex + (startindex == 0 ? 0 : 1));
                if (startindex != -1 && lastindex != -1)
                {
                    var = MessagePad.Substring(startindex, lastindex - startindex + 1);
                    if (var.Length > 2) variable = var.Substring(1, var.Length - 2);

                    ret = obj.ContainsKey(variable) ? obj[variable] ?? "" : var;
                    MessagePad = MessagePad.Replace(var, ret);
                }
            }

            if (obj.ContainsKey("referral"))
                MessagePad = MessagePad.Replace("!referral!", obj[variable]);

            return MessagePad.Trim();
        }
        catch
        {
            return "-1";
        }
    }

    public static string SubStringMax(this string str, int max)
    {
        return str.Length > max ? str.Substring(0, max) : str;
    }

    public static string RemoveComma(this string str)
    {
        return str.Replace(",", string.Empty);
    }
    public static string ReturnDash(this string str)
    {
        return string.IsNullOrWhiteSpace(str) ? "-" : str;
    }

    public static bool IsValidEmail(this string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsValidMobileNumber(this string mobileNumber)
    {
        try
        {
            const string pattern = @"^09[0|1|2|3|9][0-9]{8}$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(mobileNumber);
        }
        catch
        {
            return false;
        }
    }

    public static bool IsValidUserName(this string username)
    {
        try
        {
            if (username.IsEmpty())
            {
                return false;
            }

            if (username.Length < 2 || username.Length > 50)
            {
                return false;
            }

            const string pattern = @"^[a-zA-Z][a-zA-Z+\d-]+";   // ex: alavi-a, rasooli-rz, mahdavi34_74
            Regex reg = new Regex(pattern);
            return reg.IsMatch(username);
        }
        catch
        {
            return false;
        }
    }

    public static bool IsValidGamUserName(string gamUsername)
    {
        try
        {
            if (gamUsername.IsEmpty())
            {
                return false;
            }

            if (gamUsername.Length < 2 || gamUsername.Length > 50)
            {
                return false;
            }

            /* اتوماسیون گام، هم عدد خالی داره هم حروف.. */
            const string pattern = @"^[a-zA-Z0-9_-]+";   // ex: alavi-a, rasooli-rz, 44153, 43reza_31
            Regex reg = new Regex(pattern);
            return reg.IsMatch(gamUsername);
        }
        catch
        {
            return false;
        }
    }

    public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
    {
        return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
    }


    public static string ToNumeric(this int value)
    {
        return value.ToString("N0"); //"123,456"
    }

    public static string ToNumeric(this decimal value)
    {
        return value.ToString("N0");
    }

    public static string ToCurrency(this int value)
    {
        //fa-IR => current culture currency symbol => ریال
        //123456 => "123,123ریال"
        return value.ToString("C0");
    }

    public static string ToCurrency(this decimal value)
    {
        return value.ToString("C0");
    }

    public static string NullIfEmpty(this string str)
    {
        return str?.Length == 0 ? null : str;
    }


}
