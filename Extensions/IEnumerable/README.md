# Krzaq.Extensions.IEnumerable
Extension adds few method to `IEnumerable` collections.

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
