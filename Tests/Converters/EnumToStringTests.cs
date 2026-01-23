using KrzaqTools.Attributes;
using KrzaqTools.Converters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Krzaq.Tests.Converters
{
    [EnumToString(NameAlterMode.ToUpperSnake)]
    internal enum TestValues
    {
        None,
        LowVal,
        Medium,
        High,
    }

    internal class MyModel
    {
        [JsonConverter(typeof(EnumToStringConverter<TestValues>))]
        public TestValues Value { get; set; }
    }

    internal class EnumToStringTests
    {
        [Test]
        public void TestEnumToString()
        {
            // --- Arrange ---
            var myClass = new MyModel() { Value = TestValues.LowVal };

            // --- Act ---
            string test = JsonSerializer.Serialize(myClass);

            // --- Assert ---
            Assert.That(test, Is.EqualTo("{\"Value\":\"LOW_VAL\"}"));
        }
    }
}
