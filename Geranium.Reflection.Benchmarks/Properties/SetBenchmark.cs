using BenchmarkDotNet.Attributes;

namespace Geranium.Reflection.Benchmarks.Properties
{
    public class SetBenchmark
    {
        [Benchmark]
        public void Reflection_SetProperty()
        {
            var obj = new BenchClass(5, "");
            obj.GetType().GetProperty("I")
                .SetValue(obj, 10);
        }

        [Benchmark]
        public void SetPropValue()
        {
            var obj = new BenchClass(5, "");
            obj.SetPropValue("I", 10);
        }

        [Benchmark]
        public void SetPropValueConverted()
        {
            var obj = new BenchClass(5, "");
            obj.SetPropValue(nameof(BenchClass.WrongType), 10F);
        }

        [Benchmark]
        public void SetPropValueEnumParse()
        {
            var obj = new BenchClass(5, "");
            obj.SetPropValue(nameof(BenchClass.Enum), ConsoleColor.Cyan);
        }

        [Benchmark]
        public void SetPropValueNullable_Null()
        {
            var obj = new BenchClass(5, "");
            obj.SetPropValue(nameof(BenchClass.Nullable), null);
        }

        [Benchmark]
        public void SetPropValueNullable_Val()
        {
            var obj = new BenchClass(5, "");
            obj.SetPropValue(nameof(BenchClass.Nullable), 10);
        }
    }
}
