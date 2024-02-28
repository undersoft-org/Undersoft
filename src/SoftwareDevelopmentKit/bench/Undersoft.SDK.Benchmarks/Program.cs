using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Running;
using System;
using Undersoft.SDK.Benchmarks.Series;

namespace Undersoft.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ManualConfig
                .Create(DefaultConfig.Instance)
                .WithOptions(ConfigOptions.JoinSummary)
                .WithOptions(ConfigOptions.DisableLogFile);
            config.AddExporter(CsvMeasurementsExporter.Default);
            config.AddExporter(RPlotExporter.Default);

            var summary = BenchmarkRunner.Run(
                new[]
                {
                    BenchmarkConverter.TypeToBenchmarks(typeof(ConcurrentSetByKeyBenchmark), config),
                    BenchmarkConverter.TypeToBenchmarks(typeof(ConcurrentAddBenchmark), config),
                    BenchmarkConverter.TypeToBenchmarks(typeof(ConcurrentAddOrUpdateBenchmark), config),
                    BenchmarkConverter.TypeToBenchmarks(typeof(ConcurrentGetByKeyBenchmark), config)
                }
            );

            Console.ReadLine();
        }
    }

    // Execute all benchmarks from given assembly example
    //
    //        BenchmarkRunner.Run(
    //        typeof(MyBenchmark).Assembly,
    //        ManualConfig
    //            .Create(DefaultConfig.Instance)
    //            .With(ConfigOptions.JoinSummary)
    //            .With(ConfigOptions.DisableLogFile));
}
