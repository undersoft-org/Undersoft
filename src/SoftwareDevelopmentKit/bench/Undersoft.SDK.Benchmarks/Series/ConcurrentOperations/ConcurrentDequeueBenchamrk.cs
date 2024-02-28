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
    public class ConcurrentDequeueBenchmark
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

        public Queue<string> queue = new Queue<string>();
        public ConcurrentQueue<string> concurrentqueue = new ConcurrentQueue<string>();

        public ConcurrentDequeueBenchmark()
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
                catalog.TryAdd(item.Key.ToString(), item.Value);
                registry.TryAdd(item.Key.ToString(), item.Value);

                queue.Enqueue(item.Value);
                concurrentqueue.Enqueue(item.Value);
            }
        }


        private void Callback(Task[] t)
        {
            Debug.WriteLine($"Test Finished");
        }

        public int count => collection.Count;

        [Benchmark]
        public Task Catalog_Dequeue_Test()
        {
            var registry = new Catalog<string>();
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Factory.StartNew(
                                () =>
                                    chelper.Dequeue_Test(
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
        public Task Registry_Dequeue_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Factory.StartNew(
                                () =>
                                    chelper.Dequeue_Test(
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
        public Task ConcurrentQueue_Dequeue_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Factory.StartNew(
                                () =>
                                    dhelper.Dequeue_Test(
                                        collection.Skip(x * limit).Take(limit),
                                       concurrentqueue
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
