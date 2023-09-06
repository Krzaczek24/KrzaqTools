# Krzaq.Extensions.IEnumerable
Extension allows to convert `Dictionary` to `ReadOnlyDictionary` especially for `Dictionary` with different types of `Collection`-s which are converted to `IReadOnlyCollection`.

## v1.1.0
Added:
* `IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<T, TKey, TValue>(this IEnumerable<T> first, Func<T, TKey> keySelector, Func<T, TValue> valueSelector)`

## v1.0.0
Supports:
* `bool HasAny<T>(this IEnumerable<T> first, IEnumerable<T> second)`
* `bool HasAll<T>(this IEnumerable<T> first, IEnumerable<T> second)`
