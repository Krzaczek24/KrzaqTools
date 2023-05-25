using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Extensions.ReadOnlyDictionary
{
    public static class ReadOnlyDictionaryExtension
    {
        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, List<TValue>> input)
            where TKey : notnull
        {
            var readOnly = new Dictionary<TKey, IReadOnlyCollection<TValue>>();

            foreach (var entry in input ?? throw new ArgumentNullException())
            {
                readOnly.Add(entry.Key, new ReadOnlyCollection<TValue>(entry.Value.AsReadOnly()));
            }

            return new ReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>>(readOnly);
        }

        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, IList<TValue>> input) where TKey : notnull => AsReadOnly(input.ToDictionary(x => x.Key, x => x.Value.ToList()));
        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, IEnumerable<TValue>> input) where TKey : notnull => AsReadOnly(input.ToDictionary(x => x.Key, x => x.Value.ToList()));
        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, ICollection<TValue>> input) where TKey : notnull => AsReadOnly(input.ToDictionary(x => x.Key, x => x.Value.ToList()));
        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, HashSet<TValue>> input) where TKey : notnull => AsReadOnly(input.ToDictionary(x => x.Key, x => x.Value.ToList()));
        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, Collection<TValue>> input) where TKey : notnull => AsReadOnly(input.ToDictionary(x => x.Key, x => x.Value.ToList()));
    }
}
