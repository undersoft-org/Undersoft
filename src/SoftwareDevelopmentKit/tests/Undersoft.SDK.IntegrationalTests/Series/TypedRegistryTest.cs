using System.Series.Tests;

namespace Undersoft.SDK.IntegrationTests.Series
{
    using Undersoft.SDK.Series;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;
    using Undersoft.SDK.IntegrationTests.Instant;
    using Undersoft.SDK.Uniques;

    public class TypedRegistryTest : TypedRegistryTestHelper
    {
        public static object holder = new object();
        public static int threadCount = 0;
        public Task[] s1 = new Task[10];

        public TypedRegistryTest() : base()
        {
            typedRegistry = new TypedRegistry<Agreement>();
            DefaultTraceListener Logfile = new DefaultTraceListener();
            Logfile.Name = "Logfile";
            Trace.Listeners.Add(Logfile);
            Logfile.LogFileName = $"Registry__{DateTime.Now.ToFileTime().ToString()}_Test.log";
        }

        [Fact]
        public async Task Registry__Concurrent_IndentifierKeys_TestAsync()
        {
            await Registry_MultiThread_Test(identifiableObjectTestCollection).ConfigureAwait(true);
        }

        [Fact]
        public void Registry__IndentifierKeys_Test()
        {
            Registry_Sync_Integrated_Test(identifiableObjectTestCollection.Take(100000).ToArray());
        }

        [Fact]
        public void Registry_HashKey_Test()
        {
            var uniques = Unique.Bit64;
            var list = identifiableObjectTestCollection.Take(100000).ToArray();
            var key0 = uniques.Key(list[0], list[0].TypeId);
            var key1 = uniques.Key(list[0], list[0].TypeId);
            
            bool check = key0.Equals(key1);
            
            typedRegistry.Add(key0, list[0]);
            
            var item = typedRegistry.Get(key1);
            
            var key2 = uniques.Key(list[1], list[1].TypeId);
            var key3 = uniques.Key(list[1], list[1].TypeId);

            typedRegistry.Add(list[1]);

            item = typedRegistry.Get(key2);
            item = typedRegistry.Get(key3);

            item = typedRegistry.Get(list[1]);
        }

        private void Registry_MultiThread_TCallback_Test(Task[] t)
        {
            Debug.WriteLine($"Test Finished");
        }

        private Task Registry_MultiThread_Test(IList<Agreement> collection)
        {
            Action publicTest = () =>
            {
                int c = 0;
                lock (holder)
                    c = threadCount++;

                Registry_Async_ThreadIntegrated_Test(collection.Skip(c * 10000).Take(10000).ToArray());
            };

            for (int i = 0; i < 10; i++)
            {
                s1[i] = Task.Factory.StartNew(publicTest);
            }

            return Task.Factory.ContinueWhenAll(
                s1,
                new Action<Task[]>(a =>
                {
                    Registry_MultiThread_TCallback_Test(a);
                })
            );
        }
    }
}
