using Geranium.Reflection.Struct;
using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Geranium.Reflection
{
    public static class NewArgsExtensions
    {
        private static ConcurrentDictionary<int, Func<Type, object[], object>> NewArgsCache = new ConcurrentDictionary<int, Func<Type, object[], object>>();

        public static object New(this object obj, params object[] args)
        {
            var type = obj is Type match ? match : obj.GetType();
            switch (args.Length)
            {
                case 0: return Activator.CreateInstance(type);
                case 1:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[1].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 2:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if(!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[2].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 3:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[3].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 4:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[3].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(3)),typeArgs[3]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[4].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 5:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[5].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 6:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType(), args[5].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(5)),typeArgs[5]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[6].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 7:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType(), args[5].GetType(), args[6].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(5)),typeArgs[5]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(6)),typeArgs[6]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[7].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 8:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType(), args[5].GetType(), args[6].GetType(), args[7].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(5)),typeArgs[5]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(6)),typeArgs[6]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(7)),typeArgs[7]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[8].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 9:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType(), args[5].GetType(), args[6].GetType(), args[7].GetType(), args[8].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(5)),typeArgs[5]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(6)),typeArgs[6]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(7)),typeArgs[7]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(8)),typeArgs[8]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[9].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 10:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType(), args[5].GetType(), args[6].GetType(), args[7].GetType(), args[8].GetType(), args[9].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(5)),typeArgs[5]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(6)),typeArgs[6]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(7)),typeArgs[7]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(8)),typeArgs[8]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(9)),typeArgs[9]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[10].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 11:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType(), args[5].GetType(), args[6].GetType(), args[7].GetType(), args[8].GetType(), args[9].GetType(), args[10].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(5)),typeArgs[5]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(6)),typeArgs[6]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(7)),typeArgs[7]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(8)),typeArgs[8]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(9)),typeArgs[9]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(10)),typeArgs[10]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[11].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 12:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType(), args[5].GetType(), args[6].GetType(), args[7].GetType(), args[8].GetType(), args[9].GetType(), args[10].GetType(), args[11].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(5)),typeArgs[5]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(6)),typeArgs[6]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(7)),typeArgs[7]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(8)),typeArgs[8]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(9)),typeArgs[9]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(10)),typeArgs[10]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(11)),typeArgs[11]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[12].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 13:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType(), args[5].GetType(), args[6].GetType(), args[7].GetType(), args[8].GetType(), args[9].GetType(), args[10].GetType(), args[11].GetType(), args[12].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(5)),typeArgs[5]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(6)),typeArgs[6]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(7)),typeArgs[7]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(8)),typeArgs[8]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(9)),typeArgs[9]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(10)),typeArgs[10]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(11)),typeArgs[11]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(12)),typeArgs[12]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[13].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 14:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType(), args[5].GetType(), args[6].GetType(), args[7].GetType(), args[8].GetType(), args[9].GetType(), args[10].GetType(), args[11].GetType(), args[12].GetType(), args[13].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(5)),typeArgs[5]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(6)),typeArgs[6]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(7)),typeArgs[7]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(8)),typeArgs[8]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(9)),typeArgs[9]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(10)),typeArgs[10]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(11)),typeArgs[11]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(12)),typeArgs[12]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(13)),typeArgs[13]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[14].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 15:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType(), args[5].GetType(), args[6].GetType(), args[7].GetType(), args[8].GetType(), args[9].GetType(), args[10].GetType(), args[11].GetType(), args[12].GetType(), args[13].GetType(), args[14].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(5)),typeArgs[5]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(6)),typeArgs[6]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(7)),typeArgs[7]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(8)),typeArgs[8]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(9)),typeArgs[9]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(10)),typeArgs[10]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(11)),typeArgs[11]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(12)),typeArgs[12]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(13)),typeArgs[13]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(14)),typeArgs[14]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[15].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                case 16:
                    {
                        var key = InternalHasher.Hash(type, args);

                        if (!NewArgsCache.TryGetValue(key, out var func))
                        {
                            var typeArgs = new Type[] { args[0].GetType(), args[1].GetType(), args[2].GetType(), args[4].GetType(), args[5].GetType(), args[6].GetType(), args[7].GetType(), args[8].GetType(), args[9].GetType(), args[10].GetType(), args[11].GetType(), args[12].GetType(), args[13].GetType(), args[14].GetType(), args[15].GetType() };
                            var typeParam = Expression.Parameter(typeof(Type));
                            var arrayParam = Expression.Parameter(typeof(object[]));
                            var newParams = new Expression[]
                            {
                                typeParam,
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(0)),typeArgs[0]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(1)),typeArgs[1]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(2)),typeArgs[2]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(4)),typeArgs[4]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(5)),typeArgs[5]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(6)),typeArgs[6]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(7)),typeArgs[7]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(8)),typeArgs[8]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(9)),typeArgs[9]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(10)),typeArgs[10]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(11)),typeArgs[11]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(12)),typeArgs[12]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(13)),typeArgs[13]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(14)),typeArgs[14]),
                                Expression.Convert(Expression.ArrayAccess(arrayParam, Expression.Constant(15)),typeArgs[15]),
                            };
                            var call = Expression.Call(null, NewGenericExtensions.NewMethods[16].MakeGenericMethod(typeArgs), newParams);
                            func = Expression.Lambda<Func<Type, object[], object>>(call, typeParam, arrayParam).Compile();
                            NewArgsCache.TryAdd(key, func);
                        }

                        return func(type, args);
                    }
                default: throw new InsaneException();
            }
        }
    }
}
