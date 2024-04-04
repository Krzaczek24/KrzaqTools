﻿using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;
using KrzaqTools.Extensions;

namespace Tests.Extensions
{
    internal enum MyEnum
    {
        [Description("1")]
        First,
        Second,
        [Description("3")]
        Third,
        [MyAttr(Value = 4)]
        Fourth
    }

    [AttributeUsage(AttributeTargets.Field)]
    internal class MyAttrAttribute : Attribute
    {
        public int Value { get; set; }
    }

    internal class EnumTests
    {
        [Test]
        [TestCase(MyEnum.First, "1")]
        [TestCase(MyEnum.Second, null)]
        [TestCase(MyEnum.Third, "3")]
        [TestCase(MyEnum.Fourth, null)]
        public void GetDescriptionTest<T>(T @enum, string? expectedResult) where T : Enum
        {
            // --- Arrange ---

            // --- Act ---
            string? actualResult = @enum.GetDescription();

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(MyEnum.First, false, default(int))]
        [TestCase(MyEnum.Fourth, true, 4)]
        public void GetAttributePropertyValueTest<T>(T @enum, bool expectedResult, object expectedValue) where T : Enum
        {
            // --- Arrange ---

            // --- Act ---
            bool actualResult = @enum.TryGetAttributePropertyValue((MyAttrAttribute x) => x.Value, out int actualValue);

            // --- Assert ---
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}