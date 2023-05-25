using System.Collections.Generic;
using System.Linq;

namespace KrzaqTools.IEnumerableExtension
{
    public static class IEnumerableExtension
    {
        public static bool HasAny<T>(this IEnumerable<T> first, IEnumerable<T> second) => first.Intersect(second).Any();
        public static bool HasAll<T>(this IEnumerable<T> first, IEnumerable<T> second) => first.Intersect(second).Count() == second.Count();
    }
}
