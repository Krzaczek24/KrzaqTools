using System;
using System.ComponentModel;
using System.Reflection;

namespace KrzaqTools.Extensions
{
    public static class EnumExtension
    {
        public static string? GetDescription(this Enum @enum)
        {
            return GetAttributePropertyValue(@enum, (DescriptionAttribute attr) => attr.Description);
        }

        public static TProperty GetAttributePropertyValue<TAttribute, TProperty>(this Enum @enum, Func<TAttribute, TProperty> selector)
            where TAttribute : Attribute
        {
            var attribute = @enum.GetType().GetField(@enum.ToString()).GetCustomAttribute<TAttribute>();
            return attribute == null ? default! : selector(attribute);
        }
    }
}
