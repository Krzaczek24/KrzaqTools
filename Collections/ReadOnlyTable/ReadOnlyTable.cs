using KrzaqTools.Extensions;
using System.Collections.Generic;

namespace KrzaqTools.Collections
{
    public class ReadOnlyTable<T> : IReadOnlyTable<T>
    {
        private readonly T[,] table;

        public T this[int column, int row] => table[column, row];
        public int Columns => table.GetLength(1);
        public int Rows => table.GetLength(0);
        public int Count => table.Length;
        public IEnumerator<T> GetEnumerator() => table.AsEnumerable().GetEnumerator();

        public ReadOnlyTable(T[,] table)
        {
            this.table = table;
        }
    }
}
