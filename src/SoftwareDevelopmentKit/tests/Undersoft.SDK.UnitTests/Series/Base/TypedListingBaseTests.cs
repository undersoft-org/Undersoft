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
/// Unit tests for the type <see cref="TypedListingBase"/>.
/// </summary>
public class TypedListingBase_1Tests
{
    private class TestTypedListingBase : TypedListingBase<V>
    {
        public TestTypedListingBase() : base()
        {
        }

        public TestTypedListingBase(
            IEnumerable<IUnique<V>> collection,
            int capacity = 17,
            bool repeatable = false,
            HashBits bits = HashBits.bit64
        ) : base(collection, capacity, repeatable, bits)
        {
        }

        public TestTypedListingBase(
            IEnumerable<V> collection,
            int capacity = 17,
            bool repeatable = false,
            HashBits bits = HashBits.bit64
        ) : base(collection, capacity, repeatable, bits)
        {
        }

        public TestTypedListingBase(bool repeatable, int capacity = 17, HashBits bits = HashBits.bit64) : base(repeatable, capacity, bits)
        {
        }

        public TestTypedListingBase(int capacity = 17, HashBits bits = HashBits.bit64) : base(capacity, bits)
        {
        }

        public ISeriesItem<V> PublicGetItem(long key, V item)
        {
            return base.GetItem(key, item);
        }

        public ISeriesItem<V> PubliccreateNew(ISeriesItem<V> item)
        {
            return base.createNew(item);
        }

        public ISeriesItem<V> PubliccreateNew(long key, V value)
        {
            return base.createNew(key, value);
        }

        public void PubliccreateRepeated(ISeriesItem<V> item, V value)
        {
            base.createRepeated(item, value);
        }

        public void PubliccreateRepeated(ISeriesItem<V> item, ISeriesItem<V> newitem)
        {
            base.createRepeated(item, newitem);
        }

        public ISeriesItem<V> PublicswapRepeated(ISeriesItem<V> item)
        {
            return base.swapRepeated(item);
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
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

        public void PublicInnerInsert(int index, ISeriesItem<V> item)
        {
            base.InnerInsert(index, item);
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

        public V PublicInnerRemove(long key, V item)
        {
            return base.InnerRemove(key, item);
        }

        public int PublicIndexOf(long key, V value)
        {
            return base.IndexOf(key, value);
        }

        public void PublicRehash(int newsize)
        {
            base.Rehash(newsize);
        }

        public void PublicReindex()
        {
            base.Reindex();
        }

        public void PublicrenewClear(int capacity)
        {
            base.renewClear(capacity);
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

    private TestTypedListingBase _testClass;
    private IFixture _fixture;
    private IEnumerable<IUnique<V>> _collectionIEnumerableIUniqueV;
    private int _capacity;
    private bool _repeatable;
    private HashBits _bits;
    private IEnumerable<V> _collectionIEnumerableV;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TypedListingBase"/>.
    /// </summary>
    public TypedListingBase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._collectionIEnumerableIUniqueV = _fixture.Create<IEnumerable<IUnique<V>>>();
        this._capacity = _fixture.Create<int>();
        this._repeatable = _fixture.Create<bool>();
        this._bits = _fixture.Create<HashBits>();
        this._collectionIEnumerableV = _fixture.Create<IEnumerable<V>>();
        this._testClass = _fixture.Create<TestTypedListingBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestTypedListingBase();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedListingBase(this._collectionIEnumerableIUniqueV, this._capacity, this._repeatable, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedListingBase(this._collectionIEnumerableV, this._capacity, this._repeatable, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedListingBase(this._repeatable, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedListingBase(this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCollection()
    {
        FluentActions.Invoking(() => new TestTypedListingBase(default(IEnumerable<IUnique<V>>), this._capacity, this._repeatable, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedListingBase(default(IEnumerable<V>), this._capacity, this._repeatable, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
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
    /// Checks that the Flush method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlush()
    {
        // Act
        this._testClass.Flush();

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
    /// Checks that the Next method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNext()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.Next(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Next method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNextWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Next(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
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
    /// Checks that the PubliccreateNew method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallcreateNewWithISeriesItemOfV()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PubliccreateNew(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PubliccreateNew method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallcreateNewWithISeriesItemOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PubliccreateNew(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PubliccreateNew method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallcreateNewWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PubliccreateNew(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PubliccreateNew maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void createNewWithLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PubliccreateNew(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PubliccreateRepeated method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallcreateRepeatedWithItemAndValue()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();
        var value = _fixture.Create<V>();

        // Act
        this._testClass.PubliccreateRepeated(item, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PubliccreateRepeated method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallcreateRepeatedWithItemAndValueWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PubliccreateRepeated(default(ISeriesItem<V>), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PubliccreateRepeated method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallcreateRepeatedWithItemAndNewitem()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();
        var newitem = _fixture.Create<ISeriesItem<V>>();

        // Act
        this._testClass.PubliccreateRepeated(item, newitem);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PubliccreateRepeated method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallcreateRepeatedWithItemAndNewitemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PubliccreateRepeated(default(ISeriesItem<V>), _fixture.Create<ISeriesItem<V>>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PubliccreateRepeated method throws when the newitem parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallcreateRepeatedWithItemAndNewitemWithNullNewitem()
    {
        FluentActions.Invoking(() => this._testClass.PubliccreateRepeated(_fixture.Create<ISeriesItem<V>>(), default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("newitem");
    }

    /// <summary>
    /// Checks that the PublicswapRepeated method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallswapRepeated()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PublicswapRepeated(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicswapRepeated method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallswapRepeatedWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicswapRepeated(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicDispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Arrange
        var disposing = _fixture.Create<bool>();

        // Act
        this._testClass.PublicDispose(disposing);

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
    /// Checks that the PublicInnerInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerInsert()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        this._testClass.PublicInnerInsert(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerInsert method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerInsertWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerInsert(_fixture.Create<int>(), default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
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
    public void CanCallInnerRemoveWithKey()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerRemove(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerRemoveWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerRemove(key, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryRemove()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.TryRemove(key, item);

        // Assert
        Assert.Fail("Create or modify test");
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
    /// Checks that the PublicIndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOfWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicIndexOf(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithISeriesItemOfV()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.Contains(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsWithISeriesItemOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Contains(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithIUniqueOfV()
    {
        // Arrange
        var item = _fixture.Create<IUnique<V>>();

        // Act
        var result = this._testClass.Contains(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsWithIUniqueOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Contains(default(IUnique<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithV()
    {
        // Arrange
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.Contains(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.Contains(key, item);

        // Assert
        Assert.Fail("Create or modify test");
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
    /// Checks that the PublicrenewClear method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallrenewClear()
    {
        // Arrange
        var capacity = _fixture.Create<int>();

        // Act
        this._testClass.PublicrenewClear(capacity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the First property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFirst()
    {
        // Assert
        this._testClass.First.Should().BeAssignableTo<ISeriesItem<V>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Last property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetLast()
    {
        // Assert
        this._testClass.Last.Should().BeAssignableTo<ISeriesItem<V>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsRepeatable property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIsRepeatable()
    {
        // Assert
        this._testClass.IsRepeatable.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }
}