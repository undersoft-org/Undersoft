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

    public class TypedCatalogTest : TypedRegistryTestHelper
    {
        public static object holder = new object();
        public static int threadCount = 0;
        public Task[] s1 = new Task[10];

        public TypedCatalogTest() : base()
        {
            typedRegistry = new TypedCatalog<Agreement>();
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
