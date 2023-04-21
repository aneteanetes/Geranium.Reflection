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
        /// [Cached] Gets property value by <see cref="Expression.PropertyOrField(Expression, string)"/> and returns as <see cref="Object"/>
        /// </summary>
        /// <param name="object"></param>
        /// <param name="propName"></param>
        /// <param name="trowIfPropNotExists"></param>
        /// <returns></returns>
        public static object GetPropertyExprRaw(this object @object, string propName, bool trowIfPropNotExists = true)
        {
            var type = @object.GetType();
            var key = propName + type.AssemblyQualifiedName;

            if (!___GetBackginFieldValueExpressionCache.TryGetValue(key, out var value))
            {
                var p = Expression.Parameter(type);
                try
                {
                    value = Expression.Lambda(Expression.PropertyOrField(p, propName), p).Compile();

                    ___GetBackginFieldValueExpressionCache.AddOrUpdate(key, value, (k, v) => value);
                }
                catch
                {
                    if (trowIfPropNotExists)
                        throw;

                    return null;
                }
            }

            return value.DynamicInvoke(@object);
        }

        /// <summary>
        /// [Cast][Overload] Gets by <see cref="GetPropertyExprRaw(object, string, bool)"/> and cast by <see cref="IsAsExtensions.As{T}(object, bool)"/>
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="object"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public static TValue GetPropertyExpr<TValue>(this object @object, string propName)
            => @object.GetPropertyExprRaw(propName).As<TValue>(false);

        private static readonly ConcurrentDictionary<string, Delegate> ___GetBackginFieldValueExpressionCache = new ConcurrentDictionary<string, Delegate>();

    }
}
