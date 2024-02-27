using System.Series.Tests;

namespace Undersoft.SDK.Benchmarks.Series
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Engines;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    [RankColumn]
    [RPlotExporter]
    [SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
    public class DictionaryBenchmark
    {
        public static object holder = new object();
        public static int threadCount = 0;
        public Task[] tasks = new Task[10];
        public BenchmarkDictionaryHelper dhelper = new BenchmarkDictionaryHelper();
        public BenchmarkHelper chelper = new BenchmarkHelper();
        public IList<KeyValuePair<object, string>> collection;

        public DictionaryBenchmark()
        {
            Setup();
        }

        [GlobalSetup]
        public void Setup()
        {
            dhelper = new BenchmarkDictionaryHelper();

            DefaultTraceListener Logfile = new DefaultTraceListener();
            Logfile.Name = "Logfile";
            Trace.Listeners.Add(Logfile);
            Logfile.LogFileName = $"Catalog64_{DateTime.Now.ToFileTime().ToString()}_Test.log";

            collection = dhelper.identifierKeyTestCollection;
        }

        [IterationSetup]
        public void Prepare()
        {
            dhelper.registry = new Dictionary<string, string>();
            foreach (var item in collection)
            {
                dhelper.registry.TryAdd(item.Key.ToString(), item.Value);
            }
        }

        [Benchmark]
        public void Dictionary_Add_Test()
        {
            dhelper.registry = new Dictionary<string, string>();
            dhelper.Add_Test(collection, dhelper.registry);
        }

        [Benchmark]
        public void Dictionary_GetByKey_Test()
        {
            dhelper.GetByKey_Test(collection, dhelper.registry);
        }

        [Benchmark]
        public void Dictionary_ContainsKey_Test()
        {
            dhelper.ContainsKey_Test(collection, dhelper.registry);
        }

        [Benchmark]
        public void Dictionary_Contains_Test()
        {
            dhelper.Contains_Test(collection, dhelper.registry);
        }

        [Benchmark]
        public void Dictionary_GetLast_Test()
        {
            dhelper.GetLast_Test(collection, dhelper.registry);
        }

        [Benchmark]
        public void Dictionary_Remove_Test()
        {
            dhelper.Remove_Test(collection, dhelper.registry);
        }

        [Benchmark]
        public void Dictionary_Iteration_Test()
        {
            dhelper.Iteration_Test(collection, dhelper.registry);
        }
    }
}
