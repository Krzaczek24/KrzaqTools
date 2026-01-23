using Krzaq.Attributes.EnumParse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Krzaq.Extensions.Enum
{
    public static class EnumExtension
    {
        public static TAttribute? GetAttribute<TAttribute>(this System.Enum @enum) where TAttribute : Attribute
        {
            var attribute = @enum.GetType().GetField(@enum.ToString()).GetCustomAttribute<TAttribute>();
            return attribute;
        }

        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this System.Enum @enum) where TAttribute : Attribute
        {
            var attributes = @enum.GetType().GetField(@enum.ToString()).GetCustomAttributes<TAttribute>();
            return attributes;
        }

        public static string? GetDescription(this System.Enum @enum)
        {
            _ = TryGetAttributePropertyValue(@enum, (DescriptionAttribute attr) => attr.Description, out string descripton);
            return descripton;
        }

        public static TEnum[] GetParticularFlags<TEnum>(this TEnum @enum) where TEnum : struct, System.Enum
        {
            return System.Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Where(v => @enum.HasFlag(v)).ToArray();
        }

        public static bool TryGetAttributePropertyValue<TAttribute, TProperty>(this System.Enum @enum, Func<TAttribute, TProperty> selector, out TProperty property)
            where TAttribute : Attribute
        {
            var attribute = GetAttribute<TAttribute>(@enum);
            bool found = attribute != null;
            property = found ? selector(attribute!) : default!;
            return found;
        }

        public static IEnumerable<TProperty> GetAttributePropertyValues<TAttribute, TProperty>(this System.Enum @enum, Func<TAttribute, TProperty> selector)
            where TAttribute : Attribute
        {
            var attributes = GetAttributes<TAttribute>(@enum);
            var properties = attributes.Select(selector);
            return properties;
        }

        public static TEnum GetRandom<TEnum>() where TEnum : System.Enum
        {
            return System.Enum.GetValues(typeof(TEnum)).Cast<TEnum>().OrderBy(_ => Guid.NewGuid()).FirstOrDefault();
        }

        public static TEnum Parse<TEnum>(string value) where TEnum : notnull, System.Enum
        {
            return Parse<TEnum>(value, typeof(TEnum).GetCustomAttribute<EnumParseAttribute>()?.Mode ?? EnumParseAttribute.ConvertMode.Undefined);
        }

        public static TEnum Parse<TEnum>(string value, EnumParseAttribute.ConvertMode mode) where TEnum : notnull, System.Enum
        {
            Type type = typeof(TEnum);

            if (mode == EnumParseAttribute.ConvertMode.Value && int.TryParse(value, out int enumIntValue))
            {
                return (TEnum)System.Enum.ToObject(type, enumIntValue);
            }

            if (mode == EnumParseAttribute.ConvertMode.Description)
            {
                foreach (TEnum enumValue in System.Enum.GetValues(type))
                {
                    string? description = enumValue.GetDescription();
                    if (!string.IsNullOrEmpty(description) && description.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return enumValue;
                    }
                }
            }

            if (mode == EnumParseAttribute.ConvertMode.Name)
            {
                foreach (TEnum enumValue in System.Enum.GetValues(type))
                {
                    string name = enumValue.ToString();
                    if (name.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return enumValue;
                    }
                }
            }

            return default!;
        }
    }
}
