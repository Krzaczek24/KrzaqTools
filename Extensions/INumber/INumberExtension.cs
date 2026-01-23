using Krzaq.Common.Enums;
using System.Numerics;

namespace Krzaq.Extensions.INumber
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

        public static T Scale<T>(this T value, T minSourceValue, T maxSourceValue, T minTargetValue, T maxTargetValue) where T : INumber<T>
        {
            return minTargetValue + (value - minSourceValue) / (maxSourceValue - minSourceValue) * (maxTargetValue - minTargetValue);
        }

        public static TOut ScaleAndConvert<TIn, TOut>(this TIn value, TIn minSourceValue, TIn maxSourceValue, TOut minTargetValue, TOut maxTargetValue) where TIn : INumber<TIn> where TOut : INumber<TOut>
        {
            return TOut.CreateTruncating((value - minSourceValue) / (maxSourceValue - minSourceValue)) * (maxTargetValue - minTargetValue) + minTargetValue;
        }

        public static T CutOff<T>(this T value, T min, T max) where T : INumber<T>
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static T ScaleAndCutOff<T>(this T value, T minSourceValue, T maxSourceValue, T minTargetValue, T maxTargetValue) where T : INumber<T>
        {
            return value.Scale(minSourceValue, maxSourceValue, minTargetValue, maxTargetValue).CutOff(minTargetValue, maxTargetValue);
        }

        public static T Threshold<T>(this T value, T threshold) where T : INumber<T>
        {
            return T.Abs(value) >= threshold ? value : T.Zero;
        }

        private static bool IsLesserThan<T>(this T number, T value, bool inclusive)
            where T : INumber<T> => number < value || inclusive && number == value;

        private static bool IsGreaterThan<T>(this T number, T value, bool inclusive)
            where T : INumber<T> => number > value || inclusive && number == value;
    }
}
