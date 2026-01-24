# Krzaq.Extensions.String
Extension allows to change notation from any to choosen one

## v1.0.0
Added:
* `string ToCamelCase(this string input)`
* `string ToFlatCase(this string input)`
* `string ToKebabCase(this string input)`
* `string ToPascalCase(this string input)`
* `string ToSnakeCase(this string input)`
* `string Truncate(this string that, int maxLength, string? suffix = null)`
* `string TrimStart(this string that, string text, bool ignoreCase = false)`
* `string TrimEnd(this string that, string text, bool ignoreCase = false)`
* `string? GetTextBetween(this string that, string text, bool inclusive = false)`
* `string? GetTextBetween(this string that, string leftText, string rightText, bool inclusive = false)`