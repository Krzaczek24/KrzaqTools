# Krzaq.Extensions.INumber
Extension adds few method to `INumber` types.

## v1.1.0
Added:
* `T Scale<T>(this T value, T minSourceValue, T maxSourceValue, T minTargetValue, T maxTargetValue)`
* `T CutOff<T>(this T value, T min, T max)`
* `T ScaleAndCutOff<T>(this T value, T minSourceValue, T maxSourceValue, T minTargetValue, T maxTargetValue)`
* `T Threshold<T>(this T value, T threshold)`

## v1.0.9
* NuGet package reference fix

## v1.0.8
* Project name fix

## v1.0.7
Updated `Krzaq.Common` version

## v1.0.6
Fixed reference to `Krzaq.Common` project

## v1.0.0
Supports:
* `bool IsBetween<T>(this T number, T min, T max, Inclusivity inclusivity = Inclusivity.Both)`
