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
    public class GetByKeyBenchmark
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

        public GetByKeyBenchmark()
        {
            Setup();
        }

        [GlobalSetup]
        public void Setup()
        {
            dhelper = new BenchmarkCollectionHelper();
            chelper = new BenchmarkSeriesHelper(); ;

            collection = dhelper.identifierKeyTestCollection;

            foreach (var item in collection)
            {
                chain.Add(item.Key, item.Value);
                catalog.Add(item.Key, item.Value);
                listing.Add(item.Key, item.Value);
                registry.Add(item.Key, item.Value);

                list.Add(item.Value);
                dictionary.Add(item.Key.ToString(), item.Value);
                ordereddictionary.Add(item.Key.ToString(), item.Value);
                concurrentdictionary.TryAdd(item.Key.ToString(), item.Value);
            }

            DefaultTraceListener Logfile = new DefaultTraceListener();
            Logfile.Name = "Logfile";
            Trace.Listeners.Add(Logfile);
            Logfile.LogFileName = $"Catalog64_{DateTime.Now.ToFileTime().ToString()}_Test.log";
        }

        [Benchmark]
        public void Chain_GetByKey_Test()
        {
            chelper.GetByKey_From_Indexer_Test(collection, chain);
        }

        [Benchmark]
        public void Catalog_GetByKey_Test()
        {
            chelper.GetByKey_From_Indexer_Test(collection, catalog);
        }

        [Benchmark]
        public void Listing_GetByKey_Test()
        {
            chelper.GetByKey_From_Indexer_Test(collection, listing);
        }

        [Benchmark]
        public void Registry_GetByKey_Test()
        {
            chelper.GetByKey_From_Indexer_Test(collection, registry);
        }

        [Benchmark]
        public void Dictionary_GetByKey_Test()
        {
            dhelper.GetByKey_Test(collection, dictionary);
        }

        [Benchmark]
        public void OrderedDictionary_GetByKey_Test()
        {
            dhelper.GetByKey_Test(collection, ordereddictionary);
        }

        [Benchmark]
        public void ConcurrentDictionary_GetByKey_Test()
        {
            dhelper.GetByKey_Test(collection, concurrentdictionary);
        }
    }
}
