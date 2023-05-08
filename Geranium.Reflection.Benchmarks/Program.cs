using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Geranium.Reflection.Benchmarks.New;

ManualConfig config = ManualConfig.Create(DefaultConfig.Instance);
config.AddJob(Job.Default.WithRuntime(CoreRuntime.Core60));

config.AddDiagnoser(MemoryDiagnoser.Default);

BenchmarkRunner.Run<NewBenchmark>(config);