using BenchmarkDotNet.Attributes;

namespace Geranium.Reflection.Benchmarks.Properties
{
    public class SetBenchmark
    {
        private static BenchClass obj = new BenchClass(5, "");

        [Benchmark]
        public void Reflection_SetProperty()
        {
            obj.GetType().GetProperty("I")
                .SetValue(obj, 10);
        }

        [Benchmark]
        public void SetPropValue()
        {
            obj.SetPropValue("I", 10);
        }

        [Benchmark]
        public void SetPropValueConverted()
        {
            obj.SetPropValue(nameof(BenchClass.WrongType), 10F);
        }

        [Benchmark]
        public void SetPropValueEnumParse()
        {
            obj.SetPropValue(nameof(BenchClass.Enum), ConsoleColor.Cyan);
        }

        [Benchmark]
        public void SetPropValueNullable_Null()
        {
            obj.SetPropValue(nameof(BenchClass.Nullable), null);
        }

        [Benchmark]
        public void SetPropValueNullable_Val()
        {
            obj.SetPropValue(nameof(BenchClass.Nullable), 10);
        }
    }
}
