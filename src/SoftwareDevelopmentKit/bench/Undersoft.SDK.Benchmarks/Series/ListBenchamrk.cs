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
    public class ListBenchmark
    {
        public static object holder = new object();
        public static int threadCount = 0;
        public Task[] tasks = new Task[10];
        public BenchmarkDictionaryHelper dhelper = new BenchmarkDictionaryHelper();
        public BenchmarkHelper chelper = new BenchmarkHelper();
        public IList<KeyValuePair<object, string>> collection;

        public ListBenchmark()
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
            dhelper.list = new List<string>();

            foreach (var item in collection)
            {
                dhelper.list.Add(item.Value);
            }
        }

        [Benchmark]
        public void List_Add_Test()
        {
            dhelper.list = new List<string>();
            dhelper.Add_Test(collection, dhelper.list);
        }


        [Benchmark]
        public void Registry_GetByIndex_Test()
        {
            dhelper.GetByIndex_Test(collection, dhelper.list);
        }

        [Benchmark]
        public void Registry_SetByIndex_Test()
        {
            chelper.SetByKey_Test(collection, chelper.registry);
        }

        [Benchmark]
        public void List_Remove_Test()
        {
            dhelper.Remove_Test(collection, dhelper.list);
        }

        [Benchmark]
        public void List_Iteration_Test()
        {
            dhelper.Iteration_Test(collection, dhelper.list);
        }
    }
}
