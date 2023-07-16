using System;

namespace KrzaqTools.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum, AllowMultiple = false)]
    public class EnumParseAttribute : Attribute
    {
        public ConvertMode Mode { get; set; }

        public EnumParseAttribute() { }

        public EnumParseAttribute(ConvertMode mode)
        {
            Mode = mode;
        }

        public enum ConvertMode
        {
            Undefined,
            Name,
            Value,
            Description
        }
    }
}
