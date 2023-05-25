# ReflectionToolbox

Library contains few reflection functions

## v1.0.0
* `List<Type> GetAllNonAbstractSubclasses(Type type)`
* `List<Type> GetAllNonAbstractImplementingInterface(Type @interface)`
* `object CallPropertyMethod(object obj, string propertyName, string methodName)`
* `object GetObjectPropertyValue(object obj, string propertyName)`
* `T GetObjectPropertyValue<T>(object obj, string propertyName)`
* `object GetEnumAsJsonObject<T>()`