using Geranium.Reflection.Struct;
using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace Geranium.Reflection
{
    /// <summary>
    /// Extension methods for setting valueParam of propInfo by <see cref="Expression"/>
    /// </summary>
    public static class SetExtensions
    {
        /// <summary>
        /// [Cached] Set object property value by ExpressionTrees
        /// </summary>
        /// <param name="obj">target object</param>
        /// <param name="propName">object property</param>
        /// <param name="propValue">value</param>
        /// <exception cref="NotSupportedException">Property must be writeable</exception>
        public static void SetPropValue(this object obj, string propName, object propValue)
        {
            var type = obj.GetType();
            var key = InternalHasher.Hash(type, propName);

            var compiled = cache.GetOrAdd(key, k =>
            {
                var objParam = Expression.Parameter(typeof(object));
                var valParam = Expression.Parameter(typeof(object));

                var objT = Expression.Convert(objParam, type);

                var objProp = Expression.Property(objT, propName);

                if (objProp.Member is PropertyInfo property && property.CanWrite)
                {
                    var propType = property.PropertyType;
                    var valT = Expression.Convert(valParam, propType);
                    var assign = Expression.Assign(objProp, valT);

                    var func = Expression.Lambda<Action<object, object>>(assign, objParam, valParam).Compile();

                    if (propType.IsEnum)
                    {
                        return (o, val) =>
                        {
                            var newVal = Enum.Parse(propType, val.ToString());
                            func(o, newVal);
                        };
                    }

                    if (!propType.IsNullable())
                    {
                        var valType = propValue == null ? null : propValue.GetType();
                        if (propType!=valType)
                        {
                            return (o, val) =>
                            {
                                var newVal = Convert.ChangeType(val, propType);
                                func(o, newVal);
                            };
                        }
                    }

                    return func;
                }                
                
                throw new NotSupportedException($"Property of name {propName} can't be set!");
            });

            compiled(obj,propValue);
        }

        private static ConcurrentDictionary<int, Action<object, object>> cache = new ConcurrentDictionary<int, Action<object, object>>();
    }
}