using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KrzaqTools.Extensions
{
    public static class IEnumerableExtension
    {
        public static bool HasAny<T>(this IEnumerable<T> first, IEnumerable<T> second) => first.Intersect(second).Any();
        public static bool HasAll<T>(this IEnumerable<T> first, IEnumerable<T> second) => first.Intersect(second).Count() == second.Count();

        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<T, TKey, TValue>(this IEnumerable<T> first, Func<T, TKey> keySelector, Func<T, TValue> valueSelector)
        {
            return new ReadOnlyDictionary<TKey, TValue>(first.ToDictionary(keySelector, valueSelector));
        }
    }
}
