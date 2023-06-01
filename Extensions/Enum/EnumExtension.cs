using System;
using System.ComponentModel;
using System.Reflection;

namespace KrzaqTools.EnumExtension
{
    public static class EnumExtension
    {
        public static string? GetDescription(this Enum @enum)
        {
            return @enum.GetType().GetField(@enum.ToString()).GetCustomAttribute<DescriptionAttribute>()?.Description;
        }
    }
}
