using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Geranium.Reflection
{
    /// <summary>
    /// New expression provided by ExpressionTree, Activator alternative
    /// </summary>
    public static class NewExtensions
    {
        /// <summary>
        /// [Cached][Casted] Instantiate new object through expression tree with FirstOrDefault constructor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object"></param>
        /// <returns></returns>
        public static T New<T>(this object @object)
        {
            if(@object is Type typeObj)
                return typeObj.NewAs<T>();

            return @object.GetType().NewAs<T>();
        }

        /// <summary>
        /// [Cached][Casted] Instantiate new object through expression tree with FirstOrDefault constructor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="argsObj"></param>
        /// <returns></returns>
        public static T New<T>(this Type type, params object[] argsObj)
            => type.New<T>(typeof(T).GetConstructors().FirstOrDefault(), argsObj);

        /// <summary>
        /// [Cached][Casted] Instantiate new object through expression tree with first constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="argsObj"></param>
        /// <returns></returns>
        public static object New(this Type type, params object[] argsObj)
            => type.New<object>(type.GetConstructors().FirstOrDefault(), argsObj);

        /// <summary>
        /// [Cached] Instantiate new object through expression tree with first constructor paara
        /// </summary>
        /// <param name="type"></param>
        /// <param name="onlyParameterLess"></param>
        /// <param name="argsObj"></param>
        /// <returns></returns>
        public static object New(this Type type, bool onlyParameterLess, params object[] argsObj)
        {
            var ctors = type.GetConstructors();
            ConstructorInfo ctor = default;
            if (onlyParameterLess)
            {
                ctor = ctors.FirstOrDefault(c => c.GetParameters().Length == 0);
            }
            else
            {
                ctor = ctors.FirstOrDefault();
            }

            return type.New<object>(ctor, argsObj);
        }

        /// <summary>
        /// [Cached] Instantiate new object through expression tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="ctor"></param>
        /// <param name="argsObj"></param>
        /// <returns></returns>
        public static T New<T>(this Type type, ConstructorInfo ctor, params object[] argsObj)
        {
            if (!___CtorDelegateCache.TryGetValue(type, out var value))
            {
                if (ctor == default)
                    return default;

                ParameterInfo[] par = ctor.GetParameters();
                Expression[] args = new Expression[par.Length];
                ParameterExpression param = Expression.Parameter(typeof(object[]));
                for (int i = 0; i != par.Length; ++i)
                {
                    args[i] = Expression.Convert(Expression.ArrayIndex(param, Expression.Constant(i)), par[i].ParameterType);
                }
                var expression = Expression.Lambda<Func<object[], T>>(
                    Expression.New(ctor, args), param
                );

                value = expression.Compile();
                ___CtorDelegateCache.AddOrUpdate(type, value, (x, y) => value);
            }

            return value.DynamicInvoke(new object[] { argsObj }).As<T>();
        }

        private static ConcurrentDictionary<Type, Delegate> ___CtorDelegateCache = new ConcurrentDictionary<Type, Delegate>();

        /// <summary>
        /// [Cached][Casted] Instantiate new object through expression tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="argsObj"></param>
        /// <returns></returns>
        public static T NewAs<T>(this Type type, params object[] argsObj)
            => (T)type.New<object>(type.GetConstructors().FirstOrDefault(), argsObj);

        /// <summary>
        /// [Cached][Casted] Instantiate new object through expression tree with first constructor AND default value of it's args
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T NewDefaults<T>(this Type type)
        {
            var ctor = type.GetConstructors().FirstOrDefault();

            var args = ctor.GetParameters()
                .Select(x => x.ParameterType.Default())
                .ToArray();

            return (T)type.New<object>(ctor, args);
        }
    }
}