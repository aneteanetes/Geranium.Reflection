using BenchmarkDotNet.Attributes;
using System.Linq.Expressions;

namespace Geranium.Reflection.Benchmarks.Properties
{
    public class GetBenchmark
    {
        private static BenchClass obj = new BenchClass(5, "");

        [Benchmark]
        public object PreKnowedTypesExpr()
        {
            return YoboBoba<BenchClass, int>.GetPropFunc()(obj);
        }

        [Benchmark]
        public object Reflection_GetProperty()
        {
            return obj.GetType().GetProperty("I").GetValue(obj);
        }

        [Benchmark]
        public object GetPropValue_objects()
        {
            return obj.GetPropValue(nameof(BenchClass.I));
        }

        [Benchmark]
        public object GetPropValue_ReturnTypeKnown()
        {
            return obj.GetPropValue<int>(nameof(BenchClass.I));
        }

        [Benchmark]
        public object GetPropValue_HostTypeAndReturnTypeKnown()
        {
            return obj.GetPropValue<BenchClass, int>(nameof(BenchClass.I));
        }

        private static class YoboBoba<T1, T2>
        {
            private static Func<T1, T2> func;
            public static Func<T1, T2> GetPropFunc()
            {
                if (func == null)
                {
                    var p = Expression.Parameter(typeof(T1));
                    var property = Expression.PropertyOrField(p, "I");
                    var convert = Expression.Convert(property, typeof(T2));
                    func = Expression.Lambda<Func<T1, T2>>(convert, p).Compile();
                }

                return func;
            }
        }
    }
}