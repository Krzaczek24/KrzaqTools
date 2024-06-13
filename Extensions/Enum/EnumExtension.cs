using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace KrzaqTools.Extensions
{
    public static class EnumExtension
    {
        public static TAttribute? GetAttribute<TAttribute>(this Enum @enum) where TAttribute : Attribute
        {
            var attribute = @enum.GetType().GetField(@enum.ToString()).GetCustomAttribute<TAttribute>();
            return attribute;
        }

        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this Enum @enum) where TAttribute : Attribute
        {
            var attributes = @enum.GetType().GetField(@enum.ToString()).GetCustomAttributes<TAttribute>();
            return attributes;
        }

        public static string? GetDescription(this Enum @enum)
        {
            _ = TryGetAttributePropertyValue(@enum, (DescriptionAttribute attr) => attr.Description, out string descripton);
            return descripton;
        }

        public static bool TryGetAttributePropertyValue<TAttribute, TProperty>(this Enum @enum, Func<TAttribute, TProperty> selector, out TProperty property)
            where TAttribute : Attribute
        {
            var attribute = GetAttribute<TAttribute>(@enum);
            bool found = attribute != null;
            property = found ? selector(attribute!) : default!;
            return found;
        }

        public static IEnumerable<TProperty> GetAttributePropertyValues<TAttribute, TProperty>(this Enum @enum, Func<TAttribute, TProperty> selector)
            where TAttribute : Attribute
        {
            var attributes = GetAttributes<TAttribute>(@enum);
            var properties = attributes.Select(selector);
            return properties;
        }
    }
}
