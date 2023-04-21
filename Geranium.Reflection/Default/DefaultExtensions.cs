using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Geranium.Reflection
{
    /// <summary>
    /// "default" expressions extension 
    /// </summary>
    public static class DefaultExtensions
    {
        /// <summary>
        /// Get '<see cref="default"/>' value for type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Default(this Type type)
        {
            if (!___GetDefaultCache.TryGetValue(type, out var value))
            {
                value = Expression.Lambda(Expression.Default(type)).Compile().DynamicInvoke();
                ___GetDefaultCache.AddOrUpdate(type, value, (x, y) => value);
            }

            return value;
        }

        private static readonly ConcurrentDictionary<Type, object> ___GetDefaultCache = new ConcurrentDictionary<Type, object>();

    }
}
