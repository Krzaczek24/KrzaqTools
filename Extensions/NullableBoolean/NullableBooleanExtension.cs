﻿namespace KrzaqTools.Extensions
{
    public static class NullableBooleanExtension
    {
        public static bool IsTrue(this bool? obj) => obj.HasValue && obj.Value;
        public static bool IsNotTrue(this bool? obj) => !IsTrue(obj);

        public static bool IsFalse(this bool? obj) => obj.HasValue && !obj.Value;
        public static bool IsNotFalse(this bool? obj) => !IsFalse(obj);
    }
}
