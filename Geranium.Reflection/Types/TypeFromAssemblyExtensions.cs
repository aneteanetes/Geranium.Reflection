using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
#if NETCOREAPP3_1_OR_GREATER
using System.Runtime.Loader;
#endif

namespace Geranium.Reflection
{
    /// <summary>
    /// Extensions for getting type from Assembly
    /// </summary>
    public static class TypeFromAssemblyExtensions
    {
        private static readonly ConcurrentDictionary<string, Assembly> LoadedAssemblies = new ConcurrentDictionary<string, Assembly>();

        /// <summary>
        /// [Cached] Get all types from all <see cref="AppDomain.CurrentDomain"/> assemblies <see cref="Type.IsAssignableFrom(Type?)"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type[] AllAssignedFrom(this Type type)
        {
            if (!___AllCache.TryGetValue(type, out var value))
            {
                value = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                    .Where(t => type.IsAssignableFrom(t))
                    .ToArray();
                ___AllCache.AddOrUpdate(type, value, (x, y) => value);
            }

            return value;
        }
        private static readonly ConcurrentDictionary<Type, Type[]> ___AllCache = new ConcurrentDictionary<Type, Type[]>();

        /// <summary>
        /// [Casted] Get type from assembly and created by <see cref="NewExtensions.New{T}(object)"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyType"></param>
        /// <returns></returns>
        public static T GetInstanceFromAssembly<T>(this object assemblyType)
            => assemblyType.GetTypeFromAssembly<T>()
                .NewAs<T>();

        /// <summary>
        /// [Casted] Get type's from assembly and created by <see cref="NewExtensions.New{T}(object)"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyType"></param>
        /// <returns></returns>
        public static T[] GetInstancesFromAssembly<T>(this object assemblyType)
            => assemblyType.GetTypesFromAssembly<T>()
                .Select(x => x.NewAs<T>())
                .ToArray();

        /// <summary>
        /// Get types from assembly which <see cref="Type.IsAssignableFrom(Type?)"/> from <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyType"></param>
        /// <returns></returns>
        public static Type[] GetTypesFromAssembly<T>(this object assemblyType)
            => assemblyType.GetType()
                .Assembly
                .GetTypes()
                .Where(x => typeof(T).IsAssignableFrom(x))
                .ToArray();

        /// <summary>
        /// Get <see cref="Assembly.GetTypes"/> with process <see cref="ReflectionTypeLoadException"/>
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypesSafe(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        /// <summary>
        /// Get FirstOrDefault type from assembly which <see cref="Type.IsAssignableFrom(Type?)"/> from <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyType"></param>
        /// <returns></returns>
        public static Type GetTypeFromAssembly<T>(this object assemblyType)
            => assemblyType.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => typeof(T).IsAssignableFrom(x));

        /// <summary>
        /// [Cached] Return VALUE from <paramref name="staticClassName"/>.<paramref name="propertyName"/> by <see cref="GetExtensions.GetStaticProperty(Type, string)"/>
        /// </summary>
        /// <param name="staticClassName"></param>
        /// <param name="propertyName"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static object GetPropertyOfStaticClass(this string staticClassName, string propertyName, string assemblyName = default)
        {
            if (assemblyName == default)
            {
                assemblyName = staticClassName.Split('.').Last();
            }

            return staticClassName
                .GetTypeFromAssemblyName(assemblyName)
                .GetStaticProperty(propertyName);
        }

        /// <summary>
        /// [Cached] Return VALUE from <see cref="GetPropertyOfStaticClass(string, string, string)"/> and cast
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="staticClassName"></param>
        /// <param name="propertyName"></param>
        /// <param name="assemblyName"></param>
        /// <param name="throwExceptionIfWorngType"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static T GetPropertyOfStaticClass<T>(this string staticClassName, string propertyName, string assemblyName = default, bool throwExceptionIfWorngType = true)
        {
            var value = GetPropertyOfStaticClass(staticClassName, propertyName, assemblyName);
            if (value.Is(out T valueT))
                return valueT;

            if (throwExceptionIfWorngType)
                throw new Exception("Property of wrong type!");

            return default;
        }

        /// <summary>
        /// [Cached] Get <see cref="Type"/> from <see cref="GetAssembly(string)"/> by user delegate <paramref name="searchFunc"/>
        /// </summary>
        /// <param name="typeName">searching type name</param>
        /// <param name="assemblyDllName">dll name</param>
        /// <param name="searchFunc">user function with searching name and asm for return type</param>
        /// <returns>Type from searchFunc</returns>
        public static Type GetTypeFromAssembly(this string typeName, string assemblyDllName, Func<string, Assembly, Type> searchFunc)
        {
            var assembly = GetAssembly(assemblyDllName);
            return searchFunc(typeName, assembly);
        }

        /// <summary>
        /// [Cached] Get <see cref="Assembly"/> from <paramref name="assemblyName"/>.dll searching in <see cref="AppDomain.BaseDirectory"/> with <see cref="AssemblyLoadContext.Default"/>
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static Assembly GetAssembly(this string assemblyName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{assemblyName}.dll");

            if (!LoadedAssemblies.TryGetValue(assemblyName, out var assembly))
            {
                
                assembly =
#if (NETSTANDARD2_1 || NET46)
                    Assembly.LoadFrom(path);
#elif NETCOREAPP3_1_OR_GREATER
                AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
#endif
                LoadedAssemblies.AddOrUpdate(assemblyName, assembly, (x, y) => assembly);
            }

            if (assembly == null)
                throw new ArgumentException($"Assembly with name '{assemblyName}.dll' not found in {path}!");

            return assembly;
        }

        /// <summary>
        /// Get <see cref="System.Type"/> from <see cref="GetTypeFromAssembly(string, string, Func{string, Assembly, Type})"/>
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static Type GetTypeFromAssemblyName(this string typeName, string assemblyName)
            => typeName.GetTypeFromAssembly(assemblyName, (x, a) => a.GetType(x));

        /// <summary>
        /// Get instance from <see cref="GetTypeFromAssembly(string, string, Func{string, Assembly, Type})"/> and <see cref="NewExtensions.NewAs{T}(Type, object[])"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="assemblyName"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static T GetInstanceFromAssembly<T>(this string value, string assemblyName, params object[] arguments)
            => value.GetTypeFromAssembly(assemblyName, (x, a) => a.GetType(value) ?? a.GetTypes().FirstOrDefault(t => t.Name == x))
                .NewAs<T>(arguments);

        /// <summary>
        /// Get types from assembly by user delegate
        /// </summary>
        /// <param name="value"></param>
        /// <param name="assemblyName"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public static Type[] GetTypesFromAssembly(this string value, string assemblyName, Func<string, Assembly, IEnumerable<Type>> searchPattern)
        {
            var assembly = GetAssembly(assemblyName);
            return searchPattern(value, assembly).ToArray();
        }

        /// <summary>
        /// Get type instance from assembly name and type name by <see cref="GetTypeFromAssembly(string, string, Func{string, Assembly, Type})"/>
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="assemblyName"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public static object GetInstance(this string typeName, string assemblyName, Func<string, Assembly, Type> searchPattern)
        {
            var type = typeName.GetTypeFromAssembly(assemblyName, searchPattern);

            return type.New();
        }

        /// <summary>
        /// Get types instance's from assembly name and type name by <see cref="GetTypeFromAssembly(string, string, Func{string, Assembly, Type})"/> and <see cref="NewExtensions.New{T}(object)"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeName"></param>
        /// <param name="assemblyName"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public static T[] GetInstancesFromAssembly<T>(this string typeName, string assemblyName, Func<string, Assembly, IEnumerable<Type>> searchPattern)
        {
            var types = typeName.GetTypesFromAssembly(assemblyName, searchPattern);

            return types.Select(x => (T)x.New()).ToArray();
        }
    }
}