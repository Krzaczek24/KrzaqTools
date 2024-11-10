# Krzaq.Extensions.Enum
Extension that helps working with enums.

## v1.2.0
* Added `TEnum[] GetParticularFlags<TEnum>(this TEnum @enum)`

## v1.1.1
* Added `TAttribute? GetAttribute<TAttribute>(this Enum @enum)`
* Added `IEnumerable<TAttribute> GetAttributes<TAttribute>(this Enum @enum)`
* Added `IEnumerable<TProperty> GetAttributePropertyValues<TAttribute, TProperty>(this Enum @enum, Func<TAttribute, TProperty> selector)`

## v1.1.0
* Removed `TProperty GetAttributePropertyValue<TAttribute, TProperty>(this Enum @enum, Func<TAttribute, TProperty> selector)`
* Added `bool TryGetAttributePropertyValue<TAttribute, TProperty>(this Enum @enum, Func<TAttribute, TProperty> selector, TProperty property)`

## v1.0.0
* Added `string? GetDescription(this Enum @enum)`
* Added `TProperty GetAttributePropertyValue<TAttribute, TProperty>(this Enum @enum, Func<TAttribute, TProperty> selector)`
