using Common.Enums;
using KrzaqTools.Extensions;
using System.Numerics;

namespace Tests.Extensions
{
    internal class INumberTests
    {
        [Test]

        [TestCase(-1, 0, 1, Inclusivity.None, true)]
        [TestCase(-1, 0, 1, Inclusivity.Left, true)]
        [TestCase(-1, 0, 1, Inclusivity.Right, true)]
        [TestCase(-1, 0, 1, Inclusivity.Both, true)]

        [TestCase(-1, -1, 1, Inclusivity.None, false)]
        [TestCase(-1, -1, 1, Inclusivity.Left, true)]
        [TestCase(-1, -1, 1, Inclusivity.Right, false)]
        [TestCase(-1, -1, 1, Inclusivity.Both, true)]

        [TestCase(-1, 1, 1, Inclusivity.None, false)]
        [TestCase(-1, 1, 1, Inclusivity.Left, false)]
        [TestCase(-1, 1, 1, Inclusivity.Right, true)]
        [TestCase(-1, 1, 1, Inclusivity.Both, true)]

        [TestCase(-1, -2, 1, Inclusivity.None, false)]
        [TestCase(-1, -2, 1, Inclusivity.Left, false)]
        [TestCase(-1, -2, 1, Inclusivity.Right, false)]
        [TestCase(-1, -2, 1, Inclusivity.Both, false)]

        [TestCase(-1, 2, 1, Inclusivity.None, false)]
        [TestCase(-1, 2, 1, Inclusivity.Left, false)]
        [TestCase(-1, 2, 1, Inclusivity.Right, false)]
        [TestCase(-1, 2, 1, Inclusivity.Both, false)]

        public void IsBetweenTest<T>(T min, T value, T max, Inclusivity inclusivity, bool expectedResult) where T : INumber<T>
        {
            // --- Arrange ---

            // --- Act ---
            bool actualResult = value.IsBetween(min, max, inclusivity);

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
