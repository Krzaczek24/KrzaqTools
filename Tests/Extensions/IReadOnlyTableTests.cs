using Krzaq.Collections.IReadOnlyTable;
using Krzaq.Collections.ReadOnlyTable;
using Krzaq.Extensions.IReadOnlyTable;

namespace Krzaq.Tests.Extensions
{
    internal class IReadOnlyTableTests
    {
        private static IReadOnlyTable<int> Table { get; } = new ReadOnlyTable<int>(new int[,]
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 }
        });

        [Test]
        public void GetColumn()
        {
            // --- Arrange ---
            var expectedColumn = new int[] { 3, 7, 11 };

            // --- Act ---
            var column = Table.GetColumn(2).ToList();

            // --- Assert ---
            Assert.That(column, Is.EqualTo(expectedColumn));
        }

        [Test]
        public void GetRow()
        {
            // --- Arrange ---
            var expectedRow = new int[] { 5, 6, 7, 8 };

            // --- Act ---
            var row = Table.GetRow(1);

            // --- Assert ---
            Assert.That(row, Is.EqualTo(expectedRow));
        }

        [Test]
        public void GetColumns()
        {
            // --- Arrange ---
            var expectedColumn = new int[] { 4, 8, 12 };

            // --- Act ---
            var columns = Table.GetColumns().ToList();

            // --- Assert ---
            Assert.Multiple(() =>
            {
                Assert.That(columns, Has.Count.EqualTo(4));
                Assert.That(columns[3], Is.EqualTo(expectedColumn));
            });
        }

        [Test]
        public void GetRows()
        {
            // --- Arrange ---
            var expectedRow = new int[] { 1, 2, 3, 4 };

            // --- Act ---
            var rows = Table.GetRows().ToList();

            // --- Assert ---
            Assert.Multiple(() =>
            {
                Assert.That(rows, Has.Count.EqualTo(3));
                Assert.That(rows[0], Is.EqualTo(expectedRow));
            });
        }
    }
}
