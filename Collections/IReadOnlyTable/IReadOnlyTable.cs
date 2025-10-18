using System.Collections;
using System.Collections.Generic;

namespace KrzaqTools.Collections
{
    public interface IReadOnlyTable<T> : IReadOnlyCollection<T>
    {
        T this[int column, int row] { get; }
        int Columns { get; }
        int Rows { get; }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
