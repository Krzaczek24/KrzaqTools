# Krzaq.ReflectionToolbox
Library contains few reflection functions
	
## v1.0.0
* `List<Type> GetAllNonAbstractSubclasses(Type baseClassType)`
* `List<Type> GetAllNonAbstractSubclasses<TBaseClass>()`
* `List<Type> GetAllNonAbstractSubclasses<TBaseClass, TAssemblyClass>()`
* `List<Type> GetAllNonAbstractSubclasses(Type baseClassType, Type assemblyClassType)`
* `List<Type> GetAllNonAbstractImplementingInterface(Type @interface)`
* `List<Type> GetAllNonAbstractImplementingInterface<TInterface>()`
* `List<Type> GetAllNonAbstractImplementingInterface<TInterface, TAssemblyClass>()`
* `List<Type> GetAllNonAbstractImplementingInterface(Type @interface, Type assemblyClassType)`
* `T GetObjectPropertyValue<T>(object obj, string propertyName)`
* `object CallPropertyMethod(object obj, string propertyName, string methodName)`
* `object GetObjectPropertyValue(object obj, string propertyName)`
* `object GetEnumAsJsonObject<T>()`
