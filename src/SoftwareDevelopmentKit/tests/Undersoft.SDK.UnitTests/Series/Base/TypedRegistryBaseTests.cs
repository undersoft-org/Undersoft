using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Series;
using Undersoft.SDK.Series.Base;
using Undersoft.SDK.Uniques;
using V = Undersoft.SDK.Origin;

namespace Undersoft.SDK.UnitTests.Series.Base;

/// <summary>
/// Unit tests for the type <see cref="TypedRegistryBase"/>.
/// </summary>
public class TypedRegistryBase_1Tests
{
    private class TestTypedRegistryBase : TypedRegistryBase<V>
    {
        public TestTypedRegistryBase() : base()
        {
        }

        public TestTypedRegistryBase(int capacity = 17, HashBits bits = HashBits.bit64) : base(capacity, bits)
        {
        }

        public TestTypedRegistryBase(bool repeatable, int capacity = 17, HashBits bits = HashBits.bit64) : base(repeatable, capacity, bits)
        {
        }

        public TestTypedRegistryBase(
                                                                                                                     IEnumerable<IIdentifiable> collection,
                                                                                                                     int capacity = 17,
                                                                                                                     bool repeatable = false,
                                                                                                                     HashBits bits = HashBits.bit64
                                                                                                                 ) : base(collection, capacity, repeatable, bits)
        {
        }

        public TestTypedRegistryBase(
                                                                                                                     IEnumerable<V> collection,
                                                                                                                     int capacity = 17,
                                                                                                                     bool repeatable = false,
                                                                                                                     HashBits bits = HashBits.bit64
                                                                                                                 ) : base(collection, capacity, repeatable, bits)
        {
        }

        public TestTypedRegistryBase(
                                                                                                                     IList<IUnique<V>> collection,
                                                                                                                     int capacity = 17,
                                                                                                                     bool repeatable = false,
                                                                                                                     HashBits bits = HashBits.bit64
                                                                                                                 ) : base(collection, capacity, repeatable, bits)
        {
        }

        public TestTypedRegistryBase(
                                                                                                                     IList<V> collection,
                                                                                                                     int capacity = 17,
                                                                                                                     bool repeatable = false,
                                                                                                                     HashBits bits = HashBits.bit64
                                                                                                                 ) : base(collection, capacity, repeatable, bits)
        {
        }

        public void PublicacquireReader()
        {
            base.acquireReader();
        }

        public void PublicacquireRemover()
        {
            base.acquireRemover();
        }

        public void PublicacquireWriter()
        {
            base.acquireWriter();
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

        public ISeriesItem<V> PublicGetItem(long key, V item)
        {
            return base.GetItem(key, item);
        }

        public int PublicIndexOf(long key, V item)
        {
            return base.IndexOf(key, item);
        }

        public bool PublicInnerAdd(ISeriesItem<V> value)
        {
            return base.InnerAdd(value);
        }

        public bool PublicInnerAdd(V value)
        {
            return base.InnerAdd(value);
        }

        public bool PublicInnerAdd(long key, V value)
        {
            return base.InnerAdd(key, value);
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

        public ISeriesItem<V> PublicInnerPut(V value)
        {
            return base.InnerPut(value);
        }

        public ISeriesItem<V> PublicInnerPut(long key, V value)
        {
            return base.InnerPut(key, value);
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

        public override ISeriesItem<V>[] EmptyVector(int size)
        {
            return default(ISeriesItem<V>[]);
        }
    }

    private TestTypedRegistryBase _testClass;
    private IFixture _fixture;
    private int _capacity;
    private HashBits _bits;
    private bool _repeatable;
    private IEnumerable<IIdentifiable> _collectionIEnumerableIIdentifiable;
    private IEnumerable<V> _collectionIEnumerableV;
    private IList<IUnique<V>> _collectionIListIUniqueV;
    private IList<V> _collectionIListV;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TypedRegistryBase"/>.
    /// </summary>
    public TypedRegistryBase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._capacity = _fixture.Create<int>();
        this._bits = _fixture.Create<HashBits>();
        this._repeatable = _fixture.Create<bool>();
        this._collectionIEnumerableIIdentifiable = _fixture.Create<IEnumerable<IIdentifiable>>();
        this._collectionIEnumerableV = _fixture.Create<IEnumerable<V>>();
        this._collectionIListIUniqueV = _fixture.Create<IList<IUnique<V>>>();
        this._collectionIListV = _fixture.Create<IList<V>>();
        this._testClass = _fixture.Create<TestTypedRegistryBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestTypedRegistryBase();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedRegistryBase(this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedRegistryBase(this._repeatable, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedRegistryBase(this._collectionIEnumerableIIdentifiable, this._capacity, this._repeatable, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedRegistryBase(this._collectionIEnumerableV, this._capacity, this._repeatable, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedRegistryBase(this._collectionIListIUniqueV, this._capacity, this._repeatable, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedRegistryBase(this._collectionIListV, this._capacity, this._repeatable, this._bits);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCollection()
    {
        FluentActions.Invoking(() => new TestTypedRegistryBase(default(IEnumerable<IIdentifiable>), this._capacity, this._repeatable, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedRegistryBase(default(IEnumerable<V>), this._capacity, this._repeatable, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedRegistryBase(default(IList<IUnique<V>>), this._capacity, this._repeatable, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedRegistryBase(default(IList<V>), this._capacity, this._repeatable, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
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
    /// Checks that the PublicacquireRemover method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallacquireRemover()
    {
        // Act
        this._testClass.PublicacquireRemover();

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

    /// <summary>
    /// Checks that the PublicGetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItemWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicGetItem(key, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicIndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOfWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicIndexOf(key, item);

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
    /// Checks that the Dequeue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDequeue()
    {
        // Act
        var result = this._testClass.Dequeue();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItemWithIndex()
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
    public void GetItemWithIndexPerformsMapping()
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
    public void CanCallIndexOfWithItem()
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
    public void CannotCallIndexOfWithItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.IndexOf(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
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
}