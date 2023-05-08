using Geranium.Reflection.Struct;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;

namespace Geranium.Reflection
{
    /// <summary>
    /// Extensions methods for getting value from properties by <see cref="Expression"/>
    /// </summary>
    public static class GetExtensions
    {
        /// <summary>
        /// Gets static property value by <see cref="Expression.MakeMemberAccess(Expression?, System.Reflection.MemberInfo)"/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static object GetStaticProperty(this Type type, string property)
        {
            return Expression.Lambda(Expression.MakeMemberAccess(null, type.GetMembers().FirstOrDefault(x => x.Name == property))).Compile().DynamicInvoke();
        }

        /// <summary>
        /// Better use <see cref="GetPropValue(object, string)"/>
        /// <para>
        /// [Cached] Get object property value (of <typeparamref name="TValue"/>) from <typeparamref name="THost"/>
        /// </para>
        /// </summary>
        /// <typeparam name="THost">Type of object</typeparam>
        /// <typeparam name="TValue">Type of result</typeparam>
        /// <param name="obj">Object from getting value</param>
        /// <param name="propName">Property name</param>
        /// <returns>Value of property</returns>
        public static TValue GetPropValue<THost, TValue>(this THost obj, string propName)
        {
            return GetPropCacheGeneric<THost, TValue>.GetPropFunc(propName)(obj);
        }

        /// <summary>
        /// Better use <see cref="GetPropValue(object, string)"/>
        /// <para>
        /// [Cached] Get object property value (of <typeparamref name="TValue"/>) from object
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">Type of result</typeparam>
        /// <param name="obj">Object from getting value</param>
        /// <param name="propName">Property name</param>
        /// <returns>Value of property</returns>
        public static TValue GetPropValue<TValue>(this object obj, string propName)
        {
            return GetPropValueGeneric<TValue>.GetPropFunc(obj.GetType(), propName)(obj);
        }

        /// <summary>
        /// [Cached] Get object property value
        /// </summary>
        /// <param name="obj">Object from getting value</param>
        /// <param name="propName">Property name</param>
        /// <returns>Value of property</returns>
        public static object GetPropValue(this object obj, string propName)
        {
            return GetPropCache.GetPropFunc(obj.GetType(), propName)(obj);
        }

        private static class GetPropCacheGeneric<TType, TValue>
        {
            public static Func<TType, TValue> GetPropFunc(string propName)
            {
                var key = InternalHasher.Hash(typeof(TType), typeof(TValue), propName);
                return cache.GetOrAdd(key, k =>
                {
                    var p = Expression.Parameter(typeof(TType));
                    var property = Expression.PropertyOrField(p, propName);
                    var convert = Expression.Convert(property, typeof(TValue));
                    return Expression.Lambda<Func<TType, TValue>>(convert, p).Compile();
                });
            }

            private static readonly ConcurrentDictionary<int, Func<TType, TValue>> cache = new ConcurrentDictionary<int, Func<TType, TValue>>();
        }

        private static class GetPropValueGeneric<TValue>
        {
            public static Func<object, TValue> GetPropFunc(Type type, string propName)
            {
                var key = InternalHasher.Hash(type, typeof(TValue), propName);
                return cache.GetOrAdd(key, k =>
                {
                    var p = Expression.Parameter(typeof(object));
                    var obj = Expression.Convert(p, type);
                    var property = Expression.PropertyOrField(obj, propName);
                    return Expression.Lambda<Func<object, TValue>>(property, p).Compile();
                });
            }

            private static readonly ConcurrentDictionary<int, Func<object, TValue>> cache = new ConcurrentDictionary<int, Func<object, TValue>>();
        }

        private static class GetPropCache
        {
            public static Func<object, object> GetPropFunc(Type type, string propName)
            {
                var key = InternalHasher.Hash(type, propName);
                if (!cache.TryGetValue(key, out var func))
                {
                    var objParam = Expression.Parameter(typeof(object));
                    var objCast = Expression.Convert(objParam, type);
                    var objAccess = Expression.PropertyOrField(objCast, propName);
                    var valCast = Expression.Convert(objAccess, typeof(object));
                    func = Expression.Lambda<Func<object, object>>(valCast, objParam).Compile();
                    cache.TryAdd(key, func);
                }
                return func;
            }

            private static readonly ConcurrentDictionary<int, Func<object, object>> cache = new ConcurrentDictionary<int, Func<object, object>>();
        }

        /// <summary>
        /// Proxy for <see cref="GetPropValue(object, string)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propName"></param>
        /// <param name="trowIfPropNotExists"></param>
        /// <returns></returns>
        [Obsolete("Use GetPropValue instead!")]
        public static object GetPropertyExprRaw(this object obj, string propName, bool trowIfPropNotExists = true)
            => GetPropValue(obj, propName);

        /// <summary>
        /// Proxy for <see cref="GetPropValue{TValue}(object, string)"/>
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        [Obsolete("Use GetPropValue<T> instead!")]        
        public static TValue GetPropertyExpr<TValue>(this object obj, string propName)
            => GetPropValue<TValue>(obj, propName);

    }
}
