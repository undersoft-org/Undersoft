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

    public class ListingTest : RegistryTestHelper
    {
        public static object holder = new object();
        public static int threadCount = 0;
        public Task[] s1 = new Task[10];

        public ListingTest() : base()
        {
            registry = new Listing<string>();
            DefaultTraceListener Logfile = new DefaultTraceListener();
            Logfile.Name = "Logfile";
            Trace.Listeners.Add(Logfile);
            Logfile.LogFileName = $"Registry__{DateTime.Now.ToFileTime().ToString()}_Test.log";
        }

        [Fact]
        public void Listing__IndentifierKeys_Test()
        {
            Registry_Sync_Integrated_Test(identifierKeyTestCollection.Take(100000).ToArray());
        }

        [Fact]
        public void Listing__IntKeys_Test()
        {
            Registry_Sync_Integrated_Test(intKeyTestCollection.Take(100000).ToArray());
        }

        [Fact]
        public void Listing__LongKeys_Test()
        {
            Registry_Sync_Integrated_Test(longKeyTestCollection.Take(100000).ToArray());
        }

        [Fact]
        public void Listing__StringKeys_Test()
        {
            Registry_Sync_Integrated_Test(stringKeyTestCollection.Take(100000).ToArray());
        }
    }
}
