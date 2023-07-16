using KrzaqTools.Attributes;
using KrzaqTools.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace KrzaqTools
{
    public static class EnumTools
    {
        public static TEnum GetRandom<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().OrderBy(_ => Guid.NewGuid()).FirstOrDefault();
        }

        public static TEnum Parse<TEnum>(string value) where TEnum : notnull, Enum
        {
            return Parse<TEnum>(value, typeof(TEnum).GetCustomAttribute<EnumParseAttribute>()?.Mode ?? EnumParseAttribute.ConvertMode.Undefined);
        }

        public static TEnum Parse<TEnum>(string value, EnumParseAttribute.ConvertMode mode) where TEnum : notnull, Enum
        {
            Type type = typeof(TEnum);

            if (mode == EnumParseAttribute.ConvertMode.Value && int.TryParse(value, out int enumIntValue))
            {
                return (TEnum)Enum.ToObject(type, enumIntValue);
            }

            if (mode == EnumParseAttribute.ConvertMode.Description)
            {
                foreach (TEnum enumValue in Enum.GetValues(type))
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
                foreach (TEnum enumValue in Enum.GetValues(type))
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
