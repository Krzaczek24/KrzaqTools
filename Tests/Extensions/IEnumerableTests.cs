using KrzaqTools.Extensions;

#pragma warning disable CA1861
namespace Tests.Extensions
{
    internal class IEnumerableTests
    {
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
    }
}
