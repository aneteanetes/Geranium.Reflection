using BenchmarkDotNet.Attributes;

namespace Geranium.Reflection.Benchmarks.Ctor
{
    public class GetSetBenchmark
    {
        [Benchmark]
        public object GetPropertyExpr()
        {
            var obj = new BenchClass(5,"");
            return obj.GetPropertyExprRaw("I");
        }

        [Benchmark]
        public object GetProperty()
        {
            var obj = new BenchClass(5, "");
            return obj.GetType().GetProperty("I").GetValue(obj);
        }

        [Benchmark]
        public void SetPropertyExpr()
        {
            var obj = new BenchClass(5, "");
            obj.SetPropertyExpr("I", 10);
        }

        [Benchmark]
        public void SetProperty()
        {
            var obj = new BenchClass(5, "");
            obj.GetType().GetProperty("I")
                .SetValue(obj, 10);
        }
    }
}