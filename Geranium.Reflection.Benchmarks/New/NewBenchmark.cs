using BenchmarkDotNet.Attributes;

namespace Geranium.Reflection.Benchmarks.New
{
    public class NewBenchmark
    {
        [Benchmark]
        public object New()
        {
            return typeof(BenchClass).New();
        }

        [Benchmark]
        public object New1()
        {
            return typeof(BenchClass).New(5);
        }

        [Benchmark]
        public object New2()
        {
            return typeof(BenchClass).New(5,"5");
        }

        [Benchmark]
        public object New3()
        {
            return typeof(BenchClass).New(5, "5", new object());
        }

        [Benchmark]
        public object Newargs()
        {
            return NewArgsExtensions.New(typeof(BenchClass));
        }

        [Benchmark]
        public object New1args()
        {
            return NewArgsExtensions.New(typeof(BenchClass),5);
        }

        [Benchmark]
        public object New2args()
        {
            return NewArgsExtensions.New(typeof(BenchClass), 5,"5");
        }

        [Benchmark]
        public object New3args()
        {
            return NewArgsExtensions.New(typeof(BenchClass), 5, "5", new object());
        }

        [Benchmark()]
        public object Activator()
        {
            return System.Activator.CreateInstance(typeof(BenchClass));
        }

        [Benchmark()]
        public object Activator1()
        {
            return System.Activator.CreateInstance(typeof(BenchClass),5);
        }

        [Benchmark()]
        public object Activator2()
        {
            return System.Activator.CreateInstance(typeof(BenchClass),5,"5");
        }

        [Benchmark()]
        public object Activator3()
        {
            return System.Activator.CreateInstance(typeof(BenchClass),5,"5", new object());
        }
    }
}
