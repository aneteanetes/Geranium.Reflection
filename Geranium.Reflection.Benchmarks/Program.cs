using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Geranium.Reflection;
using Geranium.Reflection.Benchmarks;
using Geranium.Reflection.Benchmarks.Properties;

ManualConfig config = ManualConfig.Create(DefaultConfig.Instance);
config.AddJob(Job.Default.WithRuntime(CoreRuntime.Core60));

config.AddDiagnoser(MemoryDiagnoser.Default);

var obj = new BenchClass(5, "");
//Console.WriteLine(obj.GetPropValue<int>(nameof(BenchClass.I)));
//Console.WriteLine(obj.GetPropValue<int>(nameof(BenchClass.I)));
//Console.WriteLine(obj.GetPropValue(nameof(BenchClass.I)));
//Console.WriteLine(obj.GetPropValue(nameof(BenchClass.I)));
//Console.WriteLine(obj.GetPropValue(nameof(BenchClass.I)));

obj.SetPropValue("I", 10);
Console.WriteLine("set I 10");
obj.SetPropValue("I", 10);
Console.WriteLine("set I 10");

obj.SetPropValue(nameof(BenchClass.WrongType), 10F);
Console.WriteLine("set wrong 10");

obj.SetPropValue(nameof(BenchClass.Enum), ConsoleColor.Magenta);
Console.WriteLine("set console color");

obj.Nullable=1;
obj.SetPropValue(nameof(BenchClass.Nullable), null);
Console.WriteLine("set nullable null");
obj.SetPropValue(nameof(BenchClass.Nullable), 2);
Console.WriteLine("set nullable 2");

BenchmarkRunner.Run<SetBenchmark>(config);