using Geranium.Reflection.Struct;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;

namespace Geranium.Reflection
{
    internal static class NewGenericCache<T1>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, object>> cache = new ConcurrentDictionary<Type, Func<T1, object>>();
        public static Func<T1,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1,
                object>>(t, new Type[] { typeof(T1)
                }));
    }

    internal static class NewGenericCache<T1, T2>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, object>>();
        public static Func<T1, T2,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2,
                object>>(t, new Type[] { typeof(T1),typeof(T2)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, object>>();
        public static Func<T1, T2, T3,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, object>>();
        public static Func<T1, T2, T3, T4,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, object>>();
        public static Func<T1, T2, T3, T4, T5,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5, T6>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, object>>();
        public static Func<T1, T2, T3, T4, T5, T6,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5, T6,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5),typeof(T6)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5, T6, T7>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, object>>();
        public static Func<T1, T2, T3, T4, T5, T6, T7,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5, T6, T7,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5),typeof(T6),typeof(T7)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, object>>();
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5, T6, T7, T8,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5),typeof(T6),typeof(T7),typeof(T8)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>>();
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5),typeof(T6),typeof(T7),typeof(T8),typeof(T9)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>>();
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5),typeof(T6),typeof(T7),typeof(T8),typeof(T9),typeof(T10)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>>();
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5),typeof(T6),typeof(T7),typeof(T8),typeof(T9),typeof(T10),typeof(T11)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>>();
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5),typeof(T6),typeof(T7),typeof(T8),typeof(T9),typeof(T10),typeof(T11),typeof(T12)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>>();
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5),typeof(T6),typeof(T7),typeof(T8),typeof(T9),typeof(T10),typeof(T11),typeof(T12),typeof(T13)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>>();
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5),typeof(T6),typeof(T7),typeof(T8),typeof(T9),typeof(T10),typeof(T11),typeof(T12),typeof(T13),typeof(T14)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>>();
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5),typeof(T6),typeof(T7),typeof(T8),typeof(T9),typeof(T10),typeof(T11),typeof(T12),typeof(T13),typeof(T14),typeof(T15)
                }));
    }

    internal static class NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        private static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, object>> cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, object>>();
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16,
            object> GetFunc(Type type) => cache.GetOrAdd(type, t =>
            ExpressionCompiling.GetFactoryFor<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16,
                object>>(t, new Type[] { typeof(T1),typeof(T2),typeof(T3),typeof(T4),typeof(T5),typeof(T6),typeof(T7),typeof(T8),typeof(T9),typeof(T10),typeof(T11),typeof(T12),typeof(T13),typeof(T14),typeof(T15),typeof(T16)
                }));
    }

    internal static class ExpressionCompiling
    {
        public static T GetFactoryFor<T>(Type type, Type[] args = null)
        {
            var ctor = type.GetConstructor(args);

            var exprArgs = GetParams(args);

            var @new = Expression.New(ctor, exprArgs);

            var lambda = Expression.Lambda<T>(@new, exprArgs);

            return lambda.Compile();
        }

        private static ParameterExpression[] GetParams(Type[] args)
        {
#pragma warning disable IDE0066 // Convert switch statement to expression 
            // net46,netstandard, etc...
            switch (args.Length)
            {
                case 0: return Array.Empty<ParameterExpression>();
                case 1: return new ParameterExpression[] { Expression.Parameter(args[0]) };
                case 2: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]) };
                case 3: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]) };
                case 4: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]) };
                case 5: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]) };
                case 6: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]), Expression.Parameter(args[5]) };
                case 7: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]), Expression.Parameter(args[5]), Expression.Parameter(args[6]) };
                case 8: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]), Expression.Parameter(args[5]), Expression.Parameter(args[6]), Expression.Parameter(args[7]) };
                case 9: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]), Expression.Parameter(args[5]), Expression.Parameter(args[6]), Expression.Parameter(args[7]), Expression.Parameter(args[8]) };
                case 10: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]), Expression.Parameter(args[5]), Expression.Parameter(args[6]), Expression.Parameter(args[7]), Expression.Parameter(args[8]), Expression.Parameter(args[9]) };
                case 11: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]), Expression.Parameter(args[5]), Expression.Parameter(args[6]), Expression.Parameter(args[7]), Expression.Parameter(args[8]), Expression.Parameter(args[9]), Expression.Parameter(args[10]) };
                case 12: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]), Expression.Parameter(args[5]), Expression.Parameter(args[6]), Expression.Parameter(args[7]), Expression.Parameter(args[8]), Expression.Parameter(args[9]), Expression.Parameter(args[10]), Expression.Parameter(args[11]) };
                case 13: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]), Expression.Parameter(args[5]), Expression.Parameter(args[6]), Expression.Parameter(args[7]), Expression.Parameter(args[8]), Expression.Parameter(args[9]), Expression.Parameter(args[10]), Expression.Parameter(args[11]), Expression.Parameter(args[12]) };
                case 14: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]), Expression.Parameter(args[5]), Expression.Parameter(args[6]), Expression.Parameter(args[7]), Expression.Parameter(args[8]), Expression.Parameter(args[9]), Expression.Parameter(args[10]), Expression.Parameter(args[11]), Expression.Parameter(args[12]), Expression.Parameter(args[13]) };
                case 15: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]), Expression.Parameter(args[5]), Expression.Parameter(args[6]), Expression.Parameter(args[7]), Expression.Parameter(args[8]), Expression.Parameter(args[9]), Expression.Parameter(args[10]), Expression.Parameter(args[11]), Expression.Parameter(args[12]), Expression.Parameter(args[13]), Expression.Parameter(args[14]) };
                case 16: return new ParameterExpression[] { Expression.Parameter(args[0]), Expression.Parameter(args[1]), Expression.Parameter(args[2]), Expression.Parameter(args[3]), Expression.Parameter(args[4]), Expression.Parameter(args[5]), Expression.Parameter(args[6]), Expression.Parameter(args[7]), Expression.Parameter(args[8]), Expression.Parameter(args[9]), Expression.Parameter(args[10]), Expression.Parameter(args[11]), Expression.Parameter(args[12]), Expression.Parameter(args[13]), Expression.Parameter(args[14]), Expression.Parameter(args[15]) };
                default: throw new InsaneException();
            };
#pragma warning restore IDE0066 // Convert switch statement to expression
        }
    }
}
