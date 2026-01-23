using Krzaq.Attributes.EnumToString;
using Krzaq.Extensions.StringNotation;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Krzaq.Converters.EnumToString
{
    public class EnumToStringConverter<T> : JsonConverter<T>
        where T : struct, Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Enum.TryParse(typeToConvert, reader.GetString()?.ToCamelCase(), true, out object? result) ? (T)result! : default!;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var convertMode = value.GetType().GetCustomAttribute<EnumToStringAttribute>()?.Mode ?? NameAlterMode.None;
            string enumString = value.ToString();
            writer.WriteStringValue(convertMode switch
            {
                NameAlterMode.ToCamel => enumString.ToCamelCase(),
                NameAlterMode.ToFlat => enumString.ToFlatCase(),
                NameAlterMode.ToKebab => enumString.ToKebabCase(),
                NameAlterMode.ToLower => enumString.ToLower(),
                NameAlterMode.ToSnake => enumString.ToSnakeCase(),
                NameAlterMode.ToUpper => enumString.ToUpper(),
                NameAlterMode.ToUpperFlat => enumString.ToFlatCase().ToUpper(),
                NameAlterMode.ToUpperKebab => enumString.ToKebabCase().ToUpper(),
                NameAlterMode.ToUpperSnake => enumString.ToSnakeCase().ToUpper(),
                _ => enumString,
            });
        }
    }
}