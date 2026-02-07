using Krzaq.Attributes.EnumToString;
using Krzaq.Converters.EnumToString;
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

    internal class MyResponse
    {
        public IReadOnlyCollection<MyModel> Items { get; set; } = [];
    }

    internal class EnumToStringTests
    {
        [Test]
        public void TestEnumToString()
        {
            // --- Arrange ---
            var myModel = new MyModel() { Value = TestValues.LowVal };
            var myResponse = new MyResponse() { Items = [myModel] };

            // --- Act ---
            string test = JsonSerializer.Serialize(myResponse);

            // --- Assert ---
            Assert.That(test, Is.EqualTo("{\"Items\":[{\"Value\":\"LOW_VAL\"}]}"));
        }
    }
}
