using System;
using System.Collections.Generic;
using System.Linq;

namespace Geranium.Reflection
{
    /// <summary>
    /// C# IS and AS language expressions extensions
    /// </summary>
    public static class IsAsExtensions
    {
        /// <summary>
        /// Equivalent of C# 'as' expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="trowIfTypeWrong">if not, return default</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static T As<T>(this object obj, bool trowIfTypeWrong = true)
        {
            if (obj == default)
            {
                return default;
            }

            if (obj is T tObj)
            {
                return tObj;
            }

            if (obj is null)
            {
                throw new ArgumentNullException("Object is null!");
            }

            if (trowIfTypeWrong)
                throw new Exception("Object is wrong type!");

            return default;
        }

        /// <summary>
        /// Equivalent of C# 'as' expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T As<T>(this object obj)
        {
            if (obj == default)
            {
                return default;
            }

            if (obj is T tObj)
            {
                return tObj;
            }

            return default;
        }

        /// <summary>         
        /// Equivalent of C# 'as' expression with value if type is wrong
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="defaultIfExists"></param>
        /// <returns></returns>
        public static T As<T>(this object obj, T @defaultIfExists)
        {
            if (obj == default)
            {
                return default;
            }

            if (obj is T tObj)
            {
                return tObj;
            }

            return @defaultIfExists;
        }

        /// <summary>
        /// Equivalent of C# 'is' expression
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Is<TType>(this object obj)
        {
            return obj is TType;
        }

        /// <summary>
        /// Equivalent of C# 'is' expression provided by <see cref="Type.IsAssignableFrom(Type?)"/>
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Is<TType>(this Type type)
        {
            return typeof(TType).IsAssignableFrom(type);
        }

        /// <summary>
        /// Equivalent of C# 'is matched' expression
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="obj"></param>
        /// <param name="castResult"></param>
        /// <returns></returns>
        public static bool Is<TType>(this object obj, out TType castResult)
        {
            if (obj is TType result)
            {
                castResult = result;
                return true;
            }

            castResult = default;
            return false;
        }

        /// <summary>
        /// Equivalent of C# 'is not' expression
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNot<TType>(this Type type) => !type.Is<TType>();

        /// <summary>
        /// Equivalent of C# 'is not' expression
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNot<TType>(this object obj)
        {
            return !(obj is TType);
        }

        /// <summary>
        /// Equivalent of C# 'is not mathced' expression (before C# 9.0)
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="obj"></param>
        /// <param name="castResult"></param>
        /// <returns></returns>
        public static bool IsNot<TType>(this object obj, out TType castResult)
        {
            if (obj is TType result)
            {
                castResult = result;
                return false;
            }

            castResult = default;
            return true;
        }

        /// <summary>
        /// Strings and enumerables checks differently
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> @enum)
        {
            if (@enum is string str)
                return !string.IsNullOrWhiteSpace(str);

            return @enum != null && @enum.Any();
        }

        /// <summary>
        /// Strings and enumerables checks differently
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> @enum) => !@enum.IsNotEmpty();
    }
}