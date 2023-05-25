# IEnumerableExtension
Extension allows to convert `Dictionary` to `ReadOnlyDictionary` especially for `Dictionary` with different types of `Collection`-s which are converted to `IReadOnlyCollection`.

## v1.0.0
Supports:
* `bool HasAny<T>(this IEnumerable<T> first, IEnumerable<T> second)`
* `bool HasAll<T>(this IEnumerable<T> first, IEnumerable<T> second)`
