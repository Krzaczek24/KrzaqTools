using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KrzaqTools.Extensions
{
    public static class IEnumerableExtension
    {
        public static bool IsIn<T>(this T source, params T[] collection) => collection.Contains(source);

        public static bool HasAny<T>(this IEnumerable<T> first, IEnumerable<T> second) => first.Intersect(second).Any();
        public static bool HasAll<T>(this IEnumerable<T> first, IEnumerable<T> second) => !second.Except(first).Any();

        public static void ForEach<T>(this IEnumerable<T> first, Action<T> action)
        {
            foreach (var item in first) action(item);            
        }

        public static bool IsNullOrEmpty(this IEnumerable first) => first == null || !first.GetEnumerator().MoveNext();

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> first) => first == null || !first.Any();

        public static bool IsNullOrEmpty<T>(this ICollection<T> first) => !(first?.Count > 0);

        public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> first) => first.Select((item, index) => (item, index));

        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<T, TKey, TValue>(this IEnumerable<T> first, Func<T, TKey> keySelector, Func<T, TValue> valueSelector)
        {
            return new ReadOnlyDictionary<TKey, TValue>(first.ToDictionary(keySelector, valueSelector));
        }

        public static IDictionary<TKey, IEnumerable<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> first)
        {
            return first.ToDictionary(x => x.Key, x => x.AsEnumerable());
        }

        public static IDictionary<TKey, IEnumerable<TValue>> ToGroupDictionary<TKey, TValue>(this IEnumerable<TValue> first, Func<TValue, TKey> keySelector)
        {
            return first.GroupBy(keySelector).ToDictionary();
        }

        public static bool TryGetSingle<T>(this IEnumerable<T> first, out T value)
        {
            value = default!;

            var enumerator = first.GetEnumerator();
            if (!enumerator.MoveNext())
                return false;

            var currentValue = enumerator.Current;

            if (enumerator.MoveNext())
                return false;

            value = currentValue;
            return true;
        }
    }
}
