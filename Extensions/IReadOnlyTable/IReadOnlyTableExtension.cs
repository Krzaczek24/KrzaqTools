using Krzaq.Collections.IReadOnlyTable;
using System.Collections.Generic;

namespace Krzaq.Extensions.IReadOnlyTable
{
    public static class IReadOnlyTableExtension
    {
        public static IEnumerable<T> GetColumn<T>(this IReadOnlyTable<T> table, int index)
        {
            for (int i = 0; i < table.Rows; i++)
                yield return table[i, index];
        }

        public static IEnumerable<T> GetRow<T>(this IReadOnlyTable<T> table, int index)
        {
            for (int i = 0; i < table.Columns; i++)
                yield return table[index, i];
        }

        public static IEnumerable<IEnumerable<T>> GetColumns<T>(this IReadOnlyTable<T> table)
        {
            for (int i = 0; i < table.Columns; i++)
                yield return table.GetColumn(i);
        }

        public static IEnumerable<IEnumerable<T>> GetRows<T>(this IReadOnlyTable<T> table)
        {
            for (int i = 0; i < table.Rows; i++)
                yield return table.GetRow(i);
        }
    }
}
