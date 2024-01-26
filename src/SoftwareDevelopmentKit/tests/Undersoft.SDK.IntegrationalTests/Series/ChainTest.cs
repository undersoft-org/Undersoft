using System;
using System.Series.Tests;

namespace Undersoft.SDK.IntegrationTests.Series
{
    using Undersoft.SDK.Series;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;

    public class ChainTest : CatalogTestHelper
    {
        public ChainTest()
        {
            registry = new Chain<string>();
            DefaultTraceListener Logfile = new DefaultTraceListener();
            Logfile.Name = "Logfile";
            Trace.Listeners.Add(Logfile);
            Logfile.LogFileName = $"Catalog_{DateTime.Now.ToFileTime().ToString()}_Test.log";
        }       

        [Fact]
        public void Chain_IndentifierKeys_Test()
        {
            Catalog_Sync_Integrated_Test(identifierKeyTestCollection.Take(100000).ToArray());
        }

        [Fact]
        public void Chain_IntKeys_Test()
        {
            Catalog_Sync_Integrated_Test(intKeyTestCollection.Take(100000).ToArray());
        }

        [Fact]
        public void Chain_LongKeys_Test()
        {
            Catalog_Sync_Integrated_Test(longKeyTestCollection.Take(100000).ToArray());
        }

        [Fact]
        public void Chain_StringKeys_Test()
        {
            Catalog_Sync_Integrated_Test(stringKeyTestCollection.Take(100000).ToArray());
        }
    }
}
