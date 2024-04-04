using System;

namespace Common.Enums
{
    [Flags]
    public enum Inclusivity
    {
        None = 0,
        Left = 1 << 0,
        Right = 1 << 1,
        Both = Left | Right
    }
}
