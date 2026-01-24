namespace Krzaq.Extensions.String
{
    public static class StringExtension
    {
        public static string Truncate(this string that, int maxLength, string? suffix = null)
        {
            if (that.Length <= maxLength)
                return that;

            if (!string.IsNullOrEmpty(suffix))
                return $"{that[..(maxLength - suffix.Length)]}{suffix}";

            return that[..maxLength];
        }

        public static string TrimStart(this string that, string text, bool ignoreCase = false)
        {
            if (that.StartsWith(text) || ignoreCase && that.ToLower().StartsWith(text.ToLower()))
                return that[text.Length..];
            return that;
        }

        public static string TrimEnd(this string that, string text, bool ignoreCase = false)
        {
            if (that.EndsWith(text) || ignoreCase && that.ToLower().EndsWith(text.ToLower()))
                return that[..^text.Length];
            return that;
        }

        public static string? GetTextBetween(this string that, string text, bool inclusive = false) => GetTextBetween(that, text, text, inclusive);
        public static string? GetTextBetween(this string that, string leftText, string rightText, bool inclusive = false)
        {
            if (string.IsNullOrEmpty(that)) return null;
            int leftIndex = that.IndexOf(leftText);
            int rightIndex = that.IndexOf(rightText, leftIndex + 1);
            if (rightIndex <= leftIndex) return null;
            if (inclusive) return that[leftIndex..(rightIndex + rightText.Length)];
            return that[(leftIndex + leftText.Length)..rightIndex];
        }
    }
}
