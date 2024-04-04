using KrzaqTools.Common.Enums;
using System.Numerics;

namespace KrzaqTools.Extensions
{
    public static class INumberExtension
    {
        public static bool IsBetween<T>(this T number, T min, T max, Inclusivity inclusivity = Inclusivity.Both) where T : INumber<T>
        {
            if (min > max)
                (min, max) = (max, min);
            return number.IsGreaterThan(min, inclusivity.HasFlag(Inclusivity.Left))
                && number.IsLesserThan(max, inclusivity.HasFlag(Inclusivity.Right));
        }

        private static bool IsLesserThan<T>(this T number, T value, bool inclusive)
            where T : INumber<T> => number < value || inclusive && number == value;

        private static bool IsGreaterThan<T>(this T number, T value, bool inclusive)
            where T : INumber<T> => number > value || inclusive && number == value;
    }
}
