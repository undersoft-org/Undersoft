using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series;
using Undersoft.SDK.Series.Base;
using Undersoft.SDK.Uniques;
using V = Undersoft.SDK.Origin;

namespace Undersoft.SDK.UnitTests.Series.Base;

/// <summary>
/// Unit tests for the type <see cref="TypedCatalogBase"/>.
/// </summary>
public class TypedCatalogBase_1Tests
{
    private class TestTypedCatalogBase : TypedCatalogBase<V>
    {
        public TestTypedCatalogBase(
            IEnumerable<IUnique<V>> collection,
            int capacity = 17,
            HashBits bits = HashBits.bit64
        ) : base(collection, capacity, bits)
        {
        }

        public TestTypedCatalogBase(
            IEnumerable<V> collection,
            int capacity = 17,
            HashBits bits = HashBits.bit64
        ) : base(collection, capacity, bits)
        {
        }

        public TestTypedCatalogBase(
            IList<IUnique<V>> collection,
            int capacity = 17,
            HashBits bits = HashBits.bit64
        ) : base(collection, capacity, bits)
        {
        }

        public TestTypedCatalogBase(IList<V> collection, int capacity = 17, HashBits bits = HashBits.bit64) : base(collection, capacity, bits)
        {
        }

        public TestTypedCatalogBase(int capacity = 17, HashBits bits = HashBits.bit64) : base(capacity, bits)
        {
        }

        public void PublicacquireReader()
        {
            base.acquireReader();
        }

        public void PublicacquireRehash()
        {
            base.acquireRehash();
        }

        public void PublicacquireWriter()
        {
            base.acquireWriter();
        }

        public bool PublicInnerAdd(ISeriesItem<V> value)
        {
            return base.InnerAdd(value);
        }

        public bool PublicInnerAdd(long key, V value)
        {
            return base.InnerAdd(key, value);
        }

        public bool PublicInnerAdd(V value)
        {
            return base.InnerAdd(value);
        }

        public V PublicInnerGet(long key)
        {
            return base.InnerGet(key);
        }

        public ISeriesItem<V> PublicInnerGetItem(long key)
        {
            return base.InnerGetItem(key);
        }

        public ISeriesItem<V> PublicInnerPut(ISeriesItem<V> value)
        {
            return base.InnerPut(value);
        }

        public ISeriesItem<V> PublicInnerPut(long key, V value)
        {
            return base.InnerPut(key, value);
        }

        public ISeriesItem<V> PublicInnerPut(V value)
        {
            return base.InnerPut(value);
        }

        public V PublicInnerRemove(long key)
        {
            return base.InnerRemove(key);
        }

        public bool PublicInnerTryGet(long key, out ISeriesItem<V> output)
        {
            return base.InnerTryGet(key, out output);
        }

        public void PublicRehash(int newsize)
        {
            base.Rehash(newsize);
        }

        public void PublicReindex()
        {
            base.Reindex();
        }

        public void PublicreleaseReader()
        {
            base.releaseReader();
        }

        public void PublicreleaseRehash()
        {
            base.releaseRehash();
        }

        public void PublicreleaseWriter()
        {
            base.releaseWriter();
        }

        public override ISeriesItem<V> EmptyItem()
        {
            return default(ISeriesItem<V>);
        }

        public override ISeriesItem<V> NewItem(long key, V value)
        {
            return default(ISeriesItem<V>);
        }

        public override ISeriesItem<V> NewItem(object key, V value)
        {
            return default(ISeriesItem<V>);
        }

        public override ISeriesItem<V> NewItem(ISeriesItem<V> item)
        {
            return default(ISeriesItem<V>);
        }

        public override ISeriesItem<V> NewItem(V item)
        {
            return default(ISeriesItem<V>);
        }

        public override ISeriesItem<V>[] EmptyTable(int size)
        {
            return default(ISeriesItem<V>[]);
        }
    }

    private TestTypedCatalogBase _testClass;
    private IFixture _fixture;
    private IEnumerable<IUnique<V>> _collectionIEnumerableIUniqueV;
    private int _capacity;
    private HashBits _bits;
    private IEnumerable<V> _collectionIEnumerableV;
    private IList<IUnique<V>> _collectionIListIUniqueV;
    private IList<V> _collectionIListV;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TypedCatalogBase"/>.
    /// </summary>
    public TypedCatalogBase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._collectionIEnumerableIUniqueV = _fixture.Create<IEnumerable<IUnique<V>>>();
        this._capacity = _fixture.Create<int>();
        this._bits = _fixture.Create<HashBits>();
        this._collectionIEnumerableV = _fixture.Create<IEnumerable<V>>();
        this._collectionIListIUniqueV = _fixture.Create<IList<IUnique<V>>>();
        this._collectionIListV = _fixture.Create<IList<V>>();
        this._testClass = _fixture.Create<TestTypedCatalogBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestTypedCatalogBase(this._collectionIEnumerableIUniqueV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedCatalogBase(this._collectionIEnumerableV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedCatalogBase(this._collectionIListIUniqueV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedCatalogBase(this._collectionIListV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedCatalogBase(this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCollection()
    {
        FluentActions.Invoking(() => new TestTypedCatalogBase(default(IEnumerable<IUnique<V>>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedCatalogBase(default(IEnumerable<V>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedCatalogBase(default(IList<IUnique<V>>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedCatalogBase(default(IList<V>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the Clear method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClear()
    {
        // Act
        this._testClass.Clear();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyToWithArrayAndInt()
    {
        // Arrange
        var array = _fixture.Create<Array>();
        var index = _fixture.Create<int>();

        // Act
        this._testClass.CopyTo(array, index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithArrayAndIntWithNullArray()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(Array), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyToWithArrayOfISeriesItemOfVAndInt()
    {
        // Arrange
        var array = _fixture.Create<ISeriesItem<V>[]>();
        var index = _fixture.Create<int>();

        // Act
        this._testClass.CopyTo(array, index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithArrayOfISeriesItemOfVAndIntWithNullArray()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(ISeriesItem<V>[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyToWithArrayOfVAndInt()
    {
        // Arrange
        var array = _fixture.Create<V[]>();
        var index = _fixture.Create<int>();

        // Act
        this._testClass.CopyTo(array, index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithArrayOfVAndIntWithNullArray()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(V[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the GetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItem()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetItem(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetItemPerformsMapping()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetItem(index);

        // Assert
        result.Index.Should().Be(index);
    }

    /// <summary>
    /// Checks that the IndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOfWithISeriesItemOfV()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.IndexOf(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIndexOfWithISeriesItemOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.IndexOf(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the IndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOfWithV()
    {
        // Arrange
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.IndexOf(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Insert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsert()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        this._testClass.Insert(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Insert method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInsertWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Insert(_fixture.Create<int>(), default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ToArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToArray()
    {
        // Act
        var result = this._testClass.ToArray();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryDequeue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryDequeueWithISeriesItemOfV()
    {
        // Act
        var result = this._testClass.TryDequeue(out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryDequeue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryDequeueWithV()
    {
        // Act
        var result = this._testClass.TryDequeue(out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryPick method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryPick()
    {
        // Arrange
        var skip = _fixture.Create<int>();

        // Act
        var result = this._testClass.TryPick(skip, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicacquireReader method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallacquireReader()
    {
        // Act
        this._testClass.PublicacquireReader();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicacquireRehash method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallacquireRehash()
    {
        // Act
        this._testClass.PublicacquireRehash();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicacquireWriter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallacquireWriter()
    {
        // Act
        this._testClass.PublicacquireWriter();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerAddWithISeriesItemOfV()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PublicInnerAdd(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerAddWithISeriesItemOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerAdd(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerAddWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerAdd(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerAddWithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerAdd(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerGet()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerGet(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerGetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerGetItem()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerGetItem(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerPut method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerPutWithISeriesItemOfV()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerPut method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerPutWithISeriesItemOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerPut(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the PublicInnerPut maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerPutWithISeriesItemOfVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PublicInnerPut method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerPutWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerPut(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerPut maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerPutWithLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerPut(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PublicInnerPut method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerPutWithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerPut maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerPutWithVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PublicInnerRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerRemove()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerRemove(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerTryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerTryGet()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerTryGet(key, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRehash method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRehash()
    {
        // Arrange
        var newsize = _fixture.Create<int>();

        // Act
        this._testClass.PublicRehash(newsize);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicReindex method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReindex()
    {
        // Act
        this._testClass.PublicReindex();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicreleaseReader method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallreleaseReader()
    {
        // Act
        this._testClass.PublicreleaseReader();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicreleaseRehash method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallreleaseRehash()
    {
        // Act
        this._testClass.PublicreleaseRehash();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicreleaseWriter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallreleaseWriter()
    {
        // Act
        this._testClass.PublicreleaseWriter();

        // Assert
        Assert.Fail("Create or modify test");
    }
}