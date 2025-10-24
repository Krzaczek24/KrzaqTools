# Krzaq.Extensions.IEnumerable
Extension adds few method to `IEnumerable` collections.

## v1.10.0
Added:
* `IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> first, int startFrom)`

## v1.9.0
Added:
* `IEnumerable<T> AsEnumerable<T>(this T[,] first)`

## v1.8.0
Added:
* `bool IsNullOrEmpty(this IEnumerable first)`

## v1.7.0
Added:
* `bool IsNullOrEmpty<T>(this IEnumerable<T> first)`
* `bool IsNullOrEmpty<T>(this ICollection<T> first)`

## v1.6.0
Added:
* `bool IsIn<T>(this T source, params T[] collection)`

## v1.5.0
Added:
* `void ForEach<T>(this IEnumerable<T> first, Action<T> action)`

## v1.4.1
Fixed bug:
* where `bool HasAll<T>(this IEnumerable<T> first, IEnumerable<T> second)` was returning wrong results for collections containing duplicates

## v1.4.0
Added:
* `IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> first)`

## v1.3.0
Added:
* `IDictionary<TKey, IEnumerable<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> first)`
* `IDictionary<TKey, IEnumerable<TValue>> ToGroupDictionary<TKey, TValue>(this IEnumerable<TValue> first, Func<TValue, TKey> keySelector)`

## v1.2.1
Fixup for:
* `bool TryGetSingle<T>(this IEnumerable<T> first, out T value)`

## v1.2.0
Added:
* `bool TryGetSingle<T>(this IEnumerable<T> first, out T value)`

## v1.1.0
Added:
* `IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<T, TKey, TValue>(this IEnumerable<T> first, Func<T, TKey> keySelector, Func<T, TValue> valueSelector)`

## v1.0.0
Supports:
* `bool HasAny<T>(this IEnumerable<T> first, IEnumerable<T> second)`
* `bool HasAll<T>(this IEnumerable<T> first, IEnumerable<T> second)`
