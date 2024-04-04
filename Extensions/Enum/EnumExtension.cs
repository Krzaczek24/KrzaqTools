using System;
using System.ComponentModel;
using System.Reflection;

namespace KrzaqTools.Extensions
{
    public static class EnumExtension
    {
        public static string? GetDescription(this Enum @enum)
        {
            _ = TryGetAttributePropertyValue(@enum, (DescriptionAttribute attr) => attr.Description, out string descripton);
            return descripton;
        }

        public static bool TryGetAttributePropertyValue<TAttribute, TProperty>(this Enum @enum, Func<TAttribute, TProperty> selector, out TProperty property)
            where TAttribute : Attribute
        {
            var attribute = @enum.GetType().GetField(@enum.ToString()).GetCustomAttribute<TAttribute>();
            bool found = attribute != null;
            property = found ? selector(attribute!) : default!;
            return found;
        }
    }
}
