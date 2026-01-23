using Krzaq.Collections.IReadOnlyTable;
using Krzaq.Extensions.IEnumerable;
using System.Collections.Generic;

namespace Krzaq.Collections.ReadOnlyTable
{
    public class ReadOnlyTable<T> : IReadOnlyTable<T>
    {
        private readonly T[,] table;

        public T this[int row, int column] => table[row, column];
        public int Columns => table.GetLength(1);
        public int Rows => table.GetLength(0);
        public int Count => table.Length;

        public ReadOnlyTable(T[,] table)
        {
            this.table = table;
        }

        public IEnumerator<T> GetEnumerator() => table.AsEnumerable().GetEnumerator();
    }
}
