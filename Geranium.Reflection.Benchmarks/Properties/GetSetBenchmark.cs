using BenchmarkDotNet.Attributes;
using System.Linq.Expressions;

namespace Geranium.Reflection.Benchmarks.Ctor
{
    public class GetSetBenchmark
    {
        [Benchmark]
        public object GetPropertyValueExpr()
        {
            var obj = new BenchClass(5,"");
            return GetPropFunc()(obj);
        }

        private static Func<BenchClass, int> func;
        public static Func<BenchClass, int> GetPropFunc()
        {
            if (func == null)
            {
                List<int> a;
                var p = Expression.Parameter(typeof(BenchClass));
                func = Expression.Lambda<Func<BenchClass, int>>(Expression.Convert(Expression.PropertyOrField(p, "I"),typeof(int)), p).Compile();
            }

            return func;
        }

        [Benchmark]
        public object GetPropertyValue()
        {
            var obj = new BenchClass(5, "");
            return obj.GetType().GetProperty("I").GetValue(obj);
        }

        //[Benchmark]
        //public void SetPropertyExpr()
        //{
        //    var obj = new BenchClass(5, "");
        //    obj.SetPropertyExpr("I", 10);
        //}

        //[Benchmark]
        //public void SetProperty()
        //{
        //    var obj = new BenchClass(5, "");
        //    obj.GetType().GetPropertyValue("I")
        //        .SetValue(obj, 10);
        //}
    }
}