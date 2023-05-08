using BenchmarkDotNet.Attributes;
using System.Linq.Expressions;

namespace Geranium.Reflection.Benchmarks.Ctor
{
    public class GetBenchmark
    {
        [Benchmark]
        public object PreKnowedTypesExpr()
        {
            var obj = new BenchClass(5,"");
            return YoboBoba<BenchClass,int>.GetPropFunc()(obj);
        }

        [Benchmark]
        public object Reflection_GetProperty()
        {
            var obj = new BenchClass(5, "");
            return obj.GetType().GetProperty("I").GetValue(obj);
        }

        [Benchmark]
        public object GetPropValue_objects()
        {
            var obj = new BenchClass(5, "");
            return obj.GetPropValue(nameof(BenchClass.I));
        }

        [Benchmark]
        public object GetPropValue_ReturnTypeKnown()
        {
            var obj = new BenchClass(5, "");
            return obj.GetPropValue<int>(nameof(BenchClass.I));
        }

        [Benchmark]
        public object GetPropValue_HostTypeAndReturnTypeKnown()
        {
            var obj = new BenchClass(5, "");
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