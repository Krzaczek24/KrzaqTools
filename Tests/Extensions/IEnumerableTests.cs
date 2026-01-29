using Krzaq.Extensions.IEnumerable;
using System.Collections;

#pragma warning disable CA1861
namespace Krzaq.Tests.Extensions
{
    internal class IEnumerableTests
    {

        [Test]
        [TestCase(new object[] { "a", "b", "c" }, ',', "a,b,c")]
        [TestCase(new object[] { "one", "two" }, ';', "one;two")]
        [TestCase(new object[] { 1, "two" }, '/', "1/two")]
        public void Join_WithCharSeparator(object[] items, char separator, string expected)
        {
            // --- Arrange ---

            // --- Act ---
            string actual = items.Join(separator);

            // --- Assert ---
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new object[] { "a", "b", "c" }, "", "abc")]
        [TestCase(new object[] { 'x', 'y' }, "-", "x-y")]
        [TestCase(new object[] { 4, '2' }, "-", "4-2")]
        public void Join_WithStringSeparator(object[] items, string separator, string expected)
        {
            // --- Arrange ---

            // --- Act ---
            string actual = items.Join(separator);

            // --- Assert ---
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new object[] { 1, 2, 3 }, ';', "0;1;1")]
        [TestCase(new object[] { 5, 6 }, ',', "2,3")]
        public void Join_WithSelectorAndCharSeparator(object[] items, char separator, string expected)
        {
            // --- Arrange ---

            // --- Act ---
            string actual = items.Join(i => (int)i / 2, separator);

            // --- Assert ---
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new object[] { 10, 20 }, "", "510")]
        [TestCase(new object[] { 2, 3 }, ",", "1,1")]
        public void Join_WithSelectorAndStringSeparator(object[] items, string separator, string expected)
        {
            // --- Arrange ---

            // --- Act ---
            string actual = items.Join(i => ((int)i / 2), separator);

            // --- Assert ---
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new string[] { "a" }, new string[] { "b" }, false)]
        [TestCase(new string[] { "x" }, new string[] { "x" }, true)]
        [TestCase(new string[] { "a", "b" }, new string[] { "b", "b" }, true)]
        [TestCase(new string[] { "a", "b" }, new string[] { "a", "b", "c" }, true)]
        [TestCase(new string[] { "a", "a" }, new string[] { "b" }, false)]
        [TestCase(new string[] { "a", "a" }, new string[] { "a" }, true)]
        public void HasAnyTest(object[] first, object[] second, bool expectedResult)
        {
            // --- Arrange ---

            // --- Act ---
            bool actualResult = first.HasAny(second);

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(new string[] { "a" }, new string[] { "b" }, false)]
        [TestCase(new string[] { "x" }, new string[] { "x" }, true)]
        [TestCase(new string[] { "a", "b" }, new string[] { "b", "b" }, true)]
        [TestCase(new string[] { "a", "b" }, new string[] { "a", "b", "c" }, false)]
        [TestCase(new string[] { "a", "a" }, new string[] { "b" }, false)]
        [TestCase(new string[] { "a", "a" }, new string[] { "a" }, true)]
        public void HasAllTest(object[] first, object[] second, bool expectedResult)
        {
            // --- Arrange ---

            // --- Act ---
            bool actualResult = first.HasAll(second);

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(new string[] { }, false)]
        [TestCase(new string[] { "a" }, true, "a")]
        [TestCase(new string[] { "a", "b" }, false)]
        [TestCase(new string[] { "a", "b", "c" }, false)]
        public void TryGetSingleTest(object[] first, bool expectedResult, object? expectedValue = null)
        {
            // --- Arrange ---

            // --- Act ---
            bool actualResult = first.TryGetSingle(out object actualValue);

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(false, new string[] { "any" })]
        [TestCase(true, new string[] { })]
        [TestCase(true)]
        public void IsNullOrEmptyIEnumerableTest(bool expectedResult, IEnumerable? first = null)
        {
            // --- Arrange ---

            // --- Act ---
            bool actualResult = first!.IsNullOrEmpty();

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(false, new string[] { "any" })]
        [TestCase(true, new string[] { })]
        [TestCase(true)]
        public void IsNullOrEmptyEnumerableTest(bool expectedResult, IEnumerable<object>? first = null)
        {
            // --- Arrange ---

            // --- Act ---
            bool actualResult = first!.IsNullOrEmpty();

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(false, new string[] { "any" })]
        [TestCase(true, new string[] { })]
        [TestCase(true)]
        public void IsNullOrEmptyCollectionTest(bool expectedResult, ICollection<object>? first = null)
        {
            // --- Arrange ---

            // --- Act ---
            bool actualResult = first!.IsNullOrEmpty();

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DeconstructStructsTest()
        {
            // --- Arrange ---
            var array = new[] { 1, 2 };

            // --- Act ---
            var (first, (second, (third, rest))) = array;
            var (_, rest2) = array;

            // --- Assert ---
            Assert.Multiple(() =>
            {
                Assert.That(first, Is.EqualTo(1));
                Assert.That(second, Is.EqualTo(2));
                Assert.That(third, Is.Null);
                Assert.That(rest, Is.Empty);

                Assert.That(rest2.ToList(), Has.Count.EqualTo(1));
                Assert.That(rest2.First(), Is.EqualTo(2));
            });
        }

        private record Foo(int Value);
        [Test]
        public void DeconstructClassesTest()
        {
            // --- Arrange ---
            var array = new[] { new Foo(1), new Foo(2) };

            // --- Act ---
            var (first, (second, (third, rest))) = array;
            var (_, rest2) = array;

            // --- Assert ---
            Assert.Multiple(() =>
            {
                Assert.That(first, Is.EqualTo(new Foo(1)));
                Assert.That(second, Is.EqualTo(new Foo(2)));
                Assert.That(third, Is.Null);
                Assert.That(rest, Is.Empty);

                Assert.That(rest2.ToList(), Has.Count.EqualTo(1));
                Assert.That(rest2.First(), Is.EqualTo(new Foo(2)));
            });
        }
    }
}
