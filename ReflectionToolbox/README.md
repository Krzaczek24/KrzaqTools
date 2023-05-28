# ReflectionToolbox
Library contains few reflection functions
## v1.1.2
* Fixed
	* `List<Type> GetAllNonAbstractSubclasses<TBaseClass>()`
	* `List<Type> GetAllNonAbstractImplementingInterface<TInterface>()`
## v1.1.1
* Fixed
	* `List<Type> GetAllNonAbstractSubclasses<TBaseClass>()`
	* `List<Type> GetAllNonAbstractSubclasses(Type baseClassType)`
	* `List<Type> GetAllNonAbstractImplementingInterface<TInterface>()`
	* `List<Type> GetAllNonAbstractImplementingInterface(Type @interface)`
## v1.1.0
* Added
	* `List<Type> GetAllNonAbstractSubclasses<TBaseClass>()`
	* `List<Type> GetAllNonAbstractSubclasses<TBaseClass, TAssemblyClass>()`
	* `List<Type> GetAllNonAbstractSubclasses(Type baseClassType, Type assemblyClassType)`
	* `List<Type> GetAllNonAbstractImplementingInterface<TInterface>()`
	* `List<Type> GetAllNonAbstractImplementingInterface<TInterface, TAssemblyClass>()`
	* `List<Type> GetAllNonAbstractImplementingInterface(Type @interface, Type assemblyClassType)`
## v1.0.0
* `List<Type> GetAllNonAbstractSubclasses(Type baseClassType)`
* `List<Type> GetAllNonAbstractImplementingInterface(Type @interface)`
* `object CallPropertyMethod(object obj, string propertyName, string methodName)`
* `object GetObjectPropertyValue(object obj, string propertyName)`
* `T GetObjectPropertyValue<T>(object obj, string propertyName)`
* `object GetEnumAsJsonObject<T>()`