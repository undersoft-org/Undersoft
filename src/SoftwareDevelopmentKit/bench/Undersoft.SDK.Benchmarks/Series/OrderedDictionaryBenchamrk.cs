using System.Series.Tests;

namespace Undersoft.SDK.Benchmarks.Series
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Engines;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    [RankColumn]
    [RPlotExporter]
    [SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
    public class OrderedDictionaryBenchmark
    {
        public static object holder = new object();
        public static int threadCount = 0;
        public Task[] tasks = new Task[10];
        public BenchmarkDictionaryHelper dhelper = new BenchmarkDictionaryHelper();
        public BenchmarkHelper chelper = new BenchmarkHelper();
        public IList<KeyValuePair<object, string>> collection;

        public OrderedDictionaryBenchmark()
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
            dhelper.orderedRegistry = new OrderedDictionary();
            foreach (var item in collection)
            {
                dhelper.orderedRegistry.Add(item.Key.ToString(), item.Value);
            }
        }

        [Benchmark]
        public void Dictionary_Add_Test()
        {
            dhelper.orderedRegistry = new OrderedDictionary();
            dhelper.Add_Test(collection, dhelper.orderedRegistry);
        }

        [Benchmark]
        public void Dictionary_GetByKey_Test()
        {
            dhelper.GetByKey_Test(collection, dhelper.orderedRegistry);
        }

        [Benchmark]
        public void Dictionary_Contains_Test()
        {
            dhelper.Contains_Test(collection, dhelper.orderedRegistry);
        }

        [Benchmark]
        public void Registry_SetByKey_Test()
        {
            chelper.SetByKey_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Registry_SetByIndex_Test()
        {
            chelper.SetByKey_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Dictionary_Remove_Test()
        {
            dhelper.Remove_Test(collection, dhelper.orderedRegistry);
        }

        [Benchmark]
        public void Dictionary_Iteration_Test()
        {
            dhelper.Iteration_Test(collection, dhelper.orderedRegistry);
        }
    }
}
