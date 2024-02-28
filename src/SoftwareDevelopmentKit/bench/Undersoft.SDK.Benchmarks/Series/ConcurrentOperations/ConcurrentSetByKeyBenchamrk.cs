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
    using System.Linq;
    using System.Threading.Tasks;
    using Undersoft.SDK.Series;

    [MemoryDiagnoser]
    [RankColumn]
    [RPlotExporter]
    [SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
    public class ConcurrentSetByKeyBenchmark
    {
        public static object holder = new object();
        public static int threadCount = 0;
        public Task[] tasks = new Task[10];
        public BenchmarkDictionaryHelper dhelper = new BenchmarkDictionaryHelper();
        public BenchmarkHelper chelper = new BenchmarkHelper();
        public IList<KeyValuePair<object, string>> collection;

        public Chain<string> chain = new Chain<string>();
        public Catalog<string> catalog = new Catalog<string>();
        public Listing<string> listing = new Listing<string>();
        public Registry<string> registry = new Registry<string>();

        public List<string> list = new List<string>();
        public Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public OrderedDictionary ordereddictionary = new OrderedDictionary();
        public ConcurrentDictionary<string, string> concurrentdictionary = new ConcurrentDictionary<string, string>();

        public ConcurrentSetByKeyBenchmark()
        {
            Setup();
        }

        [GlobalSetup]
        public void Setup()
        {
            dhelper = new BenchmarkDictionaryHelper();
            chelper = new BenchmarkHelper(); ;

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


        private void Callback(Task[] t)
        {
            Debug.WriteLine($"Test Finished");
        }

        public int count => collection.Count;

        [Benchmark]
        public Task Catalog_SetByKey_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Factory.StartNew(
                                () =>
                                    chelper.SetByKey_Test(
                                        collection.Skip(x * limit).Take(limit),
                                       catalog
                                    )
                            )
                    )
                    .ToArray(),
                new Action<Task[]>(a =>
                {
                    Callback(a);
                })
            );
        }

        [Benchmark]
        public Task Registry_SetByKey_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Factory.StartNew(
                                () =>
                                    chelper.SetByKey_Test(
                                        collection.Skip(x * limit).Take(limit),
                                        registry
                                    )
                            )
                    )
                    .ToArray(),
                new Action<Task[]>(a =>
                {
                    Callback(a);
                })
            );
        }

        [Benchmark]
        public Task ConcurrentDictionary_SetByKey_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Factory.StartNew(
                                () =>
                                    dhelper.SetByKey_Test(
                                        collection.Skip(x * limit).Take(limit),
                                        (IDictionary<string, string>)concurrentdictionary
                                    )
                            )
                    )
                    .ToArray(),
                new Action<Task[]>(a =>
                {
                    Callback(a);
                })
            );
        }
    }
}
