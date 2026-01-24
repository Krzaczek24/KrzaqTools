using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Krzaq.Tools.Reflection
{
    public static class ReflectionToolbox
    {
        public static List<Type> GetAllNonAbstractSubclasses<TBaseClass>(Assembly? assembly = null) => GetAllNonAbstractSubclasses(typeof(TBaseClass), assembly ?? Assembly.GetCallingAssembly());

        public static List<Type> GetAllNonAbstractSubclasses(Type baseClassType) => GetAllNonAbstractSubclasses(baseClassType, Assembly.GetCallingAssembly());

        public static List<Type> GetAllNonAbstractSubclasses<TBaseClass, TAssemblyClass>()
            where TBaseClass : class
            where TAssemblyClass : class => GetAllNonAbstractSubclasses(typeof(TBaseClass), typeof(TAssemblyClass).Assembly);

        public static List<Type> GetAllNonAbstractSubclasses(Type baseClassType, Assembly assembly)
        {
            if (baseClassType == null)
                throw new ArgumentNullException($"Parameter [{nameof(baseClassType)}] cannot be null");

            if (assembly == null)
                throw new ArgumentNullException($"Parameter [{nameof(assembly)}] cannot be null");

            if (baseClassType.IsInterface)
                throw new ArgumentException($"Parameter [{nameof(baseClassType)}] cannot be interface type");

            return assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(baseClassType))
                .ToList();
        }

        public static List<Type> GetAllNonAbstractImplementingInterface<TInterface>(Assembly? assembly = null) => GetAllNonAbstractImplementingInterface(typeof(TInterface), assembly ?? Assembly.GetCallingAssembly());

        public static List<Type> GetAllNonAbstractImplementingInterface(Type @interface) => GetAllNonAbstractImplementingInterface(@interface, Assembly.GetCallingAssembly());

        public static List<Type> GetAllNonAbstractImplementingInterface<TInterface, TAssemblyClass>() 
            where TInterface : class
            where TAssemblyClass : class => GetAllNonAbstractImplementingInterface(typeof(TInterface), typeof(TAssemblyClass).Assembly);

        public static List<Type> GetAllNonAbstractImplementingInterface(Type @interface, Assembly assembly)
        {
            if (@interface == null)
                throw new ArgumentNullException($"Parameter [{nameof(@interface)}] cannot be null");

            if (assembly == null)
                throw new ArgumentNullException($"Parameter [{nameof(assembly)}] cannot be null");

            if (!@interface.IsInterface)
                throw new ArgumentException($"Parameter [{nameof(@interface)}] must be interface type");

            return assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && @interface.IsAssignableFrom(t))
                .ToList();
        }

        public static object CallPropertyMethod(object obj, string propertyName, string methodName)
        {
            var type = obj.GetType();
            var property = type.GetProperty(propertyName);
            var method = property?.PropertyType.GetMethod(methodName) ?? throw new MissingMemberException($"Property {propertyName} has been not found for type {obj.GetType().Name}");
            var value = method?.Invoke(property.GetValue(obj), null) ?? throw new MissingMethodException($"Method {methodName} has been not found for property {propertyName}");

            return value;
        }

        public static object GetObjectPropertyValue(object obj, string propertyName)
        {
            var type = obj.GetType();
            var property = type.GetProperty(propertyName);
            return property?.GetValue(obj) ?? throw new MissingMemberException($"Property {propertyName} has been not found for type {obj.GetType().Name}");
        }

        public static T GetObjectPropertyValue<T>(object obj, string propertyName)
        {
            return (T)GetObjectPropertyValue(obj, propertyName);
        }

        public static object GetEnumAsJsonObject<T>() where T : Enum
        {
            var result = new List<object>();
            var enumValues = Enum.GetValues(typeof(T));

            foreach (int value in enumValues)
            {
                result.Add(new { value, name = Enum.GetName(typeof(T), value) });
            }

            return result;
        }
    }
}
