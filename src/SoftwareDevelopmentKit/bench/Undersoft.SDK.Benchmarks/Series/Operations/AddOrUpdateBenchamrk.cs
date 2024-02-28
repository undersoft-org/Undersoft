using System.Series.Tests;

namespace Undersoft.SDK.Benchmarks.Series
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Engines;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Undersoft.SDK.Series;

    [MemoryDiagnoser]
    [RankColumn]
    [RPlotExporter]
    [SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
    public class AddOrUpdateBenchmark
    {
        public static object holder = new object();
        public static int threadCount = 0;
        public Task[] tasks = new Task[10];
        public BenchmarkCollectionHelper dhelper = new BenchmarkCollectionHelper();
        public BenchmarkSeriesHelper chelper = new BenchmarkSeriesHelper();
        public IList<KeyValuePair<object, string>> collection;

        public Chain<string> chain = new Chain<string>();
        public Catalog<string> catalog = new Catalog<string>();
        public Listing<string> listing = new Listing<string>();
        public Registry<string> registry = new Registry<string>();

        public List<string> list = new List<string>();
        public Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public OrderedDictionary ordereddictionary = new OrderedDictionary();
        public ConcurrentDictionary<string, string> concurrentdictionary = new ConcurrentDictionary<string, string>();

        public AddOrUpdateBenchmark()
        {
            Setup();
        }

        [GlobalSetup]
        public void Setup()
        {
            dhelper = new BenchmarkCollectionHelper();
            chelper = new BenchmarkSeriesHelper(); ;

            DefaultTraceListener Logfile = new DefaultTraceListener();
            Logfile.Name = "Logfile";
            Trace.Listeners.Add(Logfile);
            Logfile.LogFileName = $"Catalog64_{DateTime.Now.ToFileTime().ToString()}_Test.log";

            collection = dhelper.identifierKeyTestCollection;
        }

        [IterationSetup]
        public void Prepare()
        {
            foreach (var item in collection)
            {
                chain.TryAdd(item.Key.ToString(), item.Value);
                catalog.TryAdd(item.Key.ToString(), item.Value);
                listing.TryAdd(item.Key.ToString(), item.Value);
                registry.TryAdd(item.Key.ToString(), item.Value);

                list.Add(item.Value);
                dictionary.TryAdd(item.Key.ToString(), item.Value);
                ordereddictionary.Add(item.Key.ToString(), item.Value);
                concurrentdictionary.TryAdd(item.Key.ToString(), item.Value);
            }
        }

        [Benchmark]
        public void Chain_AddOrUpdate_Test()
        {
            chelper.Put_Test(collection, chain);
        }

        [Benchmark]
        public void Catalog_AddOrUpdate_Test()
        {
            chelper.Put_Test(collection, catalog);
        }

        [Benchmark]
        public void Listing_AddOrUpdate_Test()
        {
            chelper.Put_Test(collection, listing);
        }

        [Benchmark]
        public void Registry_AddOrUpdate_Test()
        {
            chelper.Put_Test(collection, registry);
        }

        //[Benchmark]
        //public void List_AddOrUpdate_Test()
        //{
        //    dhelper.AddOrUpdate_Test(collection, list);
        //}

        //[Benchmark]
        //public void Dictionary_AddOrUpdate_Test()
        //{
        //    dhelper.AddOrUpdate_Test(collection, (IDictionary<string, string>)dictionary);
        //}

        //[Benchmark]
        //public void OrderedDictionary_AddOrUpdate_Test()
        //{
        //    dhelper.AddOrUpdate_Test(collection, ordereddictionary);
        //}

        [Benchmark]
        public void ConcurrentDictionary_AddOrUpdate_Test()
        {
            dhelper.AddOrUpdate_Test(collection, concurrentdictionary);
        }


    }
}
