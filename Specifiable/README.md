# Krzaq.Specifiable
This `Specifiable` class allows you to box any other class and keep information about that if object was specified or not.
You can use that boxing when you want to know if object was made null intentionally.

It works little bit like `Nullable`, it also have property `Value`, but it also have property `IsSpecified` which initially is set to `false`.
Setting any value, even `null`, sets property `IsSpecified` to `true`.
There is also available method `Unspecify`, just in case to clear `Value` using `default` value and setting `IsSpecified` again to `false`.
Class provides possibility comparing with any other `Specifiable<T>` and `Specifiable`.

## v1.0.1
Fixed:
* Namespaces

## v1.0.0
* Library creation
