namespace System.Series.Tests
{
    using Undersoft.SDK.Series;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Series;
    using System.Threading;
    using Xunit;
    using Undersoft.SDK.IntegrationTests.Instant;

    public class TypedRegistryTestHelper
    {
        public TypedRegistryTestHelper()
        {
            typedRegistry = new TypedRegistry<Agreement>();
            identifiableObjectTestCollection = PrepareTestListings.prepareIdentifiableObjectTestCollection();
        }

        public IList<Agreement> identifiableObjectTestCollection { get; set; }

        public ITypedSeries<Agreement> typedRegistry { get; set; }

        public void Registry_Sync_Integrated_Test(IList<Agreement> testCollection)
        {
            Registry_Sync_Add_Test(testCollection);
            Registry_Sync_Count_Test(100000);
            Registry_Sync_First_Test(testCollection[0]);
            Registry_Sync_Last_Test(testCollection[99999]);
            Registry_Sync_Get_Test(testCollection);
            Registry_Sync_GetCard_Test(testCollection);
            Registry_Sync_Remove_Test(testCollection);
            Registry_Sync_Count_Test(70000);
            Registry_Sync_Enqueue_Test(testCollection);
            Registry_Sync_Count_Test(70005);
            Registry_Sync_Dequeue_Test(testCollection);
            Registry_Sync_Contains_Test(testCollection);
            Registry_Sync_ContainsKey_Test(testCollection);
            Registry_Sync_Put_Test(testCollection);
            Registry_Sync_Count_Test(100000);
            Registry_Sync_Clear_Test();
            Registry_Sync_Add_V_Test(testCollection);
            Registry_Sync_Count_Test(100000);
            Registry_Sync_Remove_V_Test(testCollection);
            Registry_Sync_Count_Test(70000);
            Registry_Sync_Put_V_Test(testCollection);
            Registry_Sync_IndexOf_Test(testCollection);
            Registry_Sync_GetByIndexer_Test(testCollection);
            Registry_Sync_Count_Test(100000);
        }

        public void Registry_Async_ThreadIntegrated_Test(
            IList<Agreement> testCollection
        )
        {
            Registry_Async_Add_Test(testCollection);
            Registry_Async_Get_Test(testCollection);
            Registry_Async_GetCard_Test(testCollection);
            Registry_Async_Remove_Test(testCollection);
            Registry_Async_Enqueue_Test(testCollection);
            Registry_Async_Dequeue_Test(testCollection);
            Registry_Async_Contains_Test(testCollection);
            Registry_Async_ContainsKey_Test(testCollection);
            Registry_Async_Put_Test(testCollection);
            Registry_Async_GetByIndexer_Test(testCollection);

            Debug.WriteLine($"Thread no {testCollection[0].Id.ToString()}_{typedRegistry.Count} ends");
        }

        private void Registry_Sync_Add_Test(IList<Agreement> testCollection)
        {
            foreach (var item in testCollection)
            {
                typedRegistry.Add(item);
            }
        }

        private void Registry_Sync_Add_V_Test(IList<Agreement> testCollection)
        {
            foreach (var item in testCollection)
            {
                typedRegistry.Add(item);
            }
        }

        private void Registry_Sync_Clear_Test()
        {
            typedRegistry.Clear();
            Assert.Empty(typedRegistry);
        }

        private void Registry_Sync_Contains_Test(IList<Agreement> testCollection)
        {
            List<bool> items = new List<bool>();
            foreach (var item in testCollection)
            {
                if (typedRegistry.Contains(typedRegistry.NewItem(item)))
                    items.Add(true);
            }
            Assert.Equal(70000, items.Count);
        }

        private void Registry_Sync_ContainsKey_Test(IList<Agreement> testCollection)
        {
            List<bool> items = new List<bool>();
            foreach (var item in testCollection)
            {
                if (typedRegistry.ContainsKey(item))
                    items.Add(true);
            }
            Assert.Equal(70000, items.Count);
        }

        private void Registry_Sync_CopyTo_Test() { }

        private void Registry_Sync_Count_Test(int count)
        {
            Assert.Equal(count, typedRegistry.Count);
        }

        private void Registry_Sync_Dequeue_Test(IList<Agreement> testCollection)
        {
            List<Agreement> items = new List<Agreement>();
            for (int i = 0; i < 5; i++)
            {
                if (typedRegistry.TryDequeue(out Agreement output))
                    items.Add(output);
            }
            Assert.Equal(5, items.Count);
        }

        private void Registry_Sync_Enqueue_Test(IList<Agreement> testCollection)
        {
            List<bool> items = new List<bool>();
            foreach (var item in testCollection.Skip(70000).Take(5))
            {
                if (typedRegistry.Enqueue(item))
                    items.Add(true);
            }
            Assert.Equal(5, items.Count);
        }

        private void Registry_Sync_First_Test(Agreement firstValue)
        {
            Assert.Equal(typedRegistry.Next(typedRegistry.First).Value, firstValue);
        }

        private void Registry_Sync_Get_Test(IList<Agreement> testCollection)
        {
            List<Agreement> items = new List<Agreement>();
            foreach (var item in testCollection)
            {
                Agreement r = typedRegistry.Get(item);
                if (r != null)
                    items.Add(r);
            }
            Assert.Equal(100000, items.Count);
        }

        private void Registry_Sync_GetByIndexer_Test(IList<Agreement> testCollection)
        {
            List<Agreement> items = new List<Agreement>();
            int i = 0;
            foreach (var item in testCollection.Take(1000))
            {
                Agreement a = typedRegistry[i++];
                Agreement b = item;
            }
        }

        private void Registry_Sync_GetCard_Test(IList<Agreement> testCollection)
        {
            List<ISeriesItem<Agreement>> items = new List<ISeriesItem<Agreement>>();
            foreach (var item in testCollection)
            {
                var r = typedRegistry.GetItem(item);
                if (r != null)
                    items.Add(r);
            }
            Assert.Equal(100000, items.Count);
        }

        private void Registry_Sync_IndexOf_Test(IList<Agreement> testCollection)
        {
            List<int> items = new List<int>();
            foreach (var item in testCollection.Skip(5000).Take(100))
            {
                int r = typedRegistry.IndexOf(item);
                items.Add(r);
            }
        }

        private void Registry_Sync_Last_Test(Agreement lastValue)
        {
            Assert.Equal(typedRegistry.Last.Value, lastValue);
        }

        private void Registry_Sync_Put_Test(IList<Agreement> testCollection)
        {
            foreach (var item in testCollection)
            {
                typedRegistry.Put(item);
            }
        }

        private void Registry_Sync_Put_V_Test(IList<Agreement> testCollection)
        {
            foreach (var item in testCollection)
            {
                typedRegistry.Put(item);
            }
        }

        private void Registry_Sync_Remove_Test(IList<Agreement> testCollection)
        {
            List<Agreement> items = new List<Agreement>();
            foreach (var item in testCollection.Skip(70000))
            {
                var r = typedRegistry.Remove(item);
                if (r != null)
                    items.Add(r);
            }
            Assert.Equal(30000, items.Count);
        }

        private void Registry_Sync_Remove_V_Test(IList<Agreement> testCollection)
        {
            List<Agreement> items = new List<Agreement>();
            foreach (var item in testCollection.Skip(70000))
            {
                Agreement r = typedRegistry.Remove(item);
                items.Add(r);
            }
            Assert.Equal(30000, items.Count);
        }

        private void Registry_Async_Add_Test(IList<Agreement> testCollection)
        {
            List<bool> items = new List<bool>();
            foreach (var item in testCollection)
            {
                items.Add(typedRegistry.TryAdd(item));
            }
            Debug.WriteLine($"Add Thread no {testCollection[0].Id.ToString()}_{items.Count} ends");
        }

        private void Registry_Async_Add_V_Test(IList<Agreement> testCollection)
        {
            foreach (var item in testCollection)
            {
                typedRegistry.Add(item);
            }
        }

        private void Registry_Async_Contains_Test(IList<Agreement> testCollection)
        {
            List<bool> items = new List<bool>();
            foreach (var item in testCollection)
            {
                if (typedRegistry.Contains(typedRegistry.NewItem(item)))
                    items.Add(true);
            }
            Debug.WriteLine(
                $"Get Card Thread no {testCollection[0].Id.ToString()}_{items.Count} ends"
            );
        }

        private void Registry_Async_ContainsKey_Test(
            IList<Agreement> testCollection
        )
        {
            List<bool> items = new List<bool>();
            foreach (var item in testCollection)
            {
                if (typedRegistry.ContainsKey(item))
                    items.Add(true);
            }
            Debug.WriteLine(
                $"Get Card Thread no {testCollection[0].Id.ToString()}_{items.Count} ends"
            );
        }

        private void Registry_Async_Dequeue_Test(IList<Agreement> testCollection)
        {
            List<Agreement> items = new List<Agreement>();
            for (int i = 0; i < 5; i++)
            {
                Agreement output = null;
                if (typedRegistry.TryDequeue(out output))
                    items.Add(output);
            }
            Assert.Equal(5, items.Count);
        }

        private void Registry_Async_Enqueue_Test(IList<Agreement> testCollection)
        {
            List<bool> items = new List<bool>();
            foreach (var item in testCollection.Skip(5000).Take(5))
            {
                if (typedRegistry.Enqueue(item))
                    items.Add(true);
            }
            Assert.Equal(5, items.Count);
        }

        private void Registry_Async_Get_Test(IList<Agreement> testCollection)
        {
            List<Agreement> items = new List<Agreement>();
            foreach (var item in testCollection)
            {
                Agreement r = typedRegistry.Get(item);
                if (r != null)
                    items.Add(r);
            }
            Debug.WriteLine($"Get Thread no {testCollection[0].Id.ToString()}_{items.Count} ends");
        }

        private void Registry_Async_GetByIndexer_Test(
            IList<Agreement> testCollection
        )
        {
            List<Agreement> items = new List<Agreement>();
            int i = 0;
            foreach (var item in testCollection.Take(1000))
            {
                items.Add(typedRegistry[i]);
            }
            Debug.WriteLine(
                $"Get By Indexer Thread no {testCollection[0].Id.ToString()}_{items.Count} ends"
            );
        }

        private void Registry_Async_GetCard_Test(IList<Agreement> testCollection)
        {
            List<ISeriesItem<Agreement>> items = new List<ISeriesItem<Agreement>>();
            foreach (var item in testCollection)
            {
                var r = typedRegistry.GetItem(item);
                if (r != null)
                    items.Add(r);
            }
            Debug.WriteLine(
                $"Get Card Thread no {testCollection[0].Id.ToString()}_{items.Count} ends"
            );
        }

        private void Registry_Async_Put_Test(IList<Agreement> testCollection)
        {
            List<Agreement> items = new List<Agreement>();
            foreach (var item in testCollection)
            {
                items.Add(typedRegistry.Put(item).Value);
            }
            Debug.WriteLine($"Put Thread no {testCollection[0].Id.ToString()}_{items.Count} ends");
        }

        private void Registry_Async_Put_V_Test(IList<Agreement> testCollection)
        {
            List<Agreement> items = new List<Agreement>();
            foreach (var item in testCollection)
            {
                typedRegistry.Put(item);
            }
        }

        private void Registry_Async_Remove_Test(IList<Agreement> testCollection)
        {
            List<Agreement> items = new List<Agreement>();
            foreach (var item in testCollection.Skip(5000))
            {
                var r = typedRegistry.Remove(item);
                if (r != null)
                    items.Add(r);
            }
            Debug.WriteLine(
                $"Removed Thread no {testCollection[0].Id.ToString()}_{items.Count} ends"
            );
        }

        private void Registry_Async_Remove_V_Test(IList<Agreement> testCollection)
        {
            List<Agreement> items = new List<Agreement>();
            foreach (var item in testCollection.Skip(5000))
            {
                Agreement r = typedRegistry.Remove(item);
                items.Add(r);
            }
            Debug.WriteLine(
                $"Removed V Thread no {testCollection[0].Id.ToString()}_{items.Count} ends"
            );
        }
    }
}
