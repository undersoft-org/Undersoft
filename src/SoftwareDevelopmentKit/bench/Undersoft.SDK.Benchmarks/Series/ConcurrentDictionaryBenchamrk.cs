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

    [MemoryDiagnoser]
    [RankColumn]
    [RPlotExporter]
    [SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
    public class ConcurrentDictionaryBenchamrk
    {
        public static object holder = new object();
        public int count => collection.Count;
        public static int threadCount = 0;
        public Task[] tasks = new Task[10];
        public BenchmarkCollectionHelper dhelper = new BenchmarkCollectionHelper();
        public BenchmarkSeriesHelper chelper = new BenchmarkSeriesHelper();
        public IList<KeyValuePair<object, string>> collection;

        public ConcurrentDictionaryBenchamrk()
        {
            Setup();
        }

        [GlobalSetup]
        public void Setup()
        {
            dhelper = new BenchmarkCollectionHelper();

            DefaultTraceListener Logfile = new DefaultTraceListener();
            Logfile.Name = "Logfile";
            Trace.Listeners.Add(Logfile);
            Logfile.LogFileName = $"Catalog64_{DateTime.Now.ToFileTime().ToString()}_Test.log";

            collection = dhelper.identifierKeyTestCollection;
        }

        [IterationSetup]
        public void Prepare()
        {
            dhelper.registry = new ConcurrentDictionary<string, string>();

            foreach (var item in collection)
            {
                dhelper.registry.TryAdd(item.Key.ToString(), item.Value);
            }
        }

        private void Callback(Task[] t)
        {
            Debug.WriteLine($"Test Finished");
        }

        [Benchmark]
        public void Dictionary_Add_Test()
        {
            dhelper.registry = new Dictionary<string, string>();
            dhelper.Add_Test(collection, dhelper.registry);
        }

        [Benchmark]
        public Task Dictionary_ConcurrentAdd_Test()
        {
            dhelper.registry = new ConcurrentDictionary<string, string>();
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Run(
                                () =>
                                    dhelper.Add_Test(
                                        collection.Skip(x * limit).Take(limit),
                                        dhelper.registry
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
        public Task Dictionary_GetByKey_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Run(
                                () =>
                                    dhelper.GetByKey_Test(
                                        collection.Skip(x * limit).Take(limit),
                                        dhelper.registry
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
        public void Registry_SetByKey_Test()
        {
            chelper.SetByKey_Test(collection, chelper.registry);
        }

        [Benchmark]
        public Task Dictionary_ContainsKey_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Run(
                                () =>
                                    dhelper.ContainsKey_Test(
                                        collection.Skip(x * limit).Take(limit),
                                        dhelper.registry
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
        public Task Dictionary_GetLast_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Run(
                                () =>
                                    dhelper.GetLast_Test(
                                        collection.Skip(x * limit).Take(limit),
                                        dhelper.registry
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
        public Task Dictionary_Remove_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Run(
                                () =>
                                    dhelper.Remove_Test(
                                        collection.Skip(x * limit).Take(limit),
                                        dhelper.registry
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
        public Task Dictionary_Iteration_Test()
        {
            int limit = count / 10;
            return Task.Factory.ContinueWhenAll(
                tasks
                    .ForEach(
                        (t, x) =>
                            tasks[x] = Task.Run(
                                () =>
                                    dhelper.Iteration_Test(
                                        collection.Skip(x * limit).Take(limit),
                                        dhelper.registry
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
