using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Geranium.Reflection
{
    /// <summary>
    /// Extension methods for call methods by <see cref="Expression"/>
    /// </summary>
    public static class CallExtensions
    {
        /// <summary>
        /// Call object method and return result
        /// </summary>
        /// <param name="object"></param>
        /// <param name="method">Method name</param>
        /// <param name="argsObj">Method args</param>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static object Call(this object @object, string method, params object[] argsObj)
        {
            var methodInfo = @object.GetType().GetMethods().FirstOrDefault(m => m.Name == method);
            if (methodInfo == default)
            {
                methodInfo = @object.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(m => m.Name == method);
            }
            if (methodInfo != default)
            {
                if (methodInfo.GetParameters().IsEmpty())
                    return Expression.Lambda(Expression.Call(Expression.Constant(@object), methodInfo)).Compile().DynamicInvoke(argsObj);

                var from = Expression.Constant(@object);
                var @params = argsObj.Select(a => Expression.Parameter(a.GetType())).ToArray();
                var methodCall = Expression.Call(@from, methodInfo, @params);

                return Expression.Lambda(methodCall, @params).Compile().DynamicInvoke(argsObj);
            }

            return default;
        }

        /// <summary>
        /// Call object method with strong typed args
        /// </summary>
        /// <param name="object"></param>
        /// <param name="method">Method name</param>
        /// <param name="paramTypes">Method args types</param>
        /// <param name="argsObj">Method args values</param>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static object Call(this object @object, string method, Type[] paramTypes, params object[] argsObj)
        {
            var methodInfo = @object.GetType().GetMethods().FirstOrDefault(m => m.Name == method);
            if (methodInfo == default)
            {
                methodInfo = @object.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(m => m.Name == method);
            }
            if (methodInfo != default)
            {
                if (methodInfo.GetParameters().IsEmpty())
                    return Expression.Lambda(Expression.Call(Expression.Constant(@object), methodInfo)).Compile().DynamicInvoke(argsObj);

                var from = Expression.Constant(@object);
                var @params = paramTypes.Select(Expression.Parameter).ToArray();
                var methodCall = Expression.Call(@from, methodInfo, @params);

                return Expression.Lambda(methodCall, @params).Compile().DynamicInvoke(argsObj);
            }

            return default;
        }

        /// <summary>
        /// [Static] Call type static method
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="method">Method name</param>
        /// <param name="argsObj">Method args</param>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static object CallStatic(this Type sourceType, string method, params object[] argsObj)
        {
            var methodInfo = sourceType.GetMethods().FirstOrDefault(m => m.Name == method);

            if (methodInfo == default)
            {
                methodInfo = sourceType
                    .GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
                    .FirstOrDefault(m => m.Name == method);
            }

            if (methodInfo != default)
            {
                var @params = argsObj.Select(a => Expression.Parameter(a.GetType())).ToArray();
                if (methodInfo.ReturnType != typeof(void))
                {
                    {
                        return Expression.Lambda(Expression.Call(methodInfo, @params)).Compile().DynamicInvoke(argsObj);
                    }
                }
                else
                {
                    var expCall = Expression.Call(methodInfo, @params);
                    Expression.Lambda(expCall).Compile().DynamicInvoke(argsObj);
                }
            }

            return false;
        }

        /// <summary>
        /// [Generic] Call object generic method
        /// </summary>
        /// <param name="object"></param>
        /// <param name="method">Method name</param>
        /// <param name="generics">Method generic type args</param>
        /// <param name="argsObj">Method args</param>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static object CallGeneric(this object @object, string method, Type[] generics, params object[] argsObj)
        {
            var methodInfo = @object.GetType()
                .GetMethods()
                .Where(x => x.GetParameters().Length == argsObj.Length)
                .LastOrDefault(m => m.Name == method && m.IsGenericMethod);

            if (methodInfo == default)
            {
                methodInfo = @object.GetType()
                    .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(x => x.GetParameters().Length == argsObj.Length)
                    .LastOrDefault(m => m.Name == method && m.IsGenericMethod);
            }

            if (methodInfo != default)
            {
                methodInfo = methodInfo.MakeGenericMethod(generics);
                var @params = argsObj.Select(a => Expression.Parameter(a.GetType())).ToArray();

                var methodCallExpression = Expression.Call(Expression.Constant(@object), methodInfo, @params);

                return Expression.Lambda(methodCallExpression, @params).Compile().DynamicInvoke(argsObj);
            }

            return default;
        }

        /// <summary>
        /// [Generic] Call object generic method with typed result
        /// </summary>
        /// <param name="object"></param>
        /// <param name="method">Method name</param>
        /// <param name="generics">Method generic type args</param>
        /// <param name="argsObj">Method args</param>
        /// <typeparam name="TResult">return type</typeparam>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static TResult CallGeneric<TResult>(this object @object, string method, Type[] generics, params object[] argsObj) =>
            @object.CallGeneric(method, generics, argsObj).As<TResult>();

        /// <summary>
        /// Call object method with typed result AND default value if method does not exists
        /// </summary>
        /// <param name="object"></param>
        /// <param name="method">Method name</param>
        /// <param name="default">default value</param>
        /// <param name="argsObj">Method args</param>
        /// <typeparam name="TResult">return type</typeparam>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static TResult Call<TResult>(this object @object, string method, TResult @default, params object[] argsObj)
        {
            var methodInfo = @object.GetType().GetMethods().FirstOrDefault(m => m.Name == method && m.GetParameters().Length == argsObj.Length);
            if (methodInfo == default)
            {
                methodInfo = @object.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(m => m.Name == method);
            }
            if (methodInfo != default)
            {
                var from = Expression.Constant(@object);
                var @params = argsObj.Select(a => Expression.Parameter(a.GetType())).ToArray();
                var methodCall = Expression.Call(from, methodInfo, @params);
                return Expression.Lambda(methodCall, @params).Compile().DynamicInvoke(argsObj).As<TResult>();
            }

            return @default;
        }

        /// <summary>
        /// Call method from Type or object
        /// </summary>
        /// <param name="object">Type or object</param>
        /// <param name="methodInfo"></param>
        /// <param name="argsObj">Method args</param>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static object CallObj(this object @object, MethodInfo methodInfo, params object[] argsObj)
        {
            if (methodInfo != default)
            {
                if (@object is Type type)
                {
                    var @params = argsObj.Select(a => Expression.Parameter(a.GetType())).ToArray();
                    var methodCall = Expression.Call(methodInfo, @params);
                    Expression.Lambda(methodCall, @params).Compile().DynamicInvoke(argsObj);
                }
                else
                {
                    var from = Expression.Constant(@object);
                    var @params = argsObj.Select(a => Expression.Parameter(a.GetType())).ToArray();
                    var methodCall = Expression.Call(from, methodInfo, @params);
                    return Expression.Lambda(methodCall, @params).Compile().DynamicInvoke(argsObj);
                }
            }

            return default;
        }

        /// <summary>
        /// [Specific] Call specific Type method from object (e.g. ignore overrides, explicit impl, etc)
        /// </summary>
        /// <param name="object"></param>
        /// <param name="method">Method name</param>
        /// <param name="default">default value if method not exists</param>
        /// <param name="argsObj">Method args</param>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static TResult Call<TResult, TFrom>(this object @object, string method, TResult @default, params object[] argsObj)
        {
            var methodInfo = typeof(TFrom).GetMethods().FirstOrDefault(m => m.Name == method);
            if (methodInfo == default)
            {
                methodInfo = typeof(TFrom).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(m => m.Name == method);
            }
            if (methodInfo != default)
            {
                var from = Expression.Constant(@object);
                var @params = argsObj.Select(a => Expression.Parameter(a.GetType()));
                var methodCall = Expression.Call(from, methodInfo, @params);
                return Expression.Lambda(methodCall, @params).Compile().DynamicInvoke(argsObj).As<TResult>();
            }

            return @default;
        }

        /// <summary>
        /// [Extension][Generic] Call extension method with generic args (first generic type from @object)
        /// </summary>
        /// <param name="object">This object type will use as 0st generic args</param>
        /// <param name="method">Method name</param>
        /// <param name="sourceType">Extension type</param>
        /// <param name="generic">generic args types</param>
        /// <param name="argsObj">Method args</param>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static object CallGenericExtension(this object @object, string method, Type sourceType, Type[] generic, params object[] argsObj)
        {
            var methodInfo = sourceType.GetMethods().FirstOrDefault(m => m.Name == method && m.GetGenericArguments().Length == generic.Length /*&& m.GetParameters().Length == argsObj.Length + 1*/);
            if (methodInfo != default)
            {
                var combinedArgs = new List<object> { @object };
                combinedArgs.AddRange(argsObj);
                methodInfo = methodInfo.MakeGenericMethod(generic);
                var @params = combinedArgs.Select(a => Expression.Parameter(a.GetType())).ToArray();
                var methodCall = Expression.Call(null, methodInfo, @params);
                return Expression.Lambda(methodCall, @params).Compile().DynamicInvoke(combinedArgs.ToArray());
            }

            return default;
        }

        /// <summary>
        /// [Extension] Call extension method (first generic type from @object)
        /// </summary>
        /// <param name="object">This object type will use as 0st generic args</param>
        /// <param name="method">Method name</param>
        /// <param name="sourceType">Extension type</param>
        /// <param name="argsObj">Method args</param>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static object CallExtension(this object @object, string method, Type sourceType, params object[] argsObj)
        {
            var methodInfo = sourceType.GetMethods().FirstOrDefault(m => m.Name == method);
            if (methodInfo != default)
            {
                var combinedArgs = new List<object> { @object };
                combinedArgs.AddRange(argsObj);
                var @params = combinedArgs.Select(a => Expression.Parameter(a.GetType())).ToArray();
                var methodCall = Expression.Call(null, methodInfo, @params);
                return Expression.Lambda(methodCall, @params).Compile().DynamicInvoke(combinedArgs.ToArray());
            }

            return default;
        }

        /// <summary> 
        /// [Overload][Cast] Call extension method by <see cref="CallExtension(object, string, Type, object[])"/> and cast by <see cref="IsAsExtensions.As{T}(object)"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object"></param>
        /// <param name="method">Method name</param>
        /// <param name="sourceType">Extension type</param>
        /// <param name="argsObj">Method args</param>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static T CallExtension<T>(this object @object, string method, Type sourceType, params object[] argsObj) =>
            @object.CallExtension(method, sourceType, argsObj).As<T>();

        /// <summary>
        /// [Overload][Cast] Call extension method by <see cref="CallExtension(object, string, Type, object[])"/> and cast by <see cref="IsAsExtensions.As{T}(object)"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object"></param>
        /// <param name="method">Method name</param>
        /// <param name="sourceType">Extension type</param>
        /// <param name="generic">generic args type</param>
        /// <param name="argsObj">Method args</param>
        /// <returns>Method result, <see cref="default"/> if <see cref="void"/></returns>
        public static T CallGenericExtension<T>(this object @object, string method, Type sourceType, Type[] generic, params object[] argsObj) =>
            @object.CallGenericExtension(method, sourceType, generic, argsObj).As<T>();
    }
}
