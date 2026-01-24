using Krzaq.Extensions.String;
using Krzaq.Extensions.String.Notation;

namespace Krzaq.Tests.Extensions
{
    internal class StringTests
    {
        private const string CamelCase = "alaMaKota";
        private const string FlatCase = "alamakota";
        private const string KebabCase = "ala-ma-kota";
        private const string PascalCase = "AlaMaKota";
        private const string SnakeCase = "ala_ma_kota";

        [Test]
        [TestCase(CamelCase, CamelCase)]
        //[TestCase(FlatCase, SnakeCase)]
        [TestCase(KebabCase, CamelCase)]
        [TestCase(PascalCase, CamelCase)]
        [TestCase(SnakeCase, CamelCase)]
        public void ToCamelCase(string input, string expectedResult)
        {
            // --- Arrange ---

            // --- Act ---
            string actualResult = input.ToCamelCase();

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(CamelCase, FlatCase)]
        [TestCase(FlatCase, FlatCase)]
        [TestCase(KebabCase, FlatCase)]
        [TestCase(PascalCase, FlatCase)]
        [TestCase(SnakeCase, FlatCase)]
        public void ToFlatCase(string input, string expectedResult)
        {
            // --- Arrange ---

            // --- Act ---
            string actualResult = input.ToFlatCase();

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(CamelCase, KebabCase)]
        //[TestCase(FlatCase, SnakeCase)]
        [TestCase(KebabCase, KebabCase)]
        [TestCase(PascalCase, KebabCase)]
        [TestCase(SnakeCase, KebabCase)]
        public void ToKebabCase(string input, string expectedResult)
        {
            // --- Arrange ---

            // --- Act ---
            string actualResult = input.ToKebabCase();

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(CamelCase, PascalCase)]
        //[TestCase(FlatCase, SnakeCase)]
        [TestCase(KebabCase, PascalCase)]
        [TestCase(PascalCase, PascalCase)]
        [TestCase(SnakeCase, PascalCase)]
        public void ToPascalCase(string input, string expectedResult)
        {
            // --- Arrange ---

            // --- Act ---
            string actualResult = input.ToPascalCase();

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(CamelCase, SnakeCase)]
        //[TestCase(FlatCase, SnakeCase)]
        [TestCase(KebabCase, SnakeCase)]
        [TestCase(PascalCase, SnakeCase)]
        [TestCase(SnakeCase, SnakeCase)]
        public void ToSnakeCase(string input, string expectedResult)
        {
            // --- Arrange ---

            // --- Act ---
            string actualResult = input.ToSnakeCase();

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("Sierotka", "sie", false, "Sierotka")]
        [TestCase("Sierotka", "sie", true, "rotka")]
        [TestCase("Marysia", "Mar", true, "ysia")]
        [TestCase("MaKota", "", false, "MaKota")]
        public void TrimStart(string input, string text, bool ignoreCase, string expectedResult)
        {
            // --- Arrange ---

            // --- Act ---
            string actualResult = input.TrimStart(text, ignoreCase);

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("Sierotka", "Tka", false, "Sierotka")]
        [TestCase("Sierotka", "Rotka", true, "Sie")]
        [TestCase("Marysia", "Mar", true, "Marysia")]
        [TestCase("MaKota", "", false, "MaKota")]
        public void TrimEnd(string input, string text, bool ignoreCase, string expectedResult)
        {
            // --- Arrange ---

            // --- Act ---
            string actualResult = input.TrimEnd(text, ignoreCase);

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("LoremIpsum", "m", false, "Ipsu")]
        [TestCase("LoremIpsum", "m", true, "mIpsum")]
        [TestCase("MarMarMarMar", "Mar", false, "")]
        [TestCase("TakiTamAlvaroLubiAlvaroSolera", "Alvaro", false, "Lubi")]
        public void GetTextBetween(string input, string text, bool inclusive, string expectedResult)
        {
            // --- Arrange ---


            // --- Act ---
            string? actualResult = input.GetTextBetween(text, inclusive);

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
