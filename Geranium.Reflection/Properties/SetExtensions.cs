using Geranium.Reflection.Struct;
using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace Geranium.Reflection
{
    /// <summary>
    /// Extension methods for setting value of property by <see cref="Expression"/>
    /// </summary>
    public static class SetExtensions
    {
        /// <summary>
        /// [Overload] Set property value by <see cref="SetPropertyExprType"/> 
        /// with <see cref="Convert.ChangeType(object?, Type)"/> for usual properties, 
        /// <see cref="Enum.Parse(Type, string)"/> for enums, 
        /// and <see cref="PropertyInfo.SetValue(object?, object?)"/> for nullable,
        /// <see cref="Exception"/> is not throwing
        /// </summary>
        /// <param name="object"></param>
        /// <param name="propName"></param>
        /// <param name="propValue"></param>
        /// <returns></returns>
        public static bool SetPropertyExprConverted(this object @object, string propName, object propValue)
            => @object.SetPropertyExprConvertedDebug(propName, propValue, out var _);

        /// <summary>
        /// Set property value by <see cref="SetPropertyExprType"/> 
        /// with <see cref="Convert.ChangeType(object?, Type)"/> for usual properties, 
        /// <see cref="Enum.Parse(Type, string)"/> for enums, 
        /// and <see cref="PropertyInfo.SetValue(object?, object?)"/> for nullable,
        /// <see cref="Exception"/> is not throwing
        /// </summary>
        /// <param name="object"></param>
        /// <param name="propName"></param>
        /// <param name="propValue"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static bool SetPropertyExprConvertedDebug(this object @object, string propName, object propValue, out Exception exception)
        {
            exception = null;
            var prop = @object.GetType().GetProperty(propName);

            var propType = prop.PropertyType;
            try
            {
                if (propType.IsNullable())
                {
                    try
                    {
                        prop.SetValue(@object, propValue);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        return false;
                    }
                }

                if (propType.IsEnum)
                {
                    var enumValue = Enum.Parse(propType, propValue.ToString());
                    @object.SetPropertyExprType(propName, enumValue, propType);
                }
                else
                {
                    var newValue = Convert.ChangeType(propValue, propType);
                    @object.SetPropertyExprType(propName, newValue, propType);
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
            return true;
        }

        /// <summary>
        /// [Overload] Set property value by <see cref="SetPropertyExprType"/>, passing typeof(T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object"></param>
        /// <param name="propName"></param>
        /// <param name="propValue"></param>
        public static void SetPropertyExpr<T>(this object @object, string propName, T propValue)
            => @object.SetPropertyExprType(propName, propValue, typeof(T));

        /// <summary>
        /// [Cached] Set property value by <see cref="Expression.Assign(Expression, Expression)"/>
        /// </summary>
        /// <param name="object"></param>
        /// <param name="propName"></param>
        /// <param name="propValue"></param>
        /// <param name="valueType"></param>
        public static void SetPropertyExprType(this object @object, string propName, object propValue, Type valueType)
        {
            var key = new CompositeTypeKey<string>()
            {
                Owner = @object.GetType(),
                Value = propName
            };

            if (!___SetBackingFieldValueExpressionCache.TryGetValue(key, out var value))
            {
                try
                {
                    var pType = Expression.Parameter(@object.GetType());
                    var p = Expression.Parameter(valueType);

                    var propExpr = Expression.Property(pType, propName);
                    if (propExpr.Member is PropertyInfo property && !property.CanWrite)
                        return;

                    value = Expression.Lambda(Expression.Assign(propExpr, p), pType, p)
                        .Compile();
                }
                catch { }

                ___SetBackingFieldValueExpressionCache.AddOrUpdate(key, value, (k, v) => value);
            }

            value?.DynamicInvoke(@object, propValue);
        }

        private static readonly ConcurrentDictionary<CompositeTypeKey<string>, Delegate> ___SetBackingFieldValueExpressionCache = new ConcurrentDictionary<CompositeTypeKey<string>, Delegate>();
    }
}