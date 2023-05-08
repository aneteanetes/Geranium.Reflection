using BenchmarkDotNet.Attributes;
using Geranium.Reflection.Struct;

namespace Geranium.Reflection.Benchmarks.Hash
{
    public class HashBenchmark
    {
        [Benchmark]
        public int YobaHash()
        {
            return InternalHasher.Hash(typeof(BenchClass), typeof(int), "I");
        }
    }
}
