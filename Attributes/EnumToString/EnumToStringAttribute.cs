﻿using System;

namespace KrzaqTools.Attributes
{
    public enum NameAlterMode
    {
        None,
        ToCamel,
        ToFlat,
        ToKebab,
        ToLower,
        ToSnake,
        ToUpper,
        ToUpperFlat,
        ToUpperKebab,
        ToUpperSnake
    }

    public class EnumToStringAttribute : Attribute
    {
        public NameAlterMode Mode { get; }

        public EnumToStringAttribute() { }

        public EnumToStringAttribute(NameAlterMode mode)
        {
            Mode = mode;
        }
    }
}
