# ReadOnlyDictionaryExtension
Extension allows to convert `Dictionary` to `ReadOnlyDictionary` especially for `Dictionary` with different types of `Collection`-s which are converted to `IReadOnlyCollection`.

## v1.0.0
Supports:
* `IDictionary<TKey, IList<TValue>>`
* `IDictionary<TKey, IEnumerable<TValue>>`
* `IDictionary<TKey, ICollection<TValue>>`
* `IDictionary<TKey, HashSet<TValue>>`
* `IDictionary<TKey, Collection<TValue>>`
* `IDictionary<TKey, List<TValue>>`
