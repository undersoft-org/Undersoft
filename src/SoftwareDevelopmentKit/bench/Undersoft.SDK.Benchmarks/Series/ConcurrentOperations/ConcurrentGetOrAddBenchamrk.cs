using System.Series.Tests;

namespace Undersoft.SDK.Benchmarks.Series
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Engines;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Undersoft.SDK.Series;

    [MemoryDiagnoser]
    [RankColumn]
    [RPlotExporter]
    [SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
    public class ConcurrentGetItemByKeyBenchmark
    {
        public static object holder = new object();
        public static int threadCount = 0;
        public Task[] tasks = new Task[10];
        public BenchmarkDictionaryHelper dhelper = new BenchmarkDictionaryHelper();
        public BenchmarkHelper chelper = new BenchmarkHelper();
        public IList<KeyValuePair<object, string>> collection;

        public Catalog<string> catalog = new Catalog<string>();
        public Registry<string> registry = new Registry<string>();
        public ConcurrentDictionary<string, string> concurrentdictionary = new ConcurrentDictionary<string, string>();

        public ConcurrentGetItemByKeyBenchmark()
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
                concurrentdictionary.TryAdd(item.Key.ToString(), item.Value);
            }
        }

        private void Callback(Task[] t)
        {
            Debug.WriteLine($"Test Finished");
        }

        public int count => collection.Count;

        [Benchmark]
        public Task Catalog_GetOrAdd_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Factory.StartNew(
                                () =>
                                    chelper.GetOrAdd_Test(
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
        public Task Registry_GetOrAdd_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Factory.StartNew(
                                () =>
                                    chelper.GetOrAdd_Test(
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
        public Task ConcurrentDictionary_GetOrAdd_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Factory.StartNew(
                                () =>
                                    dhelper.GetOrAdd_Test(
                                        collection.Skip(x * limit).Take(limit),
                                       concurrentdictionary
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
