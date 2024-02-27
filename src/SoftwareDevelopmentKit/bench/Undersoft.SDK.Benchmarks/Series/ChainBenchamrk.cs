using System.Series.Tests;

namespace Undersoft.SDK.Benchmarks.Series
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Engines;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Undersoft.SDK.Series;

    [MemoryDiagnoser]
    [RankColumn]
    [RPlotExporter]
    [SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
    public class ChainBenchamrk
    {
        public static object holder = new object();
        public static int threadCount = 0;
        public Task[] tasks = new Task[10];
        public BenchmarkDictionaryHelper dhelper = new BenchmarkDictionaryHelper();
        public BenchmarkHelper chelper = new BenchmarkHelper();
        public IList<KeyValuePair<object, string>> collection;

        public ChainBenchamrk()
        {
            Setup();
        }

        [GlobalSetup]
        public void Setup()
        {
            dhelper = new BenchmarkDictionaryHelper();
            chelper = new BenchmarkHelper();

            chelper.registry = new Chain<string>();

            DefaultTraceListener Logfile = new DefaultTraceListener();
            Logfile.Name = "Logfile";
            Trace.Listeners.Add(Logfile);
            Logfile.LogFileName = $"Catalog64_{DateTime.Now.ToFileTime().ToString()}_Test.log";

            collection = dhelper.identifierKeyTestCollection;
        }

        [IterationSetup]
        public void Prepare()
        {
            chelper.registry = new Chain<string>();
            foreach (var item in collection)
            {
                chelper.registry.Add(item.Key, item.Value);
            }
        }

        [Benchmark]
        public void Chain_Add_Test()
        {
            chelper.registry = new Chain<string>(capacity: 1000000);
            chelper.Add_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Chain_GetByKey_Test()
        {
            chelper.GetByKey_From_Indexer_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Chain_ContainsKey_Test()
        {
            chelper.ContainsKey_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Chain_Iteration_Test()
        {
            chelper.Iteration_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Chain_Remove_Test()
        {
            chelper.Remove_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Chain_Put_Test()
        {
            chelper.registry = new Chain<string>(capacity: 1000000);
            chelper.Put_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Chain_Enqueue_Test()
        {
            chelper.Enqueue_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Chain_Dequeue_Test()
        {
            chelper.Dequeue_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Chain_GetLast_Test()
        {
            chelper.Last_Test(null, chelper.registry);
        }

        [Benchmark]
        public void Chain_Contains_Test()
        {
            chelper.Contains_Test(collection, chelper.registry);
        }
    }
}
