namespace CleanArchitecture.Core.Application.Utilities.Extensions;

using Newtonsoft.Json.Linq;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

public static class MathExtension
{
    /// <summary>
    /// Rounds a numeric value to the specified number of decimal places.
    /// </summary>
    public static double Round<T>(this T value, int roundCount) where T : struct, IConvertible
    {
        double doubleValue = Convert.ToDouble(value);
        return Math.Round(doubleValue, roundCount);
    }

    /// <summary>
    /// Clamps a value between a minimum and maximum range.
    /// </summary>
    public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
    {
        if (value.CompareTo(min) < 0) return min;
        if (value.CompareTo(max) > 0) return max;
        return value;
    }

    /// <summary>
    /// Calculates the percentage of a value.
    /// </summary>
    public static double Percentage<T>(this T value, T total) where T : struct, IConvertible
    {
        double doubleValue = Convert.ToDouble(value);
        double doubleTotal = Convert.ToDouble(total);

        if (doubleTotal == 0)
            throw new DivideByZeroException("Total value cannot be zero.");

        return doubleValue / doubleTotal * 100;
    }

    /// <summary>
    /// Returns the absolute value of a number.
    /// </summary>
    public static T Absolute<T>(this T value) where T : struct, IConvertible
    {
        double doubleValue = Convert.ToDouble(value);
        double absValue = Math.Abs(doubleValue);
        return (T)Convert.ChangeType(absValue, typeof(T));
    }

    /// <summary>
    /// Calculates the square root of a number.
    /// </summary>
    public static double Sqrt<T>(this T value) where T : struct, IConvertible
    {
        double doubleValue = Convert.ToDouble(value);

        if (doubleValue < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Cannot calculate square root of a negative number.");

        return Math.Sqrt(doubleValue);
    }

    /// <summary>
    /// Raises a number to the specified power.
    /// </summary>
    public static double Power<T>(this T baseValue, T exponent) where T : struct, IConvertible
    {
        double baseDouble = Convert.ToDouble(baseValue);
        double exponentDouble = Convert.ToDouble(exponent);
        return Math.Pow(baseDouble, exponentDouble);
    }

    /// <summary>
    /// Checks if a number is within a specified range (inclusive).
    /// </summary>
    public static bool IsInRange<T>(this T value, T min, T max) where T : IComparable<T>
    {
        return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }

    /// <summary>
    /// Calculates the factorial of a non-negative integer.
    /// </summary>
    public static long Factorial(this int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be non-negative.");

        long result = 1;
        for (int i = 1; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
}


//      Features in MathExtension
//  Round :  Rounds a numeric value to the specified decimal places.
//double roundedValue = 23.3543.Round(2);          // Output: 23.35

//  Clamp :  Limits a value between a specified minimum and maximum range.
//int clampedValue = 15.Clamp(10, 20);             // Output: 15

//  Percentage:  Calculates the percentage of a value relative to a total.
//double percentage = 50.Percentage(200);          // Output: 25.0

//  Absolute  :  Returns the absolute value of a number.
//int absoluteValue = (-5).Absolute();             // Output: 5

//  Sqrt  :  Calculates the square root of a number.
//double squareRoot = 16.Sqrt();                   // Output: 4.0

//  Power :  Raises a number to a specified power.
//double power = 2.Power(3);                       // Output: 8.0

//  IsInRange :  Checks if a value is within a specified range.
//bool inRange = 15.IsInRange(10, 20);             // Output: True

//  Factorial :  Calculates the factorial of an integer.
//long factorial = 5.Factorial();                  // Output: 120

