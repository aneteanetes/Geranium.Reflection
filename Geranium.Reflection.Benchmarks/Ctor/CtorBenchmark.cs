using BenchmarkDotNet.Attributes;

namespace Geranium.Reflection.Benchmarks.Ctor
{
    public class CtorBenchmark
    {
        [Benchmark]
        public object NewExprEmpty()
        {
            return typeof(BenchClass).New();
        }

        [Benchmark]
        public object NewaExprEmpty()
        {
            return typeof(BenchClass).Newa();
        }

        [Benchmark]
        public object NewActivatorEmpty()
        {
            return Activator.CreateInstance(typeof(BenchClass));
        }

        [Benchmark]
        public object NewExpr3()
        {
            return typeof(BenchClass).New(0,"0",new object());
        }

        [Benchmark]
        public object NewActivator3()
        {
            return Activator.CreateInstance(typeof(BenchClass), 0, "0", new object());
        }
    }
}