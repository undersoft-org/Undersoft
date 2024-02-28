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
    public class ListingBenchamrk
    {
        public static object holder = new object();
        public static int threadCount = 0;
        public Task[] tasks = new Task[10];
        public BenchmarkCollectionHelper dhelper = new BenchmarkCollectionHelper();
        public BenchmarkSeriesHelper chelper = new BenchmarkSeriesHelper();
        public IList<KeyValuePair<object, string>> collection;

        public ListingBenchamrk()
        {
            Setup();
        }

        [GlobalSetup]
        public void Setup()
        {
            dhelper = new BenchmarkCollectionHelper();
            chelper = new BenchmarkSeriesHelper();

            chelper.registry = new Listing<string>();

            DefaultTraceListener Logfile = new DefaultTraceListener();
            Logfile.Name = "Logfile";
            Trace.Listeners.Add(Logfile);
            Logfile.LogFileName = $"Catalog64_{DateTime.Now.ToFileTime().ToString()}_Test.log";

            collection = dhelper.identifierKeyTestCollection;
        }

        [IterationSetup]
        public void Prepare()
        {
            chelper.registry = new Listing<string>();
            foreach (var item in collection)
            {
                chelper.registry.Add(item.Key, item.Value);
            }
        }

        [Benchmark]
        public void Listing_Add_Test()
        {
            chelper.registry = new Listing<string>(capacity: 1000000);
            chelper.Add_Test(collection, chelper.registry);
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
        public void Listing_GetByKey_Test()
        {
            chelper.GetByKey_From_Indexer_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Listing_ContainsKey_Test()
        {
            chelper.ContainsKey_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Listing_GetByIndex_Test()
        {
            chelper.GetByIndexer_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Listing_Iteration_Test()
        {
            chelper.Iteration_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Listing_Remove_Test()
        {
            chelper.Remove_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Registry_IndexOf_Test()
        {
            chelper.IndexOf_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Listing_Put_Test()
        {
            chelper.registry = new Listing<string>(capacity: 1000000);
            chelper.Put_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Listing_Enqueue_Test()
        {
            chelper.Enqueue_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Listing_Dequeue_Test()
        {
            chelper.Dequeue_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Listing_Contains_Test()
        {
            chelper.Contains_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void Listing_GetLast_Test()
        {
            chelper.Last_Test(null, chelper.registry);
        }
    }
}
